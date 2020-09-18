using System;
using System.Security.Cryptography;
using System.Text;

namespace Destiny.Core.Flow.Extensions
{
    /// <summary>
    /// 加密解密扩展
    /// </summary>
    public static partial class Extensions
    {

        #region 计算输入数据的MD5哈希值
        /// <summary>
        ///获取32位md5加密
        /// </summary>
        /// <param name="source">待解密的字符串</param>
        /// <returns></returns>
        public static string To32MD5(this string source)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                string hash = sBuilder.ToString();
                return hash.ToLower();
            }
        }

        /// <summary>
        ///获取16位md5加密
        /// </summary>
        /// <param name="source">待解密的字符串</param>
        /// <returns></returns>
        public static string To16MD5(this string source)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
                //转换成字符串，并取9到25位
                string sBuilder = BitConverter.ToString(data, 4, 8);
                //BitConverter转换出来的字符串会在每个字符中间产生一个分隔符，需要去除掉
                sBuilder = sBuilder.Replace("-", "");
                return sBuilder.ToString().ToLower();
            }
        }


        /// <summary>
        /// 生成MD5摘要
        /// </summary>
        /// <param name="original">元数据</param>
        /// <returns>MD5摘要</returns>
        public static byte[] ToMD5(this byte[] value) => new MD5CryptoServiceProvider().ComputeHash(value);
        #endregion

        #region 计算输入数据的SHA1哈希值
        /// <summary>
        /// 使用加密服务提供程序(CSP)计算输入数据的SHA1哈希值
        /// </summary>
        /// <param name="value">要加密的字符串</param>
        /// <returns>经过SHA1加密后的字符串</returns>
        public static string ToSHA1(this string value)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] bytes_sha1_in = Encoding.Default.GetBytes(value);
            byte[] bytes_sha1_out = sha1.ComputeHash(bytes_sha1_in);
            return BitConverter.ToString(bytes_sha1_out);
        }
        #endregion

        #region 将使用BitConverter转化的字节数组重新转为字节数组
        /// <summary>
        /// 将使用BitConverter转化的字节数组重新转为字节数组
        /// </summary>
        /// <param name="bitstring">字符串,如:"96-F8-79-F4-18-37-D0-BF-B3-15-BE-A5-77-7F-7D-9E-59"</param>
        /// <returns></returns>
        public static byte[] StringToBit(this string bitstring)
        {
            string[] values = bitstring.Split('-');
            var inBytes = new byte[values.Length];
            for (var i = 0; i < values.Length; i++)
            {
                inBytes[i] = (byte)Convert.ToInt32(values[i], 16);
            }
            return inBytes;
        }
        #endregion

        #region 字符串的DES加密,解密
        /// <summary>
        /// 对字符串进行DES加密
        /// </summary>
        /// <param name="value">字符串</param>
        /// <param name="vKey">密钥</param>
        /// <returns></returns>
        public static string DESEncrypt(this string value, string vKey = "microsoft", string ivVal = "microsoft")
        {
            try
            {
                var des = new DESCryptoServiceProvider()
                {
                    Key = Encoding.ASCII.GetBytes(vKey.To32MD5().Substring(0, 8)),
                    IV = Encoding.ASCII.GetBytes(ivVal.To32MD5().Substring(0, 8))
                };
                var inputByteArray = Encoding.Default.GetBytes(value);
                var desencrypt = des.CreateEncryptor();
                byte[] result = desencrypt.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);
                return BitConverter.ToString(result);
            }
            catch (Exception ex)
            {
                throw new Exception("加密错误", ex);
            }
        }

        /// <summary>
        /// 对加密字符串进行DES解密
        /// </summary>
        /// <param name="value">被加密的字符串</param>
        /// <param name="vKey">密钥</param>
        /// <returns></returns>
        public static string DESDecrypt(this string value, string vKey = "microsoft", string ivVal = "microsoft")
        {
            try
            {
                var des = new DESCryptoServiceProvider()
                {
                    Key = Encoding.ASCII.GetBytes(vKey.To32MD5().Substring(0, 8)),
                    IV = Encoding.ASCII.GetBytes(ivVal.To32MD5().Substring(0, 8))
                };
                string[] values = value.Split('-');
                var inBytes = new byte[values.Length];
                for (var i = 0; i < values.Length; i++)
                {
                    inBytes[i] = (byte)Convert.ToInt32(values[i], 16);
                }
                var desdecrypt = des.CreateDecryptor();
                byte[] outBlock = desdecrypt.TransformFinalBlock(inBytes, 0, inBytes.Length);
                return Encoding.Default.GetString(outBlock);
            }
            catch (Exception ex)
            {
                throw new Exception("密码错误或其他错误", ex);
            }
        }
        #endregion

        #region 随机生成MD5样式的密码,该密码不可逆
        /// <summary>
        /// 超级警告.对字符串进行不可逆DES加密,该加密算法的结果和GUID一样,每一次都不相同.针对制作恶意加密程序可以使用,输出的密码长度为32位MD5码
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string IrreversibleEncrypt(this string value)
        {
            try
            {
                var key = Guid.NewGuid().ToString("N").ToUpper();
                var ivVal = Guid.NewGuid().ToString("N").ToUpper();
                Random rd = new Random();
                var keystart = rd.Next(key.Length - 8);
                var ivstart = rd.Next(ivVal.Length - 8);
                var des = new DESCryptoServiceProvider()
                {
                    Key = Encoding.ASCII.GetBytes(key.Substring(keystart, 8)),
                    IV = Encoding.ASCII.GetBytes(ivVal.Substring(ivstart, 8))
                };
                var inputByteArray = Encoding.Default.GetBytes(value);
                var desencrypt = des.CreateEncryptor();
                byte[] result = desencrypt.TransformFinalBlock(inputByteArray, 0, inputByteArray.Length);
                return BitConverter.ToString(result).To16MD5().ToUpper();
            }
            catch (Exception ex)
            {
                throw new Exception("加密错误", ex);
            }
        }
        #endregion

        #region TripleDES 算法加密解密
        /// <summary>
        /// 使用给定密钥字符串加密String
        /// </summary>
        /// <param name="original">原始文字</param>
        /// <param name="key">密钥,默认:microsoft</param>
        /// <returns>密文</returns>
        public static string TripleDESEncrypt(this string original, string key = "microsoft") =>
            Convert.ToBase64String(TripleDESEncrypt(Encoding.Default.GetBytes(original), Encoding.Default.GetBytes(key)));

        /// <summary>
        /// 使用给定密钥字符串解密string
        /// </summary>
        /// <param name="original">密文</param>
        /// <param name="key">密钥,默认:microsoft</param>
        /// <returns>明文</returns>
        public static string TripleDESDecrypt(this string original, string key = "microsoft") => TripleDESDecrypt(original, Encoding.Default, key);

        /// <summary>
        /// 使用给定密钥字符串解密string,返回指定编码方式明文
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密钥,默认:microsoft</param>
        /// <param name="encoding">字符编码方案</param>
        /// <returns>明文</returns>
        public static string TripleDESDecrypt(this string encrypted, Encoding encoding, string key = "microsoft") =>
            encoding.GetString(TripleDESDecrypt(Convert.FromBase64String(encrypted), Encoding.Default.GetBytes(key)));

        /// <summary>
        /// 使用缺省密钥字符串解密
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密钥,默认:microsoft</param>
        /// <returns>明文</returns>
        public static byte[] TripleDESDecrypt(this byte[] encrypted, string key = "microsoft") =>
            TripleDESDecrypt(encrypted, Encoding.Default.GetBytes(key));

        /// <summary>
        /// 使用缺省密钥字符串加密
        /// </summary>
        /// <param name="original">明文</param>
        /// <param name="key">密匙,默认:microsoft</param>
        /// <returns>密文</returns>
        public static byte[] TripleDESEncrypt(this byte[] original, string key = "microsoft") =>
            TripleDESEncrypt(original, Encoding.Default.GetBytes(key));

        /// <summary>
        /// 使用给定密钥加密
        /// </summary>
        /// <param name="original">明文</param>
        /// <param name="key">密钥</param>
        /// <returns>密文</returns>
        private static byte[] TripleDESEncrypt(byte[] original, byte[] key)
        {
            try
            {
                var des = new TripleDESCryptoServiceProvider
                {
                    Key = key.ToMD5(),
                    Mode = CipherMode.ECB
                };
                return des.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 使用给定密钥解密数据
        /// </summary>
        /// <param name="encrypted">密文</param>
        /// <param name="key">密钥</param>
        /// <returns>明文</returns>
        private static byte[] TripleDESDecrypt(byte[] encrypted, byte[] key)
        {
            try
            {
                var des = new TripleDESCryptoServiceProvider
                {
                    Key = key.ToMD5(),
                    Mode = CipherMode.ECB
                };
                return des.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
