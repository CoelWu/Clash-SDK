using Clash.SDK.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Share
{
    public class ClashProxyProviderData
    {
        /// <summary>
        /// Provider名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Provider代理
        /// </summary>
        [JsonProperty("proxies")]
        public List<ClashProxyData> Proxies { get; set; }

        /// <summary>
        /// Provider类型
        /// </summary>
        [JsonProperty("type")]
        public ProviderType Type { get; set; }

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
