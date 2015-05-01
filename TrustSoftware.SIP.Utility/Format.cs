using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SilvanoFontes.AL.Utility
{
    public static class Functions
    {
        public static string ToJson(IList list)
        {
            string result = "";
            
            for (int i = 0; i < list.Count; i++)
            {
                result += list[i].ToString() + ",";
            }

            result = "{  \"aaData\": [" + result.Substring(0, result.Count() - 1) + "]}";
            return result;
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        
    }
}
