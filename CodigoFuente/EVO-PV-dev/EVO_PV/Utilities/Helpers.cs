
using EVO_PV.Enums;
using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace EVO_PV.Utilities
{
    public static class Helpers
    {
        public static bool ValidateRegex(string text, EnumRegexs enumRegexs)
        {
            string regex = string.Empty;

            switch (enumRegexs)
            {
                case EnumRegexs.ONLY_NUMBERS:

                    regex = ConfigurationManager.AppSettings[enumRegexs.ToString()].ToString();

                    break;
                case EnumRegexs.ONLY_NUMBERT_WITH_DECIMALS:

                    string minimumDecimal = ConfigurationManager.AppSettings[EnumRegexs.MINIMUM_DECIMAL.ToString()].ToString();

                    string maximumDecimal = ConfigurationManager.AppSettings[EnumRegexs.MAXIMUM_DECIMAL.ToString()].ToString();

                    regex = ConfigurationManager.AppSettings[enumRegexs.ToString()].ToString();

                    regex = regex.Replace("#", minimumDecimal).Replace("@", maximumDecimal).Replace("\\", @"\");

                    break;
            }

            Match regIPMatch = Regex.Match(text, regex);

            return regIPMatch.Success;
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("¡No hay adaptadores de red con una dirección IPv4 en el sistema!");
        }
    }
}
