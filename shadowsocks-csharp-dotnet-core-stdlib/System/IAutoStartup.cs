namespace Shadowsocks.Std.Os
{
    public interface IAutoStartup
    {

        public bool Set(bool enabled);

        public bool Check();

    }
}
