using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Model.Entities.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq.Expressions;

namespace Destiny.Core.Flow.Model.SeedDatas
{
    [Dependency(ServiceLifetime.Singleton)]
    public class UserSeedData : SeedDataDefaults<User, Guid>
    {
        public UserSeedData(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public override bool Disable => false;

        protected override Expression<Func<User, bool>> Expression(User entity)
        {
            return o => o.UserName == entity.UserName && o.NickName == entity.NickName;
        }

        protected override User[] SetSeedData()
        {
            return new User[] {
              new User()
               {
                Id = Guid.Parse("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"),
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                NickName = "管理员",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEEPWhHPCHU1i6Z0ayoApKGbPlZUb38RUdJg4QjUcccVhUSto0sRZtLOXfwWUJ+P2Xw==",
                SecurityStamp = "3OWMGQAK5ZTXMSV6OFSGIWWWNIWJ2SX6",
                ConcurrencyStamp = "0286cab6-8a4a-44ed-9a97-86b0506c65c3",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                IsSystem = true,
                CreatedTime = DateTime.Now,
                IsDeleted = false,
                Description = "系统管理员拥有所有权限",
                Sex = Sex.Man
               }
            };
        }
    }
}