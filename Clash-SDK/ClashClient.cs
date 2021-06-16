using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Clash.SDK
{
    public sealed partial class ClashClient : IDisposable
    {
        private static string _baseUrl = string.Empty;
        private static string _baseWsUrl = string.Empty;
        private static string _secret = string.Empty;
        internal HttpClient _httpClient;
        internal HttpClientHandler _httpClientHandler;

        /// <summary>
        /// 初始化ClashClient实例
        /// </summary>
        public ClashClient()
        {
            _baseUrl = "http://127.0.0.1:8080";
            _baseWsUrl = "ws://127.0.0.1:8080";
            _httpClientHandler = new HttpClientHandler
            {
                UseProxy = false,
#if NET5_0_OR_GREATER && NETCOREAPP3_1_OR_GREATER
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli
#else
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
#endif
            };
            _httpClient = new HttpClient(_httpClientHandler);
            _httpClient.Timeout = TimeSpan.FromSeconds(6);
        }

        /// <summary>
        /// 初始化ClashClient实例
        /// </summary>
        /// <param name="port">控制器端口</param>
        public ClashClient(int port)
        {
            _baseUrl = $"http://127.0.0.1:{port}";
            _baseWsUrl = $"ws://127.0.0.1:{port}";
            _httpClientHandler = new HttpClientHandler
            {
                UseProxy = false,
#if NET5_0_OR_GREATER && NETCOREAPP3_1_OR_GREATER
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli
#else
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
#endif
            };
            _httpClient = new HttpClient(_httpClientHandler);
            _httpClient.Timeout = TimeSpan.FromSeconds(6);
        }

        /// <summary>
        /// 初始化ClashClient实例
        /// </summary>
        /// <param name="address">控制器地址</param>
        public ClashClient(string address)
        {
            _baseUrl = $"http://{address}";
            _baseWsUrl = $"ws://{address}";
            _httpClientHandler = new HttpClientHandler
            {
#if NET5_0_OR_GREATER && NETCOREAPP3_1_OR_GREATER
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli
#else
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
#endif
            };
            _httpClient = new HttpClient(_httpClientHandler);
            _httpClient.Timeout = TimeSpan.FromSeconds(6);
        }

        /// <summary>
        /// 初始化ClashClient实例
        /// </summary>
        /// <param name="http">控制器Http地址</param>
        /// <param name="ws">控制器Websocket地址</param>
        public ClashClient(string http, string ws)
        {
            _baseUrl = http;
            _baseWsUrl = ws;
            _httpClientHandler = new HttpClientHandler
            {
#if NET5_0_OR_GREATER && NETCOREAPP3_1_OR_GREATER
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli
#else
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
#endif
            };
            _httpClient = new HttpClient(_httpClientHandler);
            _httpClient.Timeout = TimeSpan.FromSeconds(6);
        }

        /// <summary>
        /// 设置控制器Secret
        /// </summary>
        /// <param name="secret"></param>
        public void SetSecret(string secret)
        {
            if (_httpClient != null && !string.IsNullOrWhiteSpace(secret))
            {
                _secret = secret;
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {secret}");
            }
        }

        public string GetSecret()
        {
            return _secret;
        }

        /// <summary>
        /// 发送GET请求
        /// </summary>
        /// <typeparam name="T">需要转换的目标对象类型</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns></returns>
        internal async Task<T> GetAsync<T>(string url, Dictionary<string, dynamic> parameters = null)
        {
            string query = "";
            if (parameters != null && parameters.Count > 0)
            {
                query = "?" + string.Join("&", parameters.Select(p => p.Key + "=" + Uri.EscapeDataString(p.Value)));
                url += query;
            }
            var response = await _httpClient.GetAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            if (typeof(T) == typeof(String))
            {
                return (T)(object)result;
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        /// <summary>
        /// 发送PATCH请求
        /// </summary>
        /// <typeparam name="T">需要转换的目标对象类型</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="patchData">需要PATCH提交的数据</param>
        /// <returns></returns>
        internal async Task<T> PatchAsync<T>(string url, object patchData = null)
        {
            string json = JsonConvert.SerializeObject(patchData);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.SendAsync(new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(url),
                Content = httpContent
            });
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }

        /// <summary>
        /// 发送PUT请求
        /// </summary>
        /// <typeparam name="T">需要转换的目标对象类型</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <param name="putData">需要PUT提交的数据</param>
        /// <returns></returns>
        internal async Task<T> PutAsync<T>(string url, Dictionary<string, dynamic> parameters = null, object putData = null)
        {
            string query = "";
            if (parameters != null && parameters.Count > 0)
            {
                query = "?" + string.Join("&", parameters.Select(p => p.Key + "=" + Uri.EscapeDataString(p.Value)));
                url += query;
            }
            string json = JsonConvert.SerializeObject(putData);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, httpContent);
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }

        /// <summary>
        /// 发送DELETE请求
        /// </summary>
        /// <typeparam name="T">需要转换的目标对象类型</typeparam>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        internal async Task<T> DeleteAsync<T>(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }

        /// <summary>
        /// 释放ClashClient实例
        /// </summary>
        public void Dispose()
        {
            _httpClient.Dispose();
            _httpClientHandler.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
