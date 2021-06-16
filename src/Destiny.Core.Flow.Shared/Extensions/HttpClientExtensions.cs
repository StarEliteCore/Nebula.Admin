using DestinyCore.AspNetCore;
using DestinyCore.Exceptions;
using DestinyCore.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Shared.Extensions
{
    public static class HttpClientExtensions
    {

        /// <summary>
        /// 使用post方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="json">发送的参数字符串，只能用json</param>
        /// <returns>返回的字符串</returns>
        public static async Task<string> PostAsyncJson(this HttpClient client, string url, string json)
        {
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            using HttpResponseMessage response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }




        /// <summary>
        /// 组装QueryString的方法
        /// 参数之间用&连接，首位没有符号，如：a=1&b=2&c=3
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        public static string GetQueryString(this Dictionary<string, object> formData)
        {
            if (formData == null || formData.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();

            var i = 0;
            foreach (var kv in formData)
            {
                i++;
                sb.AppendFormat("{0}={1}", kv.Key, kv.Value);
                if (i < formData.Count)
                {
                    sb.Append("&");
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 使用post方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="data">发送的参数</param>
        /// <returns>返回的字符串</returns>
        public static async Task<string> PostAsStringAsync(this HttpClient client, string url, Dictionary<string, object> data, Dictionary<string, string> header = null)
        {

            using var relust = await client.PostAsync(url, data, header);
            return await relust.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 使用post方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="data">发送的参数</param>
        /// <returns>返回的字符串</returns>
        public static async Task<HttpResponseMessage> PostAsync(this HttpClient client, string url, Dictionary<string, object> data, Dictionary<string, string> header = null)
        {

            HttpContent content = new StringContent(data.ToJson());
            if (header != null)
            {
                client.DefaultRequestHeaders.Clear();
                foreach (var item in header)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }
            using HttpResponseMessage response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return response;
        }

        /// <summary>
        /// 使用post返回异步请求直接返回对象
        /// </summary>
        /// <typeparam name="T">返回对象类型</typeparam>
        /// <typeparam name="T2">请求对象类型</typeparam>
        /// <param name="url">请求链接</param>
        /// <param name="obj">请求对象数据</param>
        /// <returns>请求返回的目标对象</returns>
        public static async Task<T> PostObjectAsync<T, T2>(this HttpClient client, string url, T2 obj)
        {
            string json = obj.ToJson();
            string responseBody = await client.PostAsyncJson(url, json);
            return responseBody.FromJson<T>();
        }

        /// <summary>
        /// 使用post返回异步请求直接返回对象
        /// </summary>
        /// <typeparam name="T2">请求对象类型</typeparam>
        /// <param name="url">请求链接</param>
        /// <param name="obj">请求对象数据</param>
        /// <returns>请求返回的目标对象</returns>
        public static async Task<AjaxResult> PostObjectAsync<T2>(this HttpClient client, string url, T2 obj)
        {
            return await client.PostObjectAsync<T2>(url, obj);
        }

        /// <summary>
        /// 使用post返回异步请求直接返回对象
        /// </summary>
        /// <typeparam name="T">返回对象类型</typeparam>
        /// <param name="url">请求链接</param>
        /// <param name="dics">请求对象数据</param>
        /// <returns>请求返回的目标对象</returns>
        public static async Task<T> PostObjectAsync<T>(this HttpClient client, string url, Dictionary<string, object> dics)
        {
            MessageBox.ShowIf("请求参数不能为空", dics?.Count <= 0);
            return await client.PostObjectAsync<T, Dictionary<string, object>>(url, dics);
        }

        /// <summary>
        /// 使用post返回异步请求直接返回对象
        /// </summary>
        /// <typeparam name="T">返回对象类型</typeparam>
        /// <param name="url">请求链接</param>
        /// <param name="dics">请求对象数据</param>
        /// <returns>请求返回的目标对象</returns>
        public static async Task<AjaxResult> PostObjectAsync(this HttpClient client, string url, Dictionary<string, object> dics)
        {
            return await client.PostObjectAsync<AjaxResult, Dictionary<string, object>>(url, dics);
        }


        /// <summary>
        /// 使用post返回异步请求直接返回对象
        /// </summary>
        /// <typeparam name="T">返回对象类型</typeparam>
        /// <typeparam name="T2">请求对象类型</typeparam>
        /// <param name="url">请求链接</param>
        /// <param name="obj">请求对象数据</param>
        /// <returns>请求返回的目标对象</returns>
        public static async Task<T> DeleteObjectAsync<T>(this HttpClient client, string url, Dictionary<string, object> dics)
        {
            MessageBox.ShowIf("请求参数不能为空", dics?.Count <= 0);
            string responseBody = await client.DeleteAsyncJson(url, dics);
            return responseBody.FromJson<T>();
        }



        /// <summary>
        /// 使用delete返回异步请求直接返回对象
        /// </summary>
        /// <typeparam name="T">返回对象类型</typeparam>
        /// <param name="url">请求链接</param>
        /// <param name="dics">请求对象数据</param>
        /// <returns>请求返回的目标对象</returns>
        public static async Task<AjaxResult> DeleteObjectAsync(this HttpClient client, string url, Dictionary<string, object> dics)
        {
            return await client.DeleteObjectAsync<AjaxResult>(url, dics);
        }

        /// <summary>
        /// 使用delete方法异步请求
        /// </summary>
        /// <param name="url">目标链接</param>
        /// <param name="dics">请求参数</param>
        /// <returns>返回的字符串</returns>
        public static async Task<string> DeleteAsyncJson(this HttpClient client, string url, Dictionary<string, object> dics)
        {

            using HttpResponseMessage response = await client.DeleteAsync($"{url}?{dics.GetQueryString()}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        /// <summary>
        /// 转换对象
        /// </summary>
        /// <typeparam name="T">返回对象类型</typeparam>
        /// <param name="ajaxResult">ajaxresutl对象</param>
        /// <returns></returns>
        public static T ToData<T>(this AjaxResult ajaxResult)
        {

            return ajaxResult.Data.ToString().FromJson<T>();
        }
    }
}
