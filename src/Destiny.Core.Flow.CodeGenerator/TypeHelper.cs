using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Destiny.Core.Flow.CodeGenerator
{
    /// <summary>
    /// 类型帮助
    /// </summary>
    public static  class TypeHelper
    {

        /// <summary>
        /// c#类型
        /// </summary>
        private static readonly Dictionary<Type, string> _cSharpType = new Dictionary<Type, string>
        {

            { typeof(bool), "bool" },
            { typeof(byte), "byte" },
            { typeof(char), "char" },
            { typeof(decimal), "decimal" },
            { typeof(double), "double" },
            { typeof(float), "float" },
            { typeof(int), "int" },
            { typeof(long), "long" },
            { typeof(object), "object" },
            { typeof(sbyte), "sbyte" },
            { typeof(short), "short" },
            { typeof(string), "string" },
            { typeof(uint), "uint" },
            { typeof(ulong), "ulong" },
            { typeof(ushort), "ushort" },
            { typeof(Guid),"Guid"}
        };

        /// <summary>
        /// 得到c#类型
        /// </summary>
        /// <returns></returns>
        public static Dictionary<Type, string> GetCSharpType()
        {

            return _cSharpType;
        }

        /// <summary>
        /// 根据类型全称转成类型名
        /// </summary>
        /// <param name="typeFullName"></param>
        /// <returns></returns>
        public static string ToTypeName(string typeFullName)
        {
           return _cSharpType.Where(o => o.Key.FullName == typeFullName)?.FirstOrDefault().Value;
        }


        public static string ToSingleTypeName(string cSharpType, bool isNullable)
        {

            if (cSharpType == typeof(string).Name.ToLower())
            {
                return cSharpType;
            }

            return $"{cSharpType}{(isNullable ? "?" : "")}";
        }

        /// <summary>
        /// 得到想要的集合
        /// </summary>
        /// <param name="aggregateName">集合名</param>
        /// <param name="cSharpType">类型</param>
        /// <param name="isNullable">是否可空</param>
        /// <returns>返回转后集合</returns>
        public static string GetAggregate(string aggregateName, string cSharpType, bool isNullable)
        {
            //Guid? []
            //List<string>//
            //IEnumerable<string>//
            //ICollection
            //[]
            if (aggregateName == "[]")  //数组
            {
               return  $"{TypeHelper.ToSingleTypeName(cSharpType,isNullable)}{aggregateName}";
            }
            else {

                return $"{aggregateName}<{TypeHelper.ToSingleTypeName(cSharpType,isNullable)}>";
            }
        

        }

    }
}
