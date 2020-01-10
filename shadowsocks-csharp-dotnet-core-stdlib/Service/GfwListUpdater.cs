using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

using Newtonsoft.Json;

using NLog;

using Shadowsocks.Std.Model;
using Shadowsocks.Std.Util;
using Shadowsocks.Std.Util.Resource;

namespace Shadowsocks.Std.Service
{
    public class GFWListUpdater
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private const string GFWLIST_URL = "https://raw.githubusercontent.com/gfwlist/gfwlist/master/gfwlist.txt";

        public event EventHandler<ResultEventArgs> UpdateCompleted;

        public event ErrorEventHandler Error;

        public class ResultEventArgs : EventArgs
        {
            public bool Success;

            public ResultEventArgs(bool success)
            {
                this.Success = success;
            }
        }

        private static readonly IEnumerable<char> IgnoredLineBegins = new[] { '!', '[' };
        private void Http_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                File.WriteAllText(Utils.GetTempPath("gfwlist.txt"), e.Result, Encoding.UTF8);
                bool pacFileChanged = MergeAndWritePACFile(e.Result);
                UpdateCompleted?.Invoke(this, new ResultEventArgs(pacFileChanged));
            }
            catch (Exception ex)
            {
                Error?.Invoke(this, new ErrorEventArgs(ex));
            }
        }

        public static bool MergeAndWritePACFile(string gfwListResult)
        {
            string abpContent = MergePACFile(gfwListResult);
            if (File.Exists(PACDaemon.PAC_FILE))
            {
                string original = FileManager.NonExclusiveReadAllText(PACDaemon.PAC_FILE, Encoding.UTF8);
                if (original == abpContent)
                {
                    return false;
                }
            }
            File.WriteAllText(PACDaemon.PAC_FILE, abpContent, Encoding.UTF8);
            return true;
        }

        private static string MergePACFile(string gfwListResult)
        {
            string abpContent;
            if (File.Exists(PACDaemon.USER_ABP_FILE))
            {
                abpContent = FileManager.NonExclusiveReadAllText(PACDaemon.USER_ABP_FILE, Encoding.UTF8);
            }
            else
            {
                abpContent = Resources.abp_js;
            }

            List<string> userruleLines = new List<string>();
            if (File.Exists(PACDaemon.USER_RULE_FILE))
            {
                string userrulesString = FileManager.NonExclusiveReadAllText(PACDaemon.USER_RULE_FILE, Encoding.UTF8);
                userruleLines = ParseToValidList(userrulesString);
            }

            var gfwLines = ParseBase64ToValidList(gfwListResult);
            abpContent =
$@"var __USERRULES__ = {JsonConvert.SerializeObject(userruleLines, Formatting.Indented)};
var __RULES__ = {JsonConvert.SerializeObject(gfwLines, Formatting.Indented)};
{abpContent}";
            return abpContent;
        }

        public void UpdatePACFromGFWList(Configuration config)
        {
            string gfwListUrl = GFWLIST_URL;
            if (!config.gfwListUrl.IsNullOrWhiteSpace())
            {
                _logger.Info("Found custom GFWListURL in config file");
                gfwListUrl = config.gfwListUrl;
            }
            _logger.Info($"Checking GFWList from {gfwListUrl}");
            WebClient http = new WebClient();
            if (config.enabled)
            {
                http.Proxy = new WebProxy(
                    config.isIPv6Enabled
                    ? $"[{IPAddress.IPv6Loopback.ToString()}]"
                    : IPAddress.Loopback.ToString(),
                    config.localPort);
            }
            http.DownloadStringCompleted += Http_DownloadStringCompleted;
            http.DownloadStringAsync(new Uri(gfwListUrl));
        }

        public static List<string> ParseBase64ToValidList(string response)
        {
            byte[] bytes = Convert.FromBase64String(response);
            string content = Encoding.ASCII.GetString(bytes);
            return ParseToValidList(content);
        }

        private static List<string> ParseToValidList(string content)
        {
            List<string> valid_lines = new List<string>();
            using (var sr = new StringReader(content))
            {
                foreach (var line in sr.NonWhiteSpaceLines())
                {
                    if (line.BeginWithAny(IgnoredLineBegins))
                        continue;
                    valid_lines.Add(line);
                }
            }
            return valid_lines;
        }
    }
}
