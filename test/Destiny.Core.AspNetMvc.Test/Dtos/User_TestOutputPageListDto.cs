using AutoMapper;
using Destiny.Core.AspNetMvc.Test.EntityFrameworkCore.Entities;
using DestinyCore.Entity;
using DestinyCore.Enums;
using DestinyCore.Mapping;

using System;
using System.ComponentModel;

namespace Destiny.Core.AspNetMvc.Test.Dtos
{
    [AutoMapping(typeof(User_Test))]
    public class User_TestOutputPageListDto : IPagedListDto<Guid>
    {

        public string Description { get; set; }
        public string Name { get; set; }
        public Guid? CreatorUserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public Guid? LastModifierUserId { get; set; }
        public DateTime? LastModifionTime { get; set; }
        public bool IsDeleted { get; set; }
        public Guid Id { get; set; }
    }
}