using System;

using Shadowsocks.DotnetCore.GUI.WF.Properties;
using Shadowsocks.Std.Model;
using Shadowsocks.Std.Util;

namespace Shadowsocks.DotnetCore.GUI.WF.Util
{
    internal class GetResource : AbstractGetResources
    {
        public byte[] GetExec(string name)
        {
            throw new NotImplementedException();
        }

        public string GetI18NCSV() => Resources.i18n_csv;

        #region

        public byte[] GetAndUncompressLib(string unPath, string name)
        {

            FileManager.UncompressFile(unPath, name);

            throw new NotImplementedException();
        }
    }
}
