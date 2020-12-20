using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Exceptions
{
   public class MessageBox
    {


        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="message"></param>
        public static void Show(string message) => throw new AppException(message);


        public static void Show(string message, Exception  ex) => throw new AppException(message, ex);

        public static void ShowIf(string message, bool flag) {

            if (flag)
            {
                throw new AppException(message);
            }
        }
    }
}
