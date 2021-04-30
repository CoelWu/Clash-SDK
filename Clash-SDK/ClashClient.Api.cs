using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK
{
    public sealed partial class ClashClient
    {
        private string API_TRAFFIC
        {
            get => _baseWsUrl + "/traffic";
        }

        private string API_LOGS
        {
            get => _baseWsUrl + "/logs";
        }

        private string API_CONNECTIONS_WS
        {
            get => _baseWsUrl + "/connections";
        }

        private string API_STATUS
        {
            get => _baseUrl;
        }

        private string API_VERSION
        {
            get => _baseUrl + "/version";
        }

        private string API_PROXY_PROVIDERS
        {
            get => _baseUrl + "/providers/proxies";
        }

        private string API_PROXY_PROVIDER_NAME
        {
            get => _baseUrl + "/providers/proxies" + "/{0}";
        }

        private string API_PROXY_PROVIDER_HEALTHCHECK
        {
            get => _baseUrl + "/providers/proxies" + "/{0}" + "/healthcheck";
        }

        private string API_RULE_PROVIDERS
        {
            get => _baseUrl + "/rules";
        }

        private string API_RULE_PROVIDER_NAME
        {
            get => _baseUrl + "/rules" + "/{0}";
        }

        private string API_PROXIES
        {
            get => _baseUrl + "/proxies";
        }

        private string API_PROXIES_NAME
        {
            get => _baseUrl + "/proxies" + "/{0}";
        }

        private string API_PROXIES_DELAY
        {
            get => _baseUrl + "/proxies" + "/{0}" + "/delay";
        }

        private string API_CONNECTIONS
        {
            get => _baseUrl + "/connections";
        }

        private string API_CONNECTIONS_UUID
        {
            get => _baseUrl + "/connections" + "/{0}";
        }

        private string API_CONFIGS
        {
            get => _baseUrl + "/configs";
        }

        private string API_RULES
        {
            get => _baseUrl + "/rules";
        }
    }
}
