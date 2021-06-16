using Destiny.Core.AspNetMvc.Test;
using Destiny.Core.AspNetMvc.Test.Dtos;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Destiny.Core.Flow.Shared.Extensions;
using DestinyCore.AspNetCore;

namespace Destiny.Core.AspNetMvc.Test.Controller
{
    public class User_TestController_Tests : AspNetMvcTestBase
    {


        [Fact]
        public async Task Should_Trigger_User_TestController_CreateAsync()
        {
            var url = "api/User_Test/CreateAsync";
            var dto = new User_TestInputDto();
            dto.Name = "大黄瓜";
            dto.Description = "大黄瓜测试";
            dto.Id = Guid.NewGuid();
            dto.IsDeleted = false;
            var reust = await this.Client.PostObjectAsync<AjaxResult, User_TestInputDto>(url,dto);

            reust.Success.ShouldBe(true);

        }

        [Fact]
        public async Task Should_Trigger_User_TestController_UpdateAsync()
        {
            var url = "api/User_Test/UpdateAsync";
            var dto = new User_TestInputDto();
            dto.Name = "大黄瓜";
            dto.Description = "大黄瓜测试";
            dto.Id =Guid.Parse("9af57d58-92ba-4f43-9e43-f4195ab66f56");
            dto.IsDeleted = false;
            var reust = await this.Client.PostObjectAsync<AjaxResult, User_TestInputDto>(url, dto);

            reust.Success.ShouldBe(true);

        }


        [Fact]
        public async Task Should_Trigger_User_TestController_DeleteAsync()
        {
            var url = "api/User_Test/DeleteAsync";

            var reust = await this.Client.DeleteObjectAsync(url, new Dictionary<string, object> { { "key", "9af57d58-92ba-4f43-9e43-f4195ab66f56" } });

            reust.Success.ShouldBe(true);

        }
    }
}
