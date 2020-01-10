﻿using NLog;
using Shadowsocks.Std.Util;

namespace Shadowsocks.Std.Sys
{
    public interface ISysproxy
    {
        enum RET_ERRORS : int
        {
            RET_NO_ERROR = 0,
            INVALID_FORMAT = 1,
            NO_PERMISSION = 2,
            SYSCALL_FAILED = 3,
            NO_MEMORY = 4,
            INVAILD_OPTION_COUNT = 5,
        };

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private const string _userWininetJson = "user-wininet.json";

        private readonly static string[] _lanIP = {
            "<local>",
            "localhost",
            "127.*",
            "10.*",
            "172.16.*",
            "172.17.*",
            "172.18.*",
            "172.19.*",
            "172.20.*",
            "172.21.*",
            "172.22.*",
            "172.23.*",
            "172.24.*",
            "172.25.*",
            "172.26.*",
            "172.27.*",
            "172.28.*",
            "172.29.*",
            "172.30.*",
            "172.31.*",
            "192.168.*"
        };

        static ISysproxy()
        {
            Utils.GetAndUncompressExec(Utils.sysproxy);
        }



    }
}
