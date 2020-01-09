namespace Shadowsocks.Std.Model
{
    public interface IGetResources
    {
        public string GetI18NCSV();

        public byte[] GetExec(string name);

        public byte[] GetLib(string name);
    }
}
