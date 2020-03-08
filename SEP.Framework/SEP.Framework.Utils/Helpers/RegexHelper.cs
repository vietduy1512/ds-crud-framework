using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SEP.Framework.Utils.Helpers
{
    public class RegexHelper
    {
        private static RegexHelper _instance;
        protected RegexHelper()
        {
        }
    
        public static RegexHelper Instance()
        {
            if (_instance == null)
            {
                _instance = new RegexHelper();
            }
            return _instance;
        }

        public static string CreateSlug(string title)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string result = title.Normalize(NormalizationForm.FormD);

            result = regex.Replace(result, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            result = Regex.Replace(Regex.Replace(Regex.Replace(result, @"\s+", "_"), @"\W", ""), "_+", "-");

            return result;
        }
    }
}