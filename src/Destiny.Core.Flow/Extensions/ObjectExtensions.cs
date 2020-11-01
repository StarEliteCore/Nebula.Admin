using MongoDB.Bson;
using System;
using System.Reflection;

namespace Destiny.Core.Flow.Extensions
{
    /// <summary>
    /// 对象扩展方法
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 把对象类型转换为指定类型
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <param name="type">要转换的类型</param>
        /// <returns></returns>
        public static object AsTo(this object value, Type type)
        {
            if (value == null || value is DBNull)
            {
                return null;
            }


            //如果是Nullable类型
            if (type.IsNullableType())
            {

                type = type.GetUnNullableType();

            }


            //枚举类型
            if (type.IsEnum)
            {
                return Enum.Parse(type, value.ToString());
            }

            //if (type == typeof(Enum))
            //{
            //    return Enum.Parse(type, value.ToString());
            //}


            if (type == typeof(Guid))
            {
                Guid.TryParse(value.ToString(), out var newGuid);
                return newGuid;
            }

            if (value?.GetType() == typeof(Guid))
            {

                return value.ToString();
            }

            if (type == typeof(ObjectId))
            {

                ObjectId.TryParse(value.ToString(),out var newValue);
                return newValue;
            }

            return Convert.ChangeType(value, type);
        }

        /// <summary>
        /// 把对象类型转换为指定类型
        /// </summary>
        /// <typeparam name="T">动态类型</typeparam>
        /// <param name="value">要转换对象</param>
        /// <returns>转化后的指定类型的对象</returns>

        public static T AsTo<T>(this object value)
        {

            return (T)AsTo(value, typeof(T));
        }

        /// <summary>
        /// 类型转换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>

        public static T As<T>(this object obj) where T : class
        {

            return (T)obj;
        }
        /// <summary>
        /// 是否为Null
        /// </summary>
        /// <param name="value">判断的值</param>
        /// <returns>true为null,false不为null</returns>
        public static bool IsNull(this object value)
        {

            return value == null ? true : false;
        }

        public static bool IsNotNull(this object value)
        {

            return !value.IsNull();
        }



        /// <summary>
        /// 判断特性相应是否存在
        /// </summary>
        /// <typeparam name="T">动态类型要判断的特性</typeparam>
        /// <param name="memberInfo"></param>
        /// <param name="inherit"></param>
        /// <returns>如果存在还在返回true，否则返回false</returns>
        public static bool HasAttribute<T>(this MemberInfo memberInfo, bool inherit = true) where T : Attribute
        {
            return memberInfo.IsDefined(typeof(T), inherit);
        }


        /// <summary>
        /// 检查对象是否为泛型列表。
        /// </summary>
        /// <param name="o">要转换对象</param>
        /// <returns>如果对象是泛型列表，则为true。</returns>
        public static bool IsGenericList(this object o)
        {
            var oType = o.GetType();
            return (oType.IsGenericType && (oType.GetGenericTypeDefinition() == typeof(System.Collections.Generic.List<>)));
        }



    }
}
