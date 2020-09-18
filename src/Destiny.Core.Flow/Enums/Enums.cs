using Destiny.Core.Flow.Filter;
using System.ComponentModel;

namespace Destiny.Core.Flow.Enums
{

    public enum OperationResponseType
    {

        [Description("操作成功")]
        Success = 0,

        [Description("操作引发错误")]
        Error = 5,


        [Description("系统出现异常")]
        Exp = 10,

        [Description("数据源不存在")]
        QueryNull = 15,


        [Description("操作没有引发任何变化")]
        NoChanged = 20,
    }

    public enum AjaxResultType
    {
        /// <summary>
        /// 消息结果
        /// </summary>
        [Description("消息结果")]

        Info = 203,

        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 200,

        /// <summary>
        /// 错误
        /// </summary>
        [Description("错误")]
        Error = 500,

        /// <summary>
        /// 未经授权
        /// </summary>
        [Description("未经授权")]
        Unauthorized = 401,

        /// <summary>
        /// 已登录但权限不足
        /// </summary>
        [Description("当前用户权限不足")]
        Uncertified = 403,

        /// <summary>
        /// 功能资源找不到
        /// </summary>
        [Description("当前功能资源找不到")]
        NoFound = 404


    }

    [Description("姓别")]
    public enum Sex
    {
        [Description("男")]
        Man,
        [Description("女")]
        Female
    }


    /// <summary>
    /// 排序方向
    /// </summary>
    public enum SortDirection
    {

        Ascending = 0,

        Descending = 1
    }


    [Description("过滤操作器")]

    //过滤操作器
    public enum FilterOperator
    {

        /// <summary>
        /// 
        /// </summary>

        [Description("等于")]
        Equal,

        [Description("大于")]
        GreaterThan,


        [Description("大于或等于")]
        GreaterThanOrEqual,


        [Description("小于")]
        LessThan,


        [Description("小于或等于")]
        LessThanOrEqual,


        [Description("不等于")]
        NotEqual,


        [Description("包含")]
        In,


        [Description("模糊查询")]
        Like,
    }

    [Description("过滤连接器")]
    public enum FilterConnect
    {
        [FilterCode("and")]
        And,

        [FilterCode("or")]
        Or
    }

    [Description("Dto状态")]
    public enum DtoState
    {

        [Description("新增")]
        Add = 0,
        [Description("更新")]
        Update = 5
    }
}
