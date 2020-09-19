using Destiny.Core.Flow.CodeGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Destiny.Core.Tests
{
  public  class CodeGeneratorTests
    {

        public CodeGeneratorTests()
        {
           
        }

        [Fact]
        public void CodeGenerate_Test()
        {
            ProjectMetadata projectMetadata = new ProjectMetadata();
            projectMetadata.Company = "大黄瓜有限公司";
            projectMetadata.SiteUrl = "http://admin.destinycore.club";
            projectMetadata.Creator = "大黄瓜18cm";
            projectMetadata.Copyright = "大黄瓜18cm";
            projectMetadata.Namespace = "Destiny.Core.Flow.Model";
            List<PropertyMetadata> propertyMetadatas = new List<PropertyMetadata>();
            propertyMetadatas.Add(new PropertyMetadata()
            {
                IsNullable = false,
                IsPrimaryKey = false,
                CSharpType = "string",
                DisplayName = "名字",
                PropertyName = "Name"

            });
            propertyMetadatas.Add(new PropertyMetadata()
            {
                IsNullable = false,
                IsPrimaryKey = false,
                CSharpType = "string",
                DisplayName = "名字1",
                PropertyName = "Name1"

            });
            projectMetadata.EntityMetadata = new EntityMetadata()
            {
                EntityName = "TestCode",
                DisplayName = "代码生成",
                PrimaryKeyType = "Guid",
                PrimaryKeyName = "Id",
                Properties = propertyMetadatas

            };
            var savePath = @"C:\Users\Admin\Desktop\Code";
            ICodeGenerator codeGenerator = new RazorCodeGenerator();
            codeGenerator.GenerateCode(projectMetadata, savePath);
        }
    }
}
