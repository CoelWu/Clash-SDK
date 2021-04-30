using Clash.SDK.Models.Share;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clash.SDK.Models.Response
{
    public class ClashRuleProvidersResponse
    {
        /// <summary>
        /// 所有Providers规则
        /// </summary>
        [JsonProperty("providers")]
        public List<ClashRuleProviderData> Providers { get; set; }
    }
}
