using System;

namespace Destiny.Core.Flow.Ui
{
    /// <summary>
    /// 结果类型枚举
    /// </summary>
    /// <typeparam name="IType"></typeparam>
    public interface IHasResultType<IType> where IType : Enum
    {
        IType Type { get; set; }
    }
}
