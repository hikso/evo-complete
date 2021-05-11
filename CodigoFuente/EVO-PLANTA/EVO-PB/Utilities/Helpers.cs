
using EVO_PB.Enums;
using System.Configuration;
using System.Net;
using System.Text.RegularExpressions;

namespace EVO_PB.Utilities
{
    public static class Helpers
    {
        public static bool ValidateRegex(string text,EnumRegexs enumRegexs)
        {
            string regex = string.Empty;

            switch (enumRegexs)
            {
                case EnumRegexs.ONLY_NUMBERS:

                    regex = ConfigurationManager.AppSettings[enumRegexs.ToString()].ToString();

                    break;
                case EnumRegexs.ONLY_NUMBERT_WITH_DECIMALS:

                    string minimumDecimal= ConfigurationManager.AppSettings[EnumRegexs.MINIMUM_DECIMAL.ToString()].ToString();

                    string maximumDecimal = ConfigurationManager.AppSettings[EnumRegexs.MAXIMUM_DECIMAL.ToString()].ToString();                   

                    regex = ConfigurationManager.AppSettings[enumRegexs.ToString()].ToString();

                    regex= regex.Replace("#", minimumDecimal).Replace("@", maximumDecimal).Replace("\\",@"\");

                    break;              
            }         

            Match regIPMatch = Regex.Match(text, regex);

            return regIPMatch.Success;           
        }
    }
}
