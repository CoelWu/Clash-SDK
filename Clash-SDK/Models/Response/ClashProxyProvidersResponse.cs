using Clash.SDK.Models.Enums;
using Clash.SDK.Models.Share;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Response
{
    public class ClashProxyProvidersResponse
    {
        /// <summary>
        /// 所有Providers代理
        /// </summary>
        [JsonProperty("providers")]
        public List<ClashProxyProviderData> Providers { get; set; }
    }
}
