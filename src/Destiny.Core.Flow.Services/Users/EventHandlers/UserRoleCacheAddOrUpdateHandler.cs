using Destiny.Core.Flow.Caching;
using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.Services.Users.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Users.EventHandlers
{
    public class UserRoleCacheAddOrUpdateHandler : CacheHandlerBase<UserRoleCacheAddOrUpdateEvent>
    {
        public UserRoleCacheAddOrUpdateHandler(ICache cache) : base(cache)
        {
        }

        public override async Task Handle(UserRoleCacheAddOrUpdateEvent notification, CancellationToken cancellationToken)
        {
            var key = $"{UserCacheKeys.userRoleKeyPrefix}{notification.User.Id}";
            if (notification.EventState == EventState.Add)
            {
                await AddUserRoleCacheItem(key, notification.User, notification.Roles);
            }
            else
            {
                await _cache.RemoveAsync(key);

                await AddUserRoleCacheItem(key, notification.User, notification.Roles);
            }
            async Task AddUserRoleCacheItem(string key, User user, IEnumerable<Role> roles)
            {
                var roleCaheItem = roles.Select(o => new RoleCaheItem(o.Id, o.Name, o.IsAdmin));
                UserRoleCacheItem userRoleCacheItem = new UserRoleCacheItem(notification.User.Id, roleCaheItem);
                await _cache.SetAsync(key, userRoleCacheItem);
            }
        }

        private class UserRoleCacheItem
        {
            public UserRoleCacheItem(Guid userId, IEnumerable<RoleCaheItem> roles)
            {
                UserId = userId;
                Roles = roles;
            }

            public Guid UserId { get; private set; }

            public IEnumerable<RoleCaheItem> Roles { get; private set; } = new List<RoleCaheItem>();
        }

        private class RoleCaheItem
        {
            public RoleCaheItem(Guid roleId, string roleName, bool isAdmin)
            {
                RoleId = roleId;
                RoleName = roleName;
                IsAdmin = isAdmin;
            }

            public Guid RoleId { get; private set; }

            public string RoleName { get; private set; }

            public bool IsAdmin { get; private set; }
        }
    }
}