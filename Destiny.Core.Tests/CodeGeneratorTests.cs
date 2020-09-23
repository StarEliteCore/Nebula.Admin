using Destiny.Core.Flow.CodeGenerator;
using Destiny.Core.Flow.TestBase;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
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
                IsSoftDelete = false,
                AuditedUserKeyType = "Guid",
                IsAutoMap=true,
               

            };
            var savePath = @"C:\Users\Admin\Desktop\Code";
            ICodeGenerator codeGenerator = ServiceProvider.GetService<ICodeGenerator>();
            codeGenerator.GenerateCode(projectMetadata, savePath);
        }
    }
}
