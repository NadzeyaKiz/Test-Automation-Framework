using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Core.Enums
{
    public static class EnumUtils
    {
        public static T ParseEnum<T>(string value) where T : IComparable, IFormattable, IConvertible
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}

