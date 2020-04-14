using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using Destiny.Core.Flow;

namespace Destiny.Core.Tests
{
    public class ExpressionTest
    {


        [Fact]
        public void Expressionable_Qury_Test()
        {
            List<ExpressionableTest> expressionables = new List<ExpressionableTest>();


            for (int i = 0; i < 100; i++)
            {
                expressionables.Add(new ExpressionableTest()
                {
                    Id = i,
                    Name = $"Name_{i}",
                   

                });
            }

            var exp = Expressionable.Create<ExpressionableTest>();
            exp.And(o => o.Id == 0);

            var list = expressionables.AsQueryable().Where(exp.ToExpression()).ToList();
            Assert.True(list.Count() > 0);
        }
    }


    public class ExpressionableTest
    {
        public int Id { get; set; }

        public string Name { get; set; }


    }
}
