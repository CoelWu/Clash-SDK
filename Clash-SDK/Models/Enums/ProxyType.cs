using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Clash.SDK.Models.Enums
{
    public enum ProxyType
    {
        [EnumMember(Value = "Selector")]
        Selector,

        [EnumMember(Value = "Relay")]
        Relay,

        [EnumMember(Value = "URLTest")]
        URLTest,

        [EnumMember(Value = "LoadBalance")]
        LoadBalance,

        [EnumMember(Value = "Fallback")]
        FallBack,

        [EnumMember(Value = "Direct")]
        Direct,

        [EnumMember(Value = "Reject")]
        Reject,

        [EnumMember(Value = "Socks5")]
        Socks5,

        [EnumMember(Value = "Http")]
        Http,

        [EnumMember(Value = "Shadowsocks")]
        Shadowsocks,

        [EnumMember(Value = "ShadowsocksR")]
        ShadowsocksR,

        [EnumMember(Value = "Vmess")]
        Vmess,

        [EnumMember(Value = "Vless")]
        Vless,

        [EnumMember(Value = "Trojan")]
        Trojan,

        [EnumMember(Value = "Snell")]
        Snell
    }
}
