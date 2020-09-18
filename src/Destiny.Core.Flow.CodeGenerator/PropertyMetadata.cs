namespace Destiny.Core.Flow.CodeGenerator
{
    /// <summary>
    /// 属性元数据
    /// </summary>
    public class PropertyMetadata
    {
        /// <summary>
        /// 是否主键
        /// </summary>

        public bool IsPrimaryKey { get; set; }
        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 是否允许为空
        /// </summary>
        public bool IsNullable { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }


        /// <summary>
        /// C#数据类型
        /// </summary>
        public string CSharpType { get; set; }

    }
}
