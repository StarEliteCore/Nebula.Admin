using Destiny.Core.AspNetMvc.Test.EntityFrameworkCore.Entities;
using DestinyCore.Entity;
using DestinyCore.Enums;
using DestinyCore.Mapping;
using System;

namespace Destiny.Core.AspNetMvc.Test.Dtos
{
    [AutoMapping(typeof(User_Test))]
    public class User_TestInputDto : IInputDto<Guid>
    {
        public User_TestInputDto()
        {
        }


        public Guid Id { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }
      
        public bool IsDeleted { get; set; }
    }

  
}
