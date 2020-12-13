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
    }
}
