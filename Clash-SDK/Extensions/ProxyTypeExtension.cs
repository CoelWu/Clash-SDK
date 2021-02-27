﻿using Clash.SDK.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clash.SDK.Extensions
{
    public static class ProxyTypeExtension
    {
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
    }
}