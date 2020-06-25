using Destiny.Core.Flow.Data.Core;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Destiny.Core.Flow.Extensions;
using Microsoft.Extensions.Logging;
using Destiny.Core.Flow.Exceptions;
using System.Reflection;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Destiny.Core.Flow.Model.Entities.Function;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Destiny.Core.Flow.Model.Security
{
    //[Dependency(ServiceLifetime.Scoped)]
    public class FunctionHandler : IFunctionHandler
    {

        private readonly IAssemblyFinder _assemblyFinder = null;
        private readonly ILogger _logger = null;

        private readonly IActionDescriptorCollectionProvider _actionProvider = null;
        private readonly IServiceProvider _serviceProvider = null;


        public FunctionHandler(IAssemblyFinder assemblyFinder, ILoggerFactory loggerFactory, IActionDescriptorCollectionProvider actionProvider, IServiceProvider serviceProvider)
        {
            _assemblyFinder = assemblyFinder;
            _logger = loggerFactory.CreateLogger(typeof(FunctionHandler));
            _actionProvider = actionProvider;
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 每次查询全表比较慢。。。。。
        /// </summary>
        /// <typeparam name="BaseType"></typeparam>
        public void Initialize<BaseType>()
        {
            //foreach (var item in _actionProvider.ActionDescriptors.Items.Cast<ControllerActionDescriptor>().Where(o=>o.ControllerTypeInfo.HasAttribute<FunctionAttribute>()))
            //{
                
            //}
            var tyeps = _assemblyFinder.FindAll().SelectMany(o => o.GetTypes()).Where(o => o.IsController() && o.IsBaseOn<BaseType>()).ToArray();
            var functionInfos = GetFunctions(tyeps);
            this.SavaData(functionInfos);
        }

        private void SavaData(IEnumerable<FunctionInfo> functionInfos)
        {
            if (!functionInfos.Any())
            {
                return;
            }
            _serviceProvider.CreateScoped<IEFCoreRepository<Function, Guid>>(repository =>
            {
                var fcutionSelector = functionInfos.Select(o => o.Controller + o.Action);
                var dbFcutions = repository.Entities.ToList();
                var deleteDbFcutions = dbFcutions.Where(o => !fcutionSelector.Contains(o.Controller + o.Action)).ToArray();
                var addDbActions = functionInfos.Where(db => !dbFcutions.Select(o => o.Controller + o.Action).Contains(db.Controller + db.Action)).ToArray();
                repository.UnitOfWork.BeginTransaction();
                if (deleteDbFcutions.Any())
                {

                    repository.Delete(deleteDbFcutions);
                    _logger.LogInformation($"已删除【{deleteDbFcutions.Select(o => o.Name).ToJoin("、")}】功能,删除成功{deleteDbFcutions.Length}条");
                }

                if (addDbActions.Any())
                {
                   repository.Insert(this.AddFunctions(addDbActions));
                    _logger.LogInformation($"添加【{addDbActions.Select(o => o.Name).ToJoin("、")}】功能,添加成功{addDbActions.Length}条");
                }

                var updateDbFcutions = dbFcutions.Except(deleteDbFcutions);


                if (updateDbFcutions.Any())
                {

                    this.UpdateFunctions(updateDbFcutions,functionInfos,repository);
                }
                repository.UnitOfWork.Commit();
            });
        }

        private void UpdateFunctions(IEnumerable<Function> updatFunction, IEnumerable<FunctionInfo> functionInfos, IEFCoreRepository<Function, Guid> repository)
        {

            foreach (var function in updatFunction)
            {


                FunctionInfo functionInfo = functionInfos.FirstOrDefault(o =>
                    string.Equals(o.Controller, function.Controller, StringComparison.OrdinalIgnoreCase)
                    && string.Equals(o.Action, function.Action, StringComparison.OrdinalIgnoreCase)
                     );
                if (functionInfo == null)
                {
                    continue;
                }

                bool isUpdate = false;

                if (function.Controller != functionInfo.Controller)
                {
                    isUpdate = true;
                    function.Controller = functionInfo.Controller;
                }

                if (function.Action != functionInfo.Action)
                {
                    isUpdate = true;
                    function.Action = functionInfo.Action;
                }

                if (function.Name != functionInfo.Name)
                {
                    isUpdate = true;
                    function.Name = functionInfo.Name;
                }
                if (function.Url?.ToUpper() != functionInfo.Url?.ToUpper())
                {
                    isUpdate = true;
                    function.Url = functionInfo.Url;
                }
                if (isUpdate)
                {
                    repository.Update(function);
                    _logger.LogInformation($"更新【{function.Name}】名字，控制器：【{function.Controller}】,方法：【{function.Action}】功能");
                }
                
            }
        }

        private Function[] AddFunctions(IEnumerable<FunctionInfo> functionInfos)
        {
            List<Function> addFunctions = new List<Function>();
            foreach (var functionInfo in functionInfos)
            {
                addFunctions.Add(this.MapToEntity(functionInfo));
            }
            return addFunctions.ToArray();
        }

        private Function MapToEntity(FunctionInfo model)
        {

            return new Function
            {
                Name = model.Name,
                Controller = model.Controller,
                Action = model.Action,
                Description = model.Description,
                IsEnabled = true,
                Url=model.Url.ToUpper()
            };
        }
        private FunctionInfo[] GetFunctions(Type[] types)
        {
            List<FunctionInfo> functions = new List<FunctionInfo>();
            foreach (var type in types.OrderBy(o => o.FullName))
            {
                var controller = GetController(type);
                if (controller is null)
                {
                    continue;
                }
                if (!functions.Any(o => controller.Name.Equals(o.Name, StringComparison.OrdinalIgnoreCase) &&
                     controller.Controller.Equals(o.Controller, StringComparison.OrdinalIgnoreCase)))
                {
                    functions.Add(controller);
                }

                var actions = this.GetControllerActions(type);

                foreach (var method in actions)
                {
                    var action = this.GetAction(controller, method);
                    if (action is null)
                    {
                        continue;
                    }
                    if (!functions.Any(o => action.Name.Equals(o.Name, StringComparison.OrdinalIgnoreCase) &&
                    action.Controller.Equals(o.Controller, StringComparison.OrdinalIgnoreCase)))
                    {
                        functions.Add(action);
                    }

                }

            }
            return functions.ToArray();
        }

        /// <summary>
        /// 得到控制下所有方法集合
        /// </summary>
        /// <returns></returns>
        private IEnumerable<MethodInfo> GetControllerActions(Type type)
        {
            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        }

        private FunctionInfo GetController(Type type)
        {

            if (!type.IsController())
            {

                throw new AppException($"此类型{type.FullName}不是控制器!");
            }

            var controller = type.Name.Replace("ControllerBase", string.Empty).Replace("Controller", string.Empty);
            return new FunctionInfo()
            {
                Name = type.ToDescription(),
                Controller = controller,
                Url= controller

            };
        }

        private FunctionInfo GetAction(FunctionInfo function, MethodInfo method)
        {
            return new FunctionInfo
            {
                Name = $"{function.Name}-{method.ToDescription()}",
                Controller = function.Controller,
                Action = method.Name,
                Url=$"{function.Controller}/{method.Name}"
            };
        }


    }
}
