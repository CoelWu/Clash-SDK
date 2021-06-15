using Clash.SDK.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Clash.SDK.Models.Share
{
    public class ClashProxyData
    {
        /// <summary>
        /// 历史延迟
        /// </summary>
        [JsonProperty("history")]
        public List<ClashDelayData> History { get; set; }

        /// <summary>
        /// 代理组中的所有代理
        /// </summary>
        [JsonProperty("all")]
        public List<string> All { get; set; }

        /// <summary>
        /// 当前使用代理
        /// </summary>
        [JsonProperty("now")]
        public string Now { get; set; }

        /// <summary>
        /// 代理名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 代理类型
        /// </summary>
        [JsonProperty("type")]
        public ProxyType Type { get; set; }

        /// <summary>
        /// 是否支持UDP
        /// </summary>
        [JsonProperty("udp")]
        public bool Udp { get; set; }
    }
}
