using System.IO;

namespace Destiny.Core.Flow.Extensions
{
    public static class FileExtensions
    {

        /// <summary>
        /// 判断是否文件
        /// </summary>
        /// <param name="fileName">要判断文件名</param>
        /// <param name="fileExtension">要判断文件后缀名</param>
        /// <returns>如何是返回ture,则返回false</returns>
        public static bool IsFile(this string fileName,string fileExtension)
        {

            if (Path.GetExtension(fileExtension).ToLower() != fileExtension) //txt文件
            {

                return false;
            }
            return true;

        }
    }
}
