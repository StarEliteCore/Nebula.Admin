using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.ExpressionUtil;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
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
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Audit
{
    public class AuditServices : IAuditStore
    {
        private readonly IMongoDBRepository<AuditLog, ObjectId> _auditLogRepository;
        private readonly IMongoDBRepository<AuditEntry, ObjectId> _auditEntryRepository;
        private readonly IMongoDBRepository<AuditPropertysEntry, ObjectId> _auditPropertysEntryRepository;
        private readonly UserManager<User> _userManager = null;

        public AuditServices(IMongoDBRepository<AuditLog, ObjectId> auditLogRepository, IMongoDBRepository<AuditEntry, ObjectId> auditEntryRepository, IMongoDBRepository<AuditPropertysEntry, ObjectId> auditPropertysEntryRepository, UserManager<User> userManager)
        {
            _auditLogRepository = auditLogRepository;
            _auditEntryRepository = auditEntryRepository;
            _auditPropertysEntryRepository = auditPropertysEntryRepository;
            _userManager = userManager;
        }

        public async Task Save(AuditLog auditLog, List<AuditEntryInputDto> auditEntry)
        {
            var ss = auditEntry.MapToList<AuditEntry>();
            List<AuditEntry> auditentrylist = new List<AuditEntry>();
            List<AuditPropertysEntry> auditpropertysentrylist = new List<AuditPropertysEntry>();
            foreach (var item in auditEntry)
            {
                var model = item.MapTo<AuditEntry>();
                model.AuditLogId = auditLog.Id;
                foreach (var auditProperty in item.AuditPropertys)
                {
                    var auditPropertymodel = auditProperty.MapTo<AuditPropertysEntry>();
                    auditPropertymodel.AuditEntryId = model.Id;
                    auditpropertysentrylist.Add(auditPropertymodel);
                }
                auditentrylist.Add(model);
            }
            await _auditLogRepository.InsertAsync(auditLog);
            await _auditEntryRepository.InsertAsync(auditentrylist.ToArray());
            await _auditPropertysEntryRepository.InsertAsync(auditpropertysentrylist.ToArray());
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedResult<AuditLogOutputPageDto>> GetAuditLogPageAsync(PageRequest request)
        {
            var exp = FilterBuilder.GetExpression<AuditLog>(request.Filter);
            OrderCondition<AuditLog>[] orderConditions = new OrderCondition<AuditLog>[] { new OrderCondition<AuditLog>(o => o.CreatedTime, Enums.SortDirection.Descending) };
            request.OrderConditions = orderConditions;
            var users = _userManager.Users.ToList();
            var page= await _auditLogRepository.Collection.ToPageAsync(exp, request, x => new AuditLogOutputPageDto
            {
                BrowserInformation = x.BrowserInformation,
                Ip = x.Ip,
                FunctionName = x.FunctionName,
                Action = x.Action,
                ExecutionDuration = x.ExecutionDuration,
                CreatorUserId = x.CreatorUserId,
                CreatedTime = x.CreatedTime,
                Id = x.Id,
                //NickName=x.CreatorUserId == Guid.Empty || x.CreatorUserId == null ? string.Empty : users.FirstOrDefault(o => o.Id == x.CreatorUserId.Value).NickName
            });

            page.ItemList.ForEach(x =>
            {

                x.NickName = x.CreatorUserId == Guid.Empty || x.CreatorUserId == null ? string.Empty : users.FirstOrDefault(o => o.Id == x.CreatorUserId.Value).NickName;
                x.UserName = x.CreatorUserId == Guid.Empty || x.CreatorUserId == null ? string.Empty : users.FirstOrDefault(o => o.Id == x.CreatorUserId.Value).UserName;
            });
            return page;
        }

        public async Task<OperationResponse> GetAuditEntryListByAuditLogIdAsync(ObjectId id)
        {
            var list = await _auditEntryRepository.Entities.Where(x => x.AuditLogId == id)
                .Select(x => new AuditEntryOutputDto
                {
                    EntityAllName = x.EntityAllName,
                    EntityDisplayName = x.EntityDisplayName,
                    TableName = x.TableName,
                    KeyValues = x.KeyValues,
                    OperationType = x.OperationType,
                    Id=x.Id
                }).ToListAsync();
            return new OperationResponse(MessageDefinitionType.LoadSucces, list, OperationResponseType.Success);
        }

        public async Task<OperationResponse> GetAuditEntryListByAuditEntryIdAsync(ObjectId id)
        {
            var list = await _auditPropertysEntryRepository.Entities.Where(x => x.AuditEntryId == id).Select(x => new AuditPropertyEntryOutputDto
            {
                Properties = x.Properties,
                PropertieDisplayName = x.PropertieDisplayName,
                OriginalValues = x.OriginalValues,
                NewValues = x.NewValues,
                PropertiesType = x.PropertiesType,
                Id=x.Id
            }).ToListAsync();
            return new OperationResponse(MessageDefinitionType.LoadSucces, list, OperationResponseType.Success);
        }


        /// <summary>
        /// 分页获取数据实体审计 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        public async Task<IPagedResult<AuditEntryOutputDto>> GetAuditEntryPageAsync(PageRequest request)
        {
            var exp = FilterBuilder.GetExpression<AuditEntry>(request.Filter);
            OrderCondition<AuditEntry>[] orderConditions = new OrderCondition<AuditEntry>[] { new OrderCondition<AuditEntry>(o => o.CreatedTime, Enums.SortDirection.Descending) };
            request.OrderConditions = orderConditions;
            var users = _userManager.Users.ToList();
            var page= await _auditEntryRepository.Collection.ToPageAsync(exp, request, x => new AuditEntryOutputDto
            {
               Id=x.Id,
               EntityAllName=x.EntityAllName,
               EntityDisplayName=x.EntityDisplayName,
               KeyValues=x.KeyValues,
               OperationType=x.OperationType,
               CreatedTime=x.CreatedTime,
               CreatorUserId=x.CreatorUserId
           
            });
            page.ItemList.ForEach(x =>
            {

                x.NickName = x.CreatorUserId == Guid.Empty || x.CreatorUserId == null ? string.Empty : users.FirstOrDefault(o => o.Id == x.CreatorUserId.Value).NickName;
            });
       

            return page;
        }

        /// <summary>
        /// 分页获取数据实体属性审计 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IPagedResult<AuditPropertyEntryOutputDto>> GetAuditEntryPropertyPageAsync(PageRequest request)
        {
            var exp = FilterBuilder.GetExpression<AuditPropertysEntry>(request.Filter);
            OrderCondition<AuditPropertysEntry>[] orderConditions = new OrderCondition<AuditPropertysEntry>[] { new OrderCondition<AuditPropertysEntry>(o => o.CreatedTime, Enums.SortDirection.Descending) };
            request.OrderConditions = orderConditions;
            var page = await _auditPropertysEntryRepository.Collection.ToPageAsync(exp, request, x => new AuditPropertyEntryOutputDto
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
    }
}