using Destiny.Core.Flow.CodeGenerator;
using Destiny.Core.Flow.TestBase;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.Flow.Exceptions;
using System.IO;

namespace Destiny.Core.Tests
{
  public  class CodeGeneratorTests : IntegratedTest<CodeGeneratorModeule>
    {

        public CodeGeneratorTests()
        {
           
        }

        [Fact]
        public void CodeGenerate_Test()
        {
            ProjectMetadata projectMetadata = new ProjectMetadata();
            projectMetadata.Company = "大黄瓜科技有限公司";
            projectMetadata.SiteUrl = "http://admin.destinycore.club";
            projectMetadata.Creator = "大黄瓜18cm";
            projectMetadata.Copyright = "大黄瓜18cm";
            projectMetadata.Namespace = "Destiny.Core.Flow";
            projectMetadata.SaveFilePath = @"C:\Users\Admin\Desktop\Code";
            List<PropertyMetadata> propertyMetadatas = new List<PropertyMetadata>();
            propertyMetadatas.Add(new PropertyMetadata()
            {
                IsNullable = false,
                IsPrimaryKey = false,
                CSharpType = "string",
                DisplayName = "名字",
                PropertyName = "Name",
                IsPageDto=true,
                

            });
            propertyMetadatas.Add(new PropertyMetadata()
            {
                IsNullable = false,
                IsPrimaryKey = false,
                CSharpType = "string",
                DisplayName = "名字1",
                PropertyName = "Name1"

            });
            propertyMetadatas.Add(new PropertyMetadata()
            {
                IsNullable = false,
                IsPrimaryKey = false,
                CSharpType = "int",
                DisplayName = "价格",
                PropertyName = "Price",
                IsPageDto=false

            });
            projectMetadata.EntityMetadata = new EntityMetadata()
            {
                EntityName = "TestCode",
                DisplayName = "代码生成",
                PrimaryKeyType = "Guid",
                PrimaryKeyName = "Id",
                Properties = propertyMetadatas,
                IsCreation = true,
                IsModification = true,
                IsSoftDelete = true,
                AuditedUserKeyType = "Guid",
                IsAutoMap=true,
                
               

            };
     
            ICodeGenerator codeGenerator = ServiceProvider.GetService<ICodeGenerator>();

            codeGenerator.GenerateCode(projectMetadata);
       
        }

        [Fact]
        public void GetAggregate_Test()
        {

            
            var nullableArr = TypeHelper.GetAggregate("[]", "Guid", true); //空数组
            var notNullableArr = TypeHelper.GetAggregate("[]", "Guid", false); //非空数组
            Assert.True(nullableArr == "Guid?[]");
            Assert.True(notNullableArr == $"{typeof(Guid[]).Name}");
            

            var nullableIEnumerable = TypeHelper.GetAggregate("IEnumerable", "Guid", true); //空IEnumerable
            var notNullableIEnumerable = TypeHelper.GetAggregate("IEnumerable", "Guid", false); //非空IEnumerable
            Assert.True(nullableIEnumerable == "IEnumerable<Guid?>");
            Assert.True(notNullableIEnumerable == "IEnumerable<Guid>");

            
            var nullableList = TypeHelper.GetAggregate("List", "Guid", true); //空List
            var notNullableList = TypeHelper.GetAggregate("List", "Guid", false); //非空List
            Assert.True(nullableList == "List<Guid?>");
            Assert.True(notNullableList == "List<Guid>");


            var nullableCollection = TypeHelper.GetAggregate("ICollection", "Guid", true); //空List
            var notNullableCollection = TypeHelper.GetAggregate("ICollection", "Guid", false); //非空List
            Assert.True(nullableCollection == "ICollection<Guid?>");
            Assert.True(notNullableCollection == "ICollection<Guid>");
        }
    }
}
