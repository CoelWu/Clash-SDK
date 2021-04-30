using Clash.SDK;
using Clash.SDK.Models.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClashSDK.ConsoleApp
{
    class Program
    {
        static ClashClient clashClient = new ClashClient(51034);

        static void Main(string[] args)
        {
            Console.WriteLine("Clash-SDK Tester");
            TestClashSDK();
            Console.ReadKey();
        }

        public static async Task TestClashSDK()
        {

            // 打印版本
            Console.WriteLine("------------------Clash Version------------------");
            var version = await clashClient.GetClashVersion();
            Console.WriteLine(version.Version);
            // 打印Proxy Providers
            Console.WriteLine("------------------Clash Proxy Providers ------------------");
            var providers = await clashClient.GetClashProxyProviders();
            foreach (var provider in providers.Providers)
            {
                Console.WriteLine($"Name: {provider.Name} Type: {provider.Type} Vehicle Type: {provider.VehicleType}");
            }
            // 打印代理
            Console.WriteLine("------------------Clash Proxies------------------");
            var proxies = await clashClient.GetClashProxies();
            foreach (var proxy in proxies.Proxies)
            {
                Console.WriteLine($"Name: {proxy.Name} Type: {proxy.Type}");
            }
            // 打印规则
            Console.WriteLine("------------------Clash Rules------------------");
            var rules = await clashClient.GetClashRules();
            foreach (var rule in rules.Rules)
            {
                Console.WriteLine($"Type: {rule.Type} Payload: {rule.PayLoad} Proxy: {rule.Proxy}");
            }
            // 测试WebSocket
            Console.WriteLine("------------------Clash WebSocket------------------");
            clashClient.GetClashConnection();
            clashClient.ConnectionUpdatedEvt += OnConnectionUpdated;
            clashClient.ConnectionUpdatedEvt -= OnConnectionUpdated;
            Console.WriteLine("Done");
            // 测试延迟
            Console.WriteLine("------------------Clash Latency------------------");
            var result = await clashClient.GetClashProxyDelay("DIRECT");
            Console.WriteLine(result.Delay);
            // 测试更改配置
            Console.WriteLine("------------------Clash Config------------------");
            var dict = new Dictionary<string, dynamic>();
            dict.Add("mode", "direct");
            await clashClient.ChangeClashConfigs(dict);
            Console.WriteLine("Done");
            // 测试更改代理
            Console.WriteLine("------------------Clash Change Proxy------------------");
            await clashClient.SwitchClashProxy("GLOBAL", "PROXY");
            Console.WriteLine("Done");
            // 测试切换配置
            Console.WriteLine("------------------Clash Change Config------------------");
            dict = new Dictionary<string, dynamic>();
            dict.Add("allow-lan", true);
            await clashClient.ChangeClashConfigs(dict);
            Console.WriteLine("Done");
            // 测试切换配置文件
            Console.WriteLine("------------------Clash Reload Config File------------------");
            var a = await clashClient.ReloadClashConfig(false, "C:\\Users\\Coel Wu\\.config\\clash\\config.yaml");
            Console.WriteLine("Done");
        }

        public static void OnConnectionUpdated(object sender, ConnectionEvtArgs e)
        {

        }
    }
}
