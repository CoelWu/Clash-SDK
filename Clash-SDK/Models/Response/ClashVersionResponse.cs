using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Models.Response
{
    public class ClashVersionResponse
    {
        /// <summary>
        /// 是否是Experimental版本
        /// </summary>
        [JsonProperty("experimental")]
        public bool Experimental { get; set; }

        /// <summary>
        /// 是否是Premium版本
        /// </summary>
        [JsonProperty("premium")]
        public bool Premium { get; set; }

        /// <summary>
        /// Clash版本
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
