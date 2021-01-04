using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.ExpressionUtil;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Metadata.Builders;
using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.MongoDB.Repositorys;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Identity;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Audit
{
    public class AuditStore : IAuditStore
    {
        private readonly IMongoDBRepository<AuditLog, ObjectId> _auditLogRepository;
        private readonly IMongoDBRepository<AuditEntry, ObjectId> _auditEntryRepository;
        private readonly IMongoDBRepository<AuditPropertysEntry, ObjectId> _auditPropertysEntryRepository;
        private readonly UserManager<User> _userManager = null;

        private readonly IPrincipal _principal;

        public AuditStore(IMongoDBRepository<AuditLog, ObjectId> auditLogRepository, IMongoDBRepository<AuditEntry, ObjectId> auditEntryRepository, IMongoDBRepository<AuditPropertysEntry, ObjectId> auditPropertysEntryRepository, UserManager<User> userManager,IPrincipal principal)
        {
            _auditLogRepository = auditLogRepository;
            _auditEntryRepository = auditEntryRepository;
            _auditPropertysEntryRepository = auditPropertysEntryRepository;
            _userManager = userManager;
            _principal = principal;


        }



        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedResult<AuditLogOutputPageDto>> GetAuditLogPageAsync(PageRequest request)
        {

            var exp = MongoDBFilterBuilder.GetExpression<AuditLog>(request.Filter);
            OrderCondition<AuditLog>[] orderConditions = new OrderCondition<AuditLog>[] { new OrderCondition<AuditLog>(o => o.CreatedTime, Enums.SortDirection.Descending) };
            request.OrderConditions = orderConditions;
            //_auditLogRepository.Collection.Find(o=>o.FunctionName.Contains("dd"))
            var page= await _auditLogRepository.Collection.ToPageAsync(exp, request, x => new AuditLogOutputPageDto
            {
                BrowserInformation = x.BrowserInformation,
                Ip = x.Ip,
                FunctionName = x.FunctionName,
                Action = x.Action,
                ExecutionDuration = x.ExecutionDuration,
                CreatedTime = x.CreatedTime,
                Id = x.Id,
                OperationType=x.OperationType,
                Message=x.Message,
                UserId=x.UserId,
                NickName=x.NickName,
                UserName=x.UserName
            });
            return page;

        }

    

  

        /// <summary>
        /// 分页获取数据实体审计 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        public async Task<IPagedResult<AuditEntryOutputPageDto>> GetAuditEntryPageAsync(PageRequest request)
        {
            var exp = MongoDBFilterBuilder.GetExpression<AuditEntry>(request.Filter);
            OrderCondition<AuditEntry>[] orderConditions = new OrderCondition<AuditEntry>[] { new OrderCondition<AuditEntry>(o => o.CreatedTime, Enums.SortDirection.Descending) };
            request.OrderConditions = orderConditions;
            var page= await _auditEntryRepository.Collection.ToPageAsync(exp, request, x => new AuditEntryOutputPageDto
            {
               Id=x.Id,
               EntityAllName=x.EntityAllName,
               EntityDisplayName=x.EntityDisplayName,
               KeyValues=x.KeyValues,
               OperationType=x.OperationType,
               CreatedTime=x.CreatedTime,
               NickName=x.NickName,
               UserName=x.UserName,

               
           
            });
 
            return page;
        }

        /// <summary>
        /// 分页获取数据实体属性审计 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IPagedResult<AuditPropertyEntryOutputPageDto>> GetAuditEntryPropertyPageAsync(PageRequest request)
        {
            var exp = MongoDBFilterBuilder.GetExpression<AuditPropertysEntry>(request.Filter);

            var page = await _auditPropertysEntryRepository.Collection.ToPageAsync(exp, request, x => new AuditPropertyEntryOutputPageDto
            {
                Id = x.Id,
                PropertieDisplayName=x.PropertieDisplayName,
                NewValues=x.NewValues,
                OriginalValues=x.OriginalValues,
                Properties=x.Properties,
                PropertiesType=x.PropertiesType,

            });
            return page;
       
        }

       

        public async Task SaveAsync(AuditChange auditChange)
        {
            if (auditChange !=null)
            {

                var time = DateTime.Now;
                AuditLog auditLog = new AuditLog();
                auditLog.Action = auditChange.Action;
                auditLog.BrowserInformation = auditChange.BrowserInformation;
                auditLog.FunctionName = auditChange.FunctionName;
                auditLog.Ip = auditChange.Ip;
                auditLog.OperationType = auditChange.ResultType;
                auditLog.ExecutionDuration = auditChange.ExecutionDuration;
                auditLog.UserId = _principal?.Identity?.GetUesrId();
                auditLog.Message = auditChange.Message;
                auditLog.CreatedTime = time;

                var userId = auditLog.UserId.AsTo<Guid>();
                var user = _userManager.Users.Where(o => o.Id == userId).FirstOrDefault();
                auditLog.NickName = user?.NickName;
                auditLog.UserName = user?.UserName;

                List<AuditEntry> auditEntryList = new List<AuditEntry>();
                List<AuditPropertysEntry> auditPropertyList = new List<AuditPropertysEntry>();
                
                foreach (var item in auditChange.AuditEntitys)
                {
                    AuditEntry auditEntry = new AuditEntry();
                    auditEntry.AuditLogId = auditLog.Id;
                    auditEntry.EntityAllName = item.EntityName;
                    auditEntry.EntityDisplayName = item.DisplayName;
                    auditEntry.OperationType = item.OperationType;
                    auditEntry.KeyValues = item.KeyValues;
                    auditEntry.EntityDisplayName = item.DisplayName;
                    auditEntry.NickName = auditLog.NickName;
                    auditEntry.UserName = auditLog.UserName;
                    auditEntry.CreatedTime = time;
                    foreach (var auditProperty in item.AuditPropertys)
                    {
                        AuditPropertysEntry auditPropertyModel = new AuditPropertysEntry();
                        auditPropertyModel.AuditEntryId = auditEntry.Id;
                        auditPropertyModel.NewValues = auditProperty.NewValues;
                        auditPropertyModel.OriginalValues = auditProperty.OriginalValues;
                        auditPropertyModel.Properties = auditProperty.PropertyName;
                        auditPropertyModel.PropertieDisplayName = auditProperty.PropertyDisplayName;
                        auditPropertyModel.PropertiesType = auditProperty.PropertyType;
                        auditPropertyList.Add(auditPropertyModel);
                    }
                    auditEntryList.Add(auditEntry);
                }
                await _auditLogRepository.InsertAsync(auditLog);
                if (auditEntryList.Any())
                {
                    await _auditEntryRepository.InsertAsync(auditEntryList.ToArray());
                }

                if (auditPropertyList.Any())
                {
                    await _auditPropertysEntryRepository.InsertAsync(auditPropertyList.ToArray());
                }
            }
            
         
        }
    }
}