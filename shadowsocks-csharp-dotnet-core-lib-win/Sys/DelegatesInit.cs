using Shadowsocks.Std.Encryption;
using Shadowsocks.Std.Model;
using Shadowsocks.Std.Util;
using static Shadowsocks.Std.Encryption.DelegateOpenSSL;
using static Shadowsocks.Std.Encryption.DelegateSodium;
using static Shadowsocks.Std.Util.DelegateUtil;
using static Shadowsocks.Std.Win.Encryption.Sodium;
using static Shadowsocks.Std.Win.Encryption.OpenSSL;

namespace Shadowsocks.Std.Win.Util.Sys
{
    public class DelegatesInit : IDelegatesInit
    {
        public void Init()
        {
            #region Encryption

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

            OpenSSL.EVP_CIPHER_CTX_new = new EVP_CIPHER_CTX_new(EVP_CIPHER_CTX_new);
            OpenSSL.EVP_CIPHER_CTX_free = new EVP_CIPHER_CTX_free(EVP_CIPHER_CTX_free);
            OpenSSL.EVP_CIPHER_CTX_reset = new EVP_CIPHER_CTX_reset(EVP_CIPHER_CTX_reset);
            OpenSSL.EVP_CipherInit_ex = new EVP_CipherInit_ex(EVP_CipherInit_ex);
            OpenSSL.EVP_CipherUpdate = new EVP_CipherUpdate(EVP_CipherUpdate);
            OpenSSL.EVP_CipherFinal_ex = new EVP_CipherFinal_ex(EVP_CipherFinal_ex);
            OpenSSL.EVP_CIPHER_CTX_set_padding = new EVP_CIPHER_CTX_set_padding(EVP_CIPHER_CTX_set_padding);
            OpenSSL.EVP_CIPHER_CTX_set_key_length = new EVP_CIPHER_CTX_set_key_length(EVP_CIPHER_CTX_set_key_length);
            OpenSSL.EVP_CIPHER_CTX_ctrl = new EVP_CIPHER_CTX_ctrl(EVP_CIPHER_CTX_ctrl);
            OpenSSL.EVP_get_cipherbyname = new EVP_get_cipherbyname(EVP_get_cipherbyname);

            #endregion

            Utils.loadLibrary = new LoadLibrary(WinUtils.LoadLibrary);
            Utils.setProcessWorkingSetSize = new SetProcessWorkingSetSize(WinUtils.SetProcessWorkingSetSize);
        }
    }
}
