using Clash.SDK.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clash.SDK.Models.Share
{
    public class ClashRuleProviderData
    {
        /// <summary>
        /// Provider名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Provider类型
        /// </summary>
        [JsonProperty("type")]
        public ProviderType Type { get; set; }

        /// <summary>
        /// 规则类型
        /// </summary>
        [JsonProperty("behavior")]
        public BehaviorType BehaviorType { get; set; }

        /// <summary>
        /// 规则数量
        /// </summary>
        [JsonProperty("ruleCount")]
        public long RuleCount { get; set; }

        /// <summary>
        /// Provider更新时间
        /// </summary>
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Provider承载类型
        /// </summary>
        [JsonProperty("vehicleType")]
        public VehicleType VehicleType { get; set; }
    }
}
