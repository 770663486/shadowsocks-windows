namespace Shadowsocks.Std.Sys
{
    public interface IGetResources
    {
        public string GetI18NCSV();

        public byte[] GetLib(string name);

        public byte[] GetExec(string name);

    }
}
