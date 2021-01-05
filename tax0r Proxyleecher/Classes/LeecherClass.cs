using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace tax0r_Proxyleecher.Classes
{
    class LeecherClass
    {
        private string GetContent(string source)
        {
            WebClient webClient = new WebClient();
            try
            {
                return webClient.DownloadString(source);
            }
            catch
            {
                return "";
            }
            finally
            {
                webClient.Dispose();
            }
        }

        public string[] GetProxies(string source)
        {
            Regex regex = new Regex(@"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b:\d{2,5}", RegexOptions.Multiline);
            MatchCollection matches = regex.Matches(GetContent(source));

            List<string> proxies = new List<string>();

            foreach (Match match in matches)
            {
                proxies.Add(match.ToString());
            }
            return proxies.ToArray();
        }
    }
}
