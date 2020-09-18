using Destiny.Core.Flow.Attributes.Base;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Exceptions;
using JetBrains.Annotations;
using Microsoft.Extensions.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace Destiny.Core.Flow.Extensions
{
    /// <summary>
    /// Type类型扩展
    /// </summary>
    public static partial class Extensions
    {



        /// <summary>
        /// 判断类型是否为Nullable类型
        /// </summary>
        /// <param name="type"> 要处理的类型 </param>
        /// <returns> 是返回True，不是返回False </returns>
        public static bool IsNullableType(this Type type)
        {

            return ((type != null) && type.IsGenericType) && (type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }


        /// 判断当前类型是否可由指定类型派生
        /// </summary>
        public static bool IsDeriveClassFrom<TBaseType>(this Type type, bool canAbstract = false)
        {
            return IsDeriveClassFrom(type, typeof(TBaseType), canAbstract);
        }

        /// <summary>
        /// 判断当前类型是否可由指定类型派生
        /// </summary>
        public static bool IsDeriveClassFrom(this Type type, Type baseType, bool canAbstract = false)
        {
            type.NotNull(nameof(type));
            baseType.NotNull(nameof(baseType));
            return type.IsClass && (!canAbstract && !type.IsAbstract) && type.IsBaseOn(baseType);
        }


        /// <summary>
        /// 返回当前类型是否是指定基类的派生类
        /// </summary>
        /// <typeparam name="BaseType">要判断的基类型</typeparam>
        /// <param name="type">当前类型</param>
        /// <returns></returns>
        public static bool IsBaseOn<BaseType>(this Type type)
        {

            return type.IsBaseOn(typeof(BaseType));
        }

        /// <summary>
        /// 返回当前类型是否是指定基类的派生类
        /// </summary>
        /// <param name="type">当前类型</param>
        /// <param name="baseType">要判断的基类型</param>
        /// <returns></returns>
        public static bool IsBaseOn(this Type type, Type baseType)
        {
            if (baseType.IsGenericTypeDefinition)
            {
                return baseType.IsGenericAssignableFrom(type);
            }
            return baseType.IsAssignableFrom(type);
        }

        /// <summary>
        /// 判断当前泛型类型是否可由指定类型的实例填充
        /// </summary>
        /// <param name="genericType">泛型类型</param>
        /// <param name="type">指定类型</param>
        /// <returns></returns>
        public static bool IsGenericAssignableFrom(this Type genericType, Type type)
        {
            genericType.NotNull(nameof(genericType));
            type.NotNull(nameof(type));

            if (!genericType.IsGenericType)
            {
                throw new ArgumentException("该功能只支持泛型类型的调用，非泛型类型可使用 IsAssignableFrom 方法。");
            }

            List<Type> allOthers = new List<Type> { type };
            if (genericType.IsInterface)
            {
                allOthers.AddRange(type.GetInterfaces());
            }

            foreach (var other in allOthers)
            {
                Type cur = other;
                while (cur != null)
                {
                    if (cur.IsGenericType)
                    {
                        cur = cur.GetGenericTypeDefinition();
                    }
                    if (cur.IsSubclassOf(genericType) || cur == genericType)
                    {
                        return true;
                    }
                    cur = cur.BaseType;
                }
            }
            return false;
        }

        /// <summary>
        /// 通过类型转换器获取Nullable类型的基础类型
        /// </summary>
        /// <param name="type"> 要处理的类型对象 </param>
        /// <returns> </returns>
        public static Type GetUnNullableType(this Type type)
        {

            if (IsNullableType(type))
            {
                NullableConverter nullableConverter = new NullableConverter(type);
                return nullableConverter.UnderlyingType;
            }
            return type;
        }




        /// <summary>
        /// 判断是否IEnumerable、ICollection类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsEnumerable(this Type type)
        {
            return type.IsArray
                   || type.GetInterfaces().Any(x => x == typeof(ICollection) || x == typeof(IEnumerable));
        }

        /// <summary>
        /// 从类型成员获取指定Attribute特性
        /// </summary>
        /// <typeparam name="T">Attribute特性类型</typeparam>
        /// <param name="memberInfo">类型类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <returns>存在返回第一个，不存在返回null</returns>
        public static T GetAttribute<T>(this MemberInfo memberInfo, bool inherit = true) where T : Attribute
        {

            var attributes = memberInfo.GetCustomAttributes(typeof(T), inherit);
            return attributes.FirstOrDefault() as T;
        }



        /// <summary>
        /// 从类型成员获取指定Attribute特性
        /// </summary>
        /// <typeparam name="type">Attribute特性类型</typeparam>
        /// <param name="memberInfo">类型类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <returns>存在返回第一个，不存在返回null</returns>
        public static Type GetAttribute(this MemberInfo memberInfo, Type type, bool inherit = true)
        {
            var attributes = memberInfo.GetCustomAttributes(type, inherit);
            return attributes.FirstOrDefault() as Type;
        }

        /// <summary>
        /// 判断是否实体类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsEntityType(this Type type)
        {
            type.NotNull(nameof(type));
            return typeof(IEntity<>).IsGenericAssignableFrom(type) && !type.IsAbstract && !type.IsInterface;
        }



        public static string ToDescription(this MemberInfo member)
        {

            DescriptionAttribute desc = member.GetCustomAttribute<DescriptionAttribute>();
            if (!desc.IsNull())
            {
                return desc.Description;
            }

            //显示名
            DisplayNameAttribute display = member.GetCustomAttribute<DisplayNameAttribute>();
            if (!display.IsNull())
            {
                return display.DisplayName;
            }
            return member.Name;

        }

        /// <summary>
        /// 得到特性下描述 
        /// </summary>
        /// <typeparam name="TAttribute">动态特性</typeparam>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string ToDescription<TAttribute>(this MemberInfo member)
            where TAttribute : AttributeBase
        {

            var attributeBase = (AttributeBase)member.GetCustomAttribute<TAttribute>();
            if (!attributeBase.IsNull())
            {
                return attributeBase.Description();
            }
            return member.Name;

        }





        /// <summary>
        /// 基础类型
        /// </summary>
        private static readonly Type[] _basicTypes =
        {
            typeof(bool),

            typeof(sbyte),
            typeof(byte),
            typeof(int),
            typeof(uint),
            typeof(short),
            typeof(ushort),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal),

            typeof(Guid),

            typeof(DateTime),// IsPrimitive:False
            typeof(TimeSpan),// IsPrimitive:False
            typeof(DateTimeOffset),

            typeof(char),
            typeof(string),// IsPrimitive:False

            //typeof(object),// IsPrimitive:False
        };

        /// <summary>
        /// get TypeCode for specific type
        /// </summary>
        /// <param name="type">type</param>
        /// <returns></returns>
        public static TypeCode GetTypeCode(this Type type) => Type.GetTypeCode(type);

        /// <summary>
        /// 是否是 ValueTuple
        /// </summary>
        /// <param name="type">type</param>
        /// <returns></returns>
        public static bool IsValueTuple([NotNull] this Type type)
                => type.IsValueType && type.FullName?.StartsWith("System.ValueTuple`", StringComparison.Ordinal) == true;

        /// <summary>
        /// GetDescription
        /// </summary>
        /// <param name="type">type</param>
        /// <returns></returns>
        public static string GetDescription([NotNull] this Type type) =>
            type.GetCustomAttribute<DescriptionAttribute>()?.Description ?? string.Empty;

        /// <summary>
        /// 判断是否基元类型，如果是可空类型会先获取里面的类型，如 int? 也是基元类型
        /// The primitive types are Boolean, Byte, SByte, Int16, UInt16, Int32, UInt32, Int64, UInt64, IntPtr, UIntPtr, Char, Double, and Single.
        /// </summary>
        /// <param name="type">type</param>
        /// <returns></returns>
        public static bool IsPrimitiveType([NotNull] this Type type)
            => (Nullable.GetUnderlyingType(type) ?? type).IsPrimitive;

        public static bool IsPrimitiveType<T>() => typeof(T).IsPrimitiveType();

        public static bool IsBasicType([NotNull] this Type type) => _basicTypes.Contains(type) || type.IsEnum;

        public static bool IsBasicType<T>() => typeof(T).IsBasicType();

        public static bool IsBasicType<T>(this T value) => value.IsBasicType();

        /// <summary>
        /// Finds best constructor, least parameter
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="parameterTypes"></param>
        /// <returns>Matching constructor or default one</returns>
        [CanBeNull]
        public static ConstructorInfo GetConstructor<T>(this Type type, params Type[] parameterTypes)
        {
            if (parameterTypes == null || parameterTypes.Length == 0)
                return GetEmptyConstructor(type);

            var constructors = type.GetConstructors();

            var ctors = constructors
                .OrderBy(c => c.IsPublic ? 0 : (c.IsPrivate ? 2 : 1))
                .ThenBy(c => c.GetParameters().Length)
                .ToArray();

            foreach (var ctor in ctors)
            {
                var parameters = ctor.GetParameters();
                if (parameters.All(p => parameterTypes.Contains(p.ParameterType)))
                {
                    return ctor;
                }
            }

            return null;
        }

        [CanBeNull]
        public static ConstructorInfo GetEmptyConstructor(this Type type)
        {
            var constructors = type.GetConstructors();

            var ctor = constructors.OrderBy(c => c.IsPublic ? 0 : (c.IsPrivate ? 2 : 1))
                .ThenBy(c => c.GetParameters().Length).FirstOrDefault();

            return ctor?.GetParameters().Length == 0 ? ctor : null;
        }

        /// <summary>
        /// Determines whether this type is assignable to <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to test assignability to.</typeparam>
        /// <param name="this">The type to test.</param>
        /// <returns>True if this type is assignable to references of type
        /// <typeparamref name="T"/>; otherwise, False.</returns>
        public static bool IsAssignableTo<T>(this Type @this)
        {
            if (@this == null)
            {
                throw new ArgumentNullException(nameof(@this));
            }

            return typeof(T).IsAssignableFrom(@this);
        }

        /// <summary>
        /// Finds a constructor with the matching type parameters.
        /// </summary>
        /// <param name="type">The type being tested.</param>
        /// <param name="constructorParameterTypes">The types of the contractor to find.</param>
        /// <returns>The <see cref="ConstructorInfo"/> is a match is found; otherwise, <c>null</c>.</returns>
        [CanBeNull]
        public static ConstructorInfo GetMatchingConstructor(this Type type, Type[] constructorParameterTypes)
        {
            if (constructorParameterTypes == null || constructorParameterTypes.Length == 0)
                return GetEmptyConstructor(type);

            return type.GetConstructors().FirstOrDefault(c => c.GetParameters().Select(p => p.ParameterType).SequenceEqual(constructorParameterTypes));
        }

        /// <summary>
        /// Get ImplementedInterfaces
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>当前类型实现的接口的集合。</returns>
        public static IEnumerable<Type> GetImplementedInterfaces([NotNull] this Type type)
        {
            return type.GetTypeInfo().ImplementedInterfaces;
        }

        public static bool IsNonAbstractClass(this Type type, bool publicOnly)
        {
            var typeInfo = type.GetTypeInfo();

            if (typeInfo.IsSpecialName)
            {
                return false;
            }

            if (typeInfo.IsClass && !typeInfo.IsAbstract)
            {
                if (typeInfo.IsDefined(typeof(CompilerGeneratedAttribute), inherit: true))
                {
                    return false;
                }

                if (publicOnly)
                {
                    return typeInfo.IsPublic || typeInfo.IsNestedPublic;
                }

                return true;
            }

            return false;
        }

        public static IEnumerable<Type> GetBaseTypes(this Type type)
        {
            var typeInfo = type.GetTypeInfo();

            foreach (var implementedInterface in typeInfo.ImplementedInterfaces)
            {
                yield return implementedInterface;
            }

            var baseType = typeInfo.BaseType;

            while (baseType != null)
            {
                var baseTypeInfo = baseType.GetTypeInfo();

                yield return baseType;

                baseType = baseTypeInfo.BaseType;
            }
        }

        public static bool IsInNamespace(this Type type, string @namespace)
        {
            var typeNamespace = type.Namespace ?? string.Empty;

            if (@namespace.Length > typeNamespace.Length)
            {
                return false;
            }

            var typeSubNamespace = typeNamespace.Substring(0, @namespace.Length);

            if (typeSubNamespace.Equals(@namespace, StringComparison.Ordinal))
            {
                if (typeNamespace.Length == @namespace.Length)
                {
                    //exactly the same
                    return true;
                }

                //is a subnamespace?
                return typeNamespace[@namespace.Length] == '.';
            }

            return false;
        }

        public static bool IsInExactNamespace(this Type type, string @namespace)
        {
            return string.Equals(type.Namespace, @namespace, StringComparison.Ordinal);
        }

        public static bool HasAttribute(this Type type, Type attributeType)
        {
            return type.GetTypeInfo().IsDefined(attributeType, inherit: true);
        }

        public static bool HasAttribute<T>(this Type type, Func<T, bool> predicate) where T : Attribute
        {
            return type.GetTypeInfo().GetCustomAttributes<T>(inherit: true).Any(predicate);
        }

        public static bool IsAssignableTo(this Type type, Type otherType)
        {
            var typeInfo = type.GetTypeInfo();
            var otherTypeInfo = otherType.GetTypeInfo();

            if (otherTypeInfo.IsGenericTypeDefinition)
            {
                return typeInfo.IsAssignableToGenericTypeDefinition(otherTypeInfo);
            }

            return otherTypeInfo.IsAssignableFrom(typeInfo);
        }

        private static bool IsAssignableToGenericTypeDefinition(this TypeInfo typeInfo, TypeInfo genericTypeInfo)
        {
            var interfaceTypes = typeInfo.ImplementedInterfaces.Select(t => t.GetTypeInfo());

            foreach (var interfaceType in interfaceTypes)
            {
                if (interfaceType.IsGenericType)
                {
                    var typeDefinitionTypeInfo = interfaceType
                        .GetGenericTypeDefinition()
                        .GetTypeInfo();

                    if (typeDefinitionTypeInfo.Equals(genericTypeInfo))
                    {
                        return true;
                    }
                }
            }

            if (typeInfo.IsGenericType)
            {
                var typeDefinitionTypeInfo = typeInfo
                    .GetGenericTypeDefinition()
                    .GetTypeInfo();

                if (typeDefinitionTypeInfo.Equals(genericTypeInfo))
                {
                    return true;
                }
            }

            var baseTypeInfo = typeInfo.BaseType?.GetTypeInfo();

            if (baseTypeInfo is null)
            {
                return false;
            }

            return baseTypeInfo.IsAssignableToGenericTypeDefinition(genericTypeInfo);
        }


        private static IEnumerable<Type> GetImplementedInterfacesToMap(TypeInfo typeInfo)
        {
            if (!typeInfo.IsGenericType)
            {
                return typeInfo.ImplementedInterfaces;
            }

            if (!typeInfo.IsGenericTypeDefinition)
            {
                return typeInfo.ImplementedInterfaces;
            }

            return FilterMatchingGenericInterfaces(typeInfo);
        }

        private static IEnumerable<Type> FilterMatchingGenericInterfaces(TypeInfo typeInfo)
        {
            var genericTypeParameters = typeInfo.GenericTypeParameters;

            foreach (var current in typeInfo.ImplementedInterfaces)
            {
                var currentTypeInfo = current.GetTypeInfo();

                if (currentTypeInfo.IsGenericType && currentTypeInfo.ContainsGenericParameters
                    && GenericParametersMatch(genericTypeParameters, currentTypeInfo.GenericTypeArguments))
                {
                    yield return currentTypeInfo.GetGenericTypeDefinition();
                }
            }
        }

        private static bool GenericParametersMatch(IReadOnlyList<Type> parameters, IReadOnlyList<Type> interfaceArguments)
        {
            if (parameters.Count != interfaceArguments.Count)
            {
                return false;
            }

            for (var i = 0; i < parameters.Count; i++)
            {
                if (parameters[i] != interfaceArguments[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static string ToFriendlyName(this Type type)
        {
            return TypeNameHelper.GetTypeDisplayName(type, includeGenericParameterNames: true);
        }

        public static bool IsOpenGeneric(this Type type)
        {
            return type.GetTypeInfo().IsGenericTypeDefinition;
        }

        public static bool HasMatchingGenericArity(this Type interfaceType, TypeInfo typeInfo)
        {
            if (typeInfo.IsGenericType)
            {
                var interfaceTypeInfo = interfaceType.GetTypeInfo();

                if (interfaceTypeInfo.IsGenericType)
                {
                    var argumentCount = interfaceType.GenericTypeArguments.Length;
                    var parameterCount = typeInfo.GenericTypeParameters.Length;

                    return argumentCount == parameterCount;
                }

                return false;
            }

            return true;
        }

        public static Type GetRegistrationType(this Type interfaceType, TypeInfo typeInfo)
        {
            if (typeInfo.IsGenericTypeDefinition)
            {
                var interfaceTypeInfo = interfaceType.GetTypeInfo();

                if (interfaceTypeInfo.IsGenericType)
                {
                    return interfaceType.GetGenericTypeDefinition();
                }
            }

            return interfaceType;
        }

        /// <summary>
        /// 是原始的扩展包括空
        /// </summary>
        /// <param name="type"></param>
        /// <param name="includeEnums"></param>
        /// <returns></returns>
        public static bool IsPrimitiveExtendedIncludingNullable(this Type type, bool includeEnums = false)
        {
            if (IsPrimitiveExtended(type, includeEnums)) return true;

            if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return IsPrimitiveExtended(type.GenericTypeArguments[0], includeEnums);

            return false;
        }

        private static bool IsPrimitiveExtended(Type type, bool includeEnums)
        {
            if (type.GetTypeInfo().IsPrimitive) return true;

            if (includeEnums && type.GetTypeInfo().IsEnum) return true;

            return type == typeof(string) ||
                   type == typeof(decimal) ||
                   type == typeof(DateTime) ||
                   type == typeof(DateTimeOffset) ||
                   type == typeof(TimeSpan) ||
                   type == typeof(Guid);
        }


        public static Expression GetKeySelector(this Type type, string keyName)
        {

            string key = $"{type.FullName}.{keyName}";
            //if (Cache.ContainsKey(key))
            //{
            //    return Cache[key];
            //}
            ParameterExpression param = Expression.Parameter(type);
            string[] propertyNames = keyName.Split(".");
            Expression propertyAccess = param;

            foreach (var propertyName in propertyNames)
            {
                PropertyInfo property = type.GetProperty(propertyName);
                if (property.IsNull())
                {
                    throw new AppException($"查找类似 指定对象中不存在名称为“{propertyName}”的属性");
                }
                type = property.PropertyType;
                propertyAccess = Expression.Property(propertyAccess, propertyName);
            }

            return propertyAccess;
        }

    }
}
