using Shadowsocks.Std.Sys;

namespace Shadowsocks.Std.Model
{
    public class ShadowsocksContext
    {
        public string[] runArgs;

        public IAutoStartup autoStartup;


        public IDelegatesInit delegatesInit;

        public ShadowsocksContext(string[] runArgs, IAutoStartup autoStartup, IDelegatesInit delegatesInit)
        {
            this.runArgs = runArgs;
            this.autoStartup = autoStartup;
            this.delegatesInit = delegatesInit;

            this.delegatesInit.Init();
        }
    }
}
