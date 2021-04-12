﻿using Clash.SDK.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Extensions
{
    public static class ProxyTypeExtension
    {
        public static bool IsUnUsedProxy(this ProxyType Type)
        {
            switch (Type)
            {
                case ProxyType.Direct:
                case ProxyType.Reject:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsPolicyGroup(this ProxyType Type)
        {
            switch (Type)
            {
                case ProxyType.Selector:
                case ProxyType.URLTest:
                case ProxyType.LoadBalance:
                case ProxyType.FallBack:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsPolicyGroupSelectable(this ProxyType Type)
        {
            switch (Type)
            {
                case ProxyType.Selector:
                    return true;
                default:
                    return false;
            }
        }
    }
}
