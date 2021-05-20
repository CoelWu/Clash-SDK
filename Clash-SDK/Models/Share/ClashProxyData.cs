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
        /// 规则中的所有代理
        /// </summary>
        [JsonProperty("all")]
        public List<string> All { get; set; }

        /// <summary>
        /// 当前使用代理
        /// </summary>
        [JsonProperty("now")]
        public string Now { get; set; }

        /// <summary>
        /// 规则名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// 规则类型
        /// </summary>
        [JsonProperty("type")]
        public ProxyType Type { get; set; }
    }
}
