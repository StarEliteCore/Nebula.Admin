using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.Flow.EntityFrameworkCore;
using Destiny.Core.Flow.Extensions;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Destiny.Core.Flow.Model.SeedDatas
{
    public class UserSeedData : SeedDataBase<User, Guid>
    {
        private ILogger _logger = null;
        public UserSeedData(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _logger = serviceProvider.GetLogger(GetType());
        }

        
        
        public override bool Disable => false;

        protected override Expression<Func<User, bool>> Expression(User entity)
        {

            return o => o.UserName == entity.UserName && o.NickName == entity.NickName;
        }

        protected override void SaveDatabase(User[] entities)
        {
            if (entities == null || entities.Length == 0)
            {

                return;
            }
            _serviceProvider.CreateScoped(provider =>
            {
                var repository = provider.GetService<IEFCoreRepository<User, Guid>>();
                var unitOfWork = provider.GetService<IUnitOfWork>();
                unitOfWork.BeginTransaction();
                foreach (var entitie in entities)
                {
                    if (repository.TrackEntities.Where(Expression(entitie)).Any())
                    {
                        continue;
                    }
                    repository.Insert(entities);


                }
                unitOfWork.Commit();
            });


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
