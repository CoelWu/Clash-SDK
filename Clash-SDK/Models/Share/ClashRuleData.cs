using Clash.SDK.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Share
{
    public class ClashRuleData
    {
        /// <summary>
        /// 规则类型
        /// </summary>
        [JsonProperty("type")]
        public RuleType Type { get; set; }

        /// <summary>
        /// 规则内容
        /// </summary>
        [JsonProperty("payload")]
        public string PayLoad { get; set; }

        /// <summary>
        /// 连接方式
        /// </summary>
        [JsonProperty("proxy")]
        public string Proxy { get; set; }
    }
}
