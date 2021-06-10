using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clash.SDK.Extensions
{
    public static class BooleanExtension
    {
        public static string ToLowerString(this bool value)
        {
            return value ? "true" : "false";
        }

        public static string ToLowerString(this bool? value)
        {
            return ToLowerString((bool)value);
        }
    }
}
