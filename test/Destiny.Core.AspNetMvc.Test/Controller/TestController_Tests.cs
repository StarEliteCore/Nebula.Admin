using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using DestinyCore;
using DestinyCore.Helpers;
using Newtonsoft.Json;
using DestinyCore.AspNetCore;
using Destiny.Core.Flow.Shared.Extensions;
using Microsoft.AspNetCore.Http;

namespace Destiny.Core.AspNetMvc.Test.Controller
{
    public class TestController_Tests: AspNetMvcTestBase
    {

        [Fact]
        public async Task Should_Trigger_TestController_Get()
        {
            var url = "api/test/GetPage";
            var reust=await this.GetResponseAsStringAsync(url);
          
            reust.ShouldBe("Ok");
    
        }

        [Fact]
        public async Task Should_Trigger_TestController_GetPost()
        {
            var url = "api/test/GetPost";
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("Id", 18);
            dic.Add("Name", "大黄瓜");
            var obj = (await this.Client.PostAsStringAsync(url, dic));
            obj.ShouldBe("Ok");
        }


        [Fact]
        public async Task Should_Trigger_TestController_GetDelete()
        {
            var url = "api/test/GetDelete";
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("id", 18);

           
      
            var response = await this.Client.DeleteAsyncJson(url,dic);
            response.ShouldBe("Ok");
        }
    }



}

public class TestObj { 
   public int Id { get; set; }
   public string Name { get; set; }

}
