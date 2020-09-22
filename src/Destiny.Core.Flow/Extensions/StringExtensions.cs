using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Destiny.Core.Flow.Extensions
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 以指定字符串作为分隔符将指定字符串分隔成数组
        /// </summary>
        /// <param name="value">要分割的字符串</param>
        /// <param name="strSplit">字符串类型的分隔符</param>
        /// <param name="removeEmptyEntries">是否移除数据中元素为空字符串的项</param>
        /// <returns>分割后的数据</returns>
        public static string[] Split(this string value, string strSplit, bool removeEmptyEntries = false)
        {

            value.NotNullOrEmpty(nameof(value));
            strSplit.NotNullOrEmpty(nameof(strSplit));
            return value.Split(new[] { strSplit },
                removeEmptyEntries ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
        }
        /// <summary>
        /// 将字符中拼接
        /// </summary>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string StrToJoin(this string value, string left, string right, string separator = ",")
        {
            value.NotNullOrEmpty(nameof(value));
            left.NotNullOrEmpty(nameof(left));
            right.NotNullOrEmpty(nameof(right));
            StringBuilder sb = new StringBuilder();
            if (!value.IsNullOrEmpty())
            {
                foreach (var item in value.Split(separator))
                {
                    sb.AppendFormat("{0}{1}{2}{3}", left, item, right, separator);
                }
            }
            return sb.ToString().TrimEnd(separator.ToCharArray());
        }
        /// <summary>
        ///把字符串转成SQL中IN
        /// </summary>
        /// <param name="value">要转换的值</param>
        /// <param name="left">左边符</param>
        /// <param name="right">右边符</param>
        /// <param name="inMiddleSeparator">in里面中间分割符:"'a','b'"</param>
        /// <param name="valueSeparator">值分割符如："a,b,c,d"</param>
        /// <returns>返回组装好的值，例如"'a','b'"</returns>
        public static string ToSqlIn(this string value, string left = "'", string right = "'", string inMiddleSeparator = ",",
            string valueSeparator = ",")
        {
            value.NotNullOrEmpty(nameof(value));

            StringBuilder sb = new StringBuilder();
            if (!value.IsNullOrEmpty())
            {
                foreach (var item in value.Split(valueSeparator))
                {
                    sb.AppendFormat("{0}{1}{2}{3}", left, item, right, inMiddleSeparator);
                }
            }
            else
            {
                return value;
            }
            return sb.ToString().TrimEnd(inMiddleSeparator.ToCharArray());
        }
        /// <summary>
        /// 是否为空或者为null或者空格
        /// </summary>
        /// <param name="value">要判断的值</param>
        /// <returns>返回true/false</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        /// <summary>
        /// 是否为空或者为null
        /// </summary>
        /// <param name="value">要判断的值</param>
        /// <returns>返回true/false</returns>
        public static bool IsNullOrEmpty(this string value)
        {

            return string.IsNullOrEmpty(value);
        }
        /// <summary>
        /// 判断是否数字
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInt(this string value)
        {
            return Regex.IsMatch(value, @"^[0-9]*$");
        }
        /// <summary>
        /// 在指定的输入字符串中搜索指定的正则表达式的第一个匹配项
        /// </summary>
        /// <param name="value">要搜索匹配项的字符串</param>
        /// <param name="pattern">要匹配的正则表达式模式</param>
        /// <returns>一个对象，包含有关匹配项的信息</returns>
        public static string Match(this string value, string pattern)
        {
            if (value == null)
            {
                return null;
            }
            return Regex.Match(value, pattern).Value;
        }
        public static string FormatWith(this string format, params object[] args)
        {
            format.NotNull("format");
            return string.Format(CultureInfo.CurrentCulture, format, args);
        }

        public static string RemovePostFix(this string str, params string[] postFixes)
        {
            return str.RemovePostFix(StringComparison.Ordinal, postFixes);
        }

        public static string RemovePostFix(this string str, StringComparison comparisonType, params string[] postFixes)
        {
            if (str.IsNullOrEmpty())
            {
                return null;
            }

            if (postFixes.Any())
            {
                return str;
            }

            foreach (var postFix in postFixes)
            {
                if (str.EndsWith(postFix, comparisonType))
                {
                    return str.Left(str.Length - postFix.Length);
                }
            }

            return str;
        }

        public static string Left(this string str, int len)
        {
            str.NotNull(nameof(str));

            if (str.Length < len)
            {
                throw new ArgumentException("len参数不能大于给定字符串的长度!");
            }

            return str.Substring(0, len);
        }

        /// <summary>
        /// 单词变成单数形式
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ToMakeSingle(string name)
        {
            Regex plural1 = new Regex("(?<keep>[^aeiou])ies$");
            Regex plural2 = new Regex("(?<keep>[aeiou]y)s$");
            Regex plural3 = new Regex("(?<keep>[sxzh])es$");
            Regex plural4 = new Regex("(?<keep>[^sxzhyu])s$");

            if (plural1.IsMatch(name))
                return plural1.Replace(name, "${keep}y");
            else if (plural2.IsMatch(name))
                return plural2.Replace(name, "${keep}");
            else if (plural3.IsMatch(name))
                return plural3.Replace(name, "${keep}");
            else if (plural4.IsMatch(name))
                return plural4.Replace(name, "${keep}");

            return name;
        }

        /// <summary>
        /// 单词变成复数形式
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ToMakePlural(string name)
        {
            Regex plural1 = new Regex("(?<keep>[^aeiou])y$");
            Regex plural2 = new Regex("(?<keep>[aeiou]y)$");
            Regex plural3 = new Regex("(?<keep>[sxzh])$");
            Regex plural4 = new Regex("(?<keep>[^sxzhy])$");

            if (plural1.IsMatch(name))
                return plural1.Replace(name, "${keep}ies");
            else if (plural2.IsMatch(name))
                return plural2.Replace(name, "${keep}s");
            else if (plural3.IsMatch(name))
                return plural3.Replace(name, "${keep}es");
            else if (plural4.IsMatch(name))
                return plural4.Replace(name, "${keep}s");

            return name;
        }

        /// <summary>
        /// 将驼峰字符串的第一个字符小写
        /// </summary>
        public static string LowerFirstChar(this string str)
        {
            if (string.IsNullOrEmpty(str) || !char.IsUpper(str[0]))
            {
                return str;
            }
            if (str.Length == 1)
            {
                return char.ToLower(str[0]).ToString();
            }
            return char.ToLower(str[0]) + str.Substring(1, str.Length - 1);
        }
    }
}
