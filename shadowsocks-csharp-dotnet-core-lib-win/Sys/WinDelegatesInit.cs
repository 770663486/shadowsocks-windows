using Shadowsocks.Std.Encryption;
using Shadowsocks.Std.Model;
using Shadowsocks.Std.Util;

using static Shadowsocks.Std.Model.DelegateSodium;
using static Shadowsocks.Std.Model.DelegateUtil;
using static Shadowsocks.Std.Win.Encryption.WinSodium;

namespace Shadowsocks.Std.Win.Util.Sys
{
    public class WinDelegatesInit : IDelegatesInit
    {
        public void Init()
        {
            Sodium.sodium_init = new Sodium_init(sodium_init);
            Sodium.crypto_aead_aes256gcm_is_available = new Crypto_aead_aes256gcm_is_available(crypto_aead_aes256gcm_is_available);

            Sodium.sodium_increment = new Sodium_increment(sodium_increment);
            Sodium.crypto_aead_chacha20poly1305_ietf_encrypt = new Crypto_aead_chacha20poly1305_ietf_encrypt(crypto_aead_chacha20poly1305_ietf_encrypt);
            Sodium.crypto_aead_chacha20poly1305_ietf_decrypt = new Crypto_aead_chacha20poly1305_ietf_decrypt(crypto_aead_chacha20poly1305_ietf_decrypt);
            Sodium.crypto_aead_xchacha20poly1305_ietf_encrypt = new Crypto_aead_xchacha20poly1305_ietf_encrypt(crypto_aead_xchacha20poly1305_ietf_encrypt);
            Sodium.crypto_aead_xchacha20poly1305_ietf_decrypt = new Crypto_aead_xchacha20poly1305_ietf_decrypt(crypto_aead_xchacha20poly1305_ietf_decrypt);
            Sodium.crypto_aead_aes256gcm_encrypt = new Crypto_aead_aes256gcm_encrypt(crypto_aead_aes256gcm_encrypt);
            Sodium.crypto_aead_aes256gcm_decrypt = new Crypto_aead_aes256gcm_decrypt(crypto_aead_aes256gcm_decrypt);

            Sodium.crypto_stream_salsa20_xor_ic = new Crypto_stream_salsa20_xor_ic(crypto_stream_salsa20_xor_ic);
            Sodium.crypto_stream_chacha20_xor_ic = new Crypto_stream_chacha20_xor_ic(crypto_stream_chacha20_xor_ic);
            Sodium.crypto_stream_chacha20_ietf_xor_ic = new Crypto_stream_chacha20_ietf_xor_ic(crypto_stream_chacha20_ietf_xor_ic);

            Utils.loadLibrary = new LoadLibrary(WinUtils.LoadLibrary);
            Utils.setProcessWorkingSetSize = new SetProcessWorkingSetSize(WinUtils.SetProcessWorkingSetSize);
        }
    }
}
