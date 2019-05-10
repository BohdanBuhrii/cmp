using System;
using System.Collections.Generic;
using System.Text;

namespace Helper
{
    public static class StringHelper
    {
        public static string[] Split(string str, char separator)
        {
            while (str.IndexOf(separator.ToString()+ separator.ToString()) > 0)
            {
                str = str.Replace(separator.ToString() + separator.ToString(), separator.ToString());
            }
            return str.Split(separator);
        }
    }
}
