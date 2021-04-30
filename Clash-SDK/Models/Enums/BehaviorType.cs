using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Clash.SDK.Models.Enums
{
    public enum BehaviorType
    {
        [EnumMember(Value = "Domain")]
        Domain,

        [EnumMember(Value = "IPCIDR")]
        IPCIDR,

        [EnumMember(Value = "Classical")]
        Classical
    }
}
