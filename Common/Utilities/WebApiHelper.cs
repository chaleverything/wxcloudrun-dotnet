using Newtonsoft.Json;
using System.Text;

namespace Common.Utilities
{
    public class WebApiHelper
    {
        /// <summary>
        /// client
        /// </summary>
        private static HttpClient client = new HttpClient();

        /// <summary>
        /// 获取HttpClient
        /// </summary>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        private static HttpClient GetClient(HttpClient? httpClient = null)
        {
            return httpClient ?? client;
        }

        /// <summary>
        /// Get请求(返回string，自行解析)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static string GetAsyncStr(string url, HttpClient? httpClient = null)
        {
            return GetClient(httpClient).GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static T? GetAsync<T>(string url, HttpClient? httpClient = null)
        {
            var strRes = GetAsyncStr(url, httpClient);
            return JsonConvert.DeserializeObject<T>(strRes);
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static string PostAsyncStr(string url, object data, Encoding? encoding = null, HttpClient? httpClient = null)
        {
            string body = (data is string) ? (string)data : JsonConvert.SerializeObject(data);
            var res = GetClient(httpClient).PostAsync(url, new StringContent(body, encoding)).Result.Content.ReadAsStringAsync().Result;
            return res;
        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static T? PostAsync<T>(string url, object data, HttpClient httpClient = null)
        {
            var strRes = PostAsyncStr(url, data, httpClient: httpClient);
            return JsonConvert.DeserializeObject<T>(strRes);
        }

        /// <summary>
        /// Post请求HttpContent
        /// </summary>
        /// <param name="url"></param>
        /// <param name="httpContent"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static string PostHttpContentStr(string url, HttpContent httpContent, HttpClient? httpClient = null)
        {
            var res = GetClient(httpClient).PostAsync(url, httpContent).Result.Content.ReadAsStringAsync().Result;
            return res;
        }

        /// <summary>
        /// Post请求HttpContent
        /// </summary>
        /// <param name="url"></param>
        /// <param name="httpContent"></param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public static T? PostHttpContent<T>(string url, HttpContent httpContent, HttpClient? httpClient = null)
        {
            var strRes = PostHttpContentStr(url, httpContent, httpClient);
            return JsonConvert.DeserializeObject<T>(strRes);
        }

    }
}
