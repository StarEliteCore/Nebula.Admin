namespace Destiny.Core.Flow.Extensions
{
    public static partial class Extensions
    {

        /// <summary>
        /// 可空Bool转成Bool
        /// </summary>
        /// <param name="bool"></param>
        /// <returns></returns>
        public static bool NullableBoolToBool(bool? @bool)
        {
            return @bool == null || @bool == false ? false : true;
        }
    }
}
