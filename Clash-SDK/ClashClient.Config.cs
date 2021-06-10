using Clash.SDK.Extensions;
using Clash.SDK.Models.Enums;
using Clash.SDK.Models.Response;
using Clash.SDK.Models.Share;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Clash.SDK
{
    public sealed partial class ClashClient
    {
        public async Task<bool> GetClashStatus()
        {
            try
            {
                _ = await GetAsync<ClashStatusResponse>(API_STATUS);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ClashVersionResponse> GetClashVersion()
        {
            var result = await GetAsync<ClashVersionResponse>(API_VERSION);
            return result;
        }

        public async Task<ClashConfigsResponse> GetClashConfigs()
        {
            var result = await GetAsync<ClashConfigsResponse>(API_CONFIGS);
            return result;
        }

        public async Task<ClashNullableResponse> ChangeClashConfigs(Dictionary<string, dynamic> dict)
        {
            var result = await PatchAsync<ClashNullableResponse>(API_CONFIGS, dict);
            return result;
        }

        public async Task<ClashNullableResponse> ReloadClashConfig(ConfigType type = ConfigType.Path, bool force = false, string value = "")
        {
            var dict = new Dictionary<string, dynamic>();
            dict.Add("force", force.ToLowerString());

            object obj = new object{};
            if (type == ConfigType.Path)
            {
                obj = new
                { 
                    path = value,
                };
            }
            else if (type == ConfigType.Payload)
            {
                obj = new
                {
                    payload = value,
                };
            }

            var result = await PutAsync<ClashNullableResponse>(API_CONFIGS, dict, string.IsNullOrWhiteSpace(value) ? null : obj);
            return result;
        }

        public async Task<ClashRulesResponse> GetClashRules()
        {
            var result = await GetAsync<ClashRulesResponse>(API_RULES);
            return result;
        }

        public async Task<ClashRuleProvidersResponse> GetClashRuleProviders()
        {
            ClashRuleProvidersResponse result = new ClashRuleProvidersResponse
            {
                Providers = new List<ClashRuleProviderData>()
            };
            string data = await GetAsync<string>(API_RULE_PROVIDERS);
            var obj = JObject.Parse(data);
            foreach (JProperty provider in obj["providers"])
            {
                result.Providers.Add(provider.Value.ToObject<ClashRuleProviderData>());
            }
            return result;
        }

        public async Task<ClashRuleProviderData> GetClashRuleProvider(string name)
        {
            string url = string.Format(API_RULE_PROVIDER_NAME, Uri.EscapeDataString(name));

            var result = await PutAsync<ClashRuleProviderData>(url);
            return result;
        }

        public async Task<ClashNullableResponse> UpdateClashRuleProvider(string name)
        {
            string url = string.Format(API_RULE_PROVIDER_NAME, Uri.EscapeDataString(name));

            var result = await PutAsync<ClashNullableResponse>(url);
            return result;
        }
    }
}
