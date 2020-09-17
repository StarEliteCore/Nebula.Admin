using Destiny.Core.Flow.Data.Core;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Model.Entities.Function;
using Destiny.Core.Flow.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            var controllerActionDescriptorList = _actionProvider.ActionDescriptors.Items.Cast<ControllerActionDescriptor>().Where(o => o.ControllerTypeInfo.IsBaseOn<BaseType>() && !o.ControllerTypeInfo.HasAttribute<AllowAnonymousAttribute>());

            var functionInfos = GetFunctions(controllerActionDescriptorList.ToArray());
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
                var fcutionSelector = functionInfos.Select(o => o.LinkUrl);
                var dbFcutions = repository.Entities.ToList();
                var deleteDbFcutions = dbFcutions.Where(o => !fcutionSelector.Contains(o.LinkUrl)).ToArray();
                var addDbActions = functionInfos.Where(db => !dbFcutions.Select(o => o.LinkUrl).Contains(db.LinkUrl)).ToArray();
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
                    this.UpdateFunctions(updateDbFcutions, functionInfos, repository);
                }
                repository.UnitOfWork.Commit();
            });
        }

        private void UpdateFunctions(IEnumerable<Function> updatFunction, IEnumerable<FunctionInfo> functionInfos, IEFCoreRepository<Function, Guid> repository)
        {
            foreach (var function in updatFunction)
            {
                FunctionInfo functionInfo = functionInfos.FirstOrDefault(o =>
                    string.Equals(o.LinkUrl, function.LinkUrl, StringComparison.OrdinalIgnoreCase)

                     );
                if (functionInfo == null)
                {
                    continue;
                }

                bool isUpdate = false;

                if (function.Name != functionInfo.Name)
                {
                    isUpdate = true;
                    function.Name = functionInfo.Name;
                }
                if (function.LinkUrl?.ToLower() != functionInfo.LinkUrl?.ToLower())
                {
                    isUpdate = true;
                    function.LinkUrl = functionInfo.LinkUrl;
                }
                if (isUpdate)
                {
                    repository.Update(function);
                    _logger.LogInformation($"更新【{function.Name}】名字，链接Url：【{function.LinkUrl}】");
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

                Description = model.Description,
                IsEnabled = true,
                LinkUrl = model.LinkUrl.ToLower()
            };
        }

        private FunctionInfo[] GetFunctions(ControllerActionDescriptor[] controllers)
        {
            List<FunctionInfo> functions = new List<FunctionInfo>();
            foreach (var controllerDescriptor in controllers.OrderBy(o => o.ControllerName))
            {
                var controller = GetController(controllerDescriptor);
                if (controller is null)
                {
                    continue;
                }

                if (controllerDescriptor.MethodInfo.HasAttribute<AllowAnonymousAttribute>())
                {
                    continue;
                }

                var action = this.GetAction(controller, controllerDescriptor.MethodInfo, controllerDescriptor);
                if (action is null)
                {
                    continue;
                }
                if (!functions.Any(o => action.Name.Equals(o.Name, StringComparison.OrdinalIgnoreCase) &&
                action.LinkUrl.Equals(o.LinkUrl, StringComparison.OrdinalIgnoreCase)))
                {
                    functions.Add(action);
                }
                //if (!functions.Any(o => controller.Name.Equals(o.Name, StringComparison.OrdinalIgnoreCase) &&
                //   controller.LinkUrl.Equals(o.LinkUrl, StringComparison.OrdinalIgnoreCase)))
                //{
                //    functions.Add(controller);
                //}
            }
            return functions.ToArray();
        }

        private FunctionInfo GetController(ControllerActionDescriptor controller)
        {
            return new FunctionInfo()
            {
                Name = controller.ControllerTypeInfo.ToDescription(),

                LinkUrl = controller.ControllerName
            };
        }

        private FunctionInfo GetAction(FunctionInfo function, MethodInfo method, ControllerActionDescriptor controller)
        {
            return new FunctionInfo
            {
                Name = $"{function.Name}-{method.ToDescription()}",
                LinkUrl = $"{controller.ControllerName}/{controller.ActionName}".ToLower()
            };
        }
    }
}