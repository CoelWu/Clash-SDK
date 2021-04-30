using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Clash.SDK.Models.Enums
{
    public enum ModeType
    {
        [EnumMember(Value = "direct")]
        Direct,

        [EnumMember(Value = "rule")]
        Rule,

        [EnumMember(Value = "global")]
        Global,

        [EnumMember(Value = "script")]
        Script
    }
}
