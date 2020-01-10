using System;

namespace Shadowsocks.Std
{
    namespace Encryption
    {
        public static class DelegateSodium
        {
            public delegate int Sodium_init();

            public delegate int Crypto_aead_aes256gcm_is_available();

            #region AEAD

            public delegate int Sodium_increment(byte[] n, int nlen);

            public delegate int Crypto_aead_chacha20poly1305_ietf_encrypt(byte[] c, ref ulong clen_p, byte[] m, ulong mlen, byte[] ad, ulong adlen, byte[] nsec, byte[] npub, byte[] k);

            public delegate int Crypto_aead_chacha20poly1305_ietf_decrypt(byte[] m, ref ulong mlen_p, byte[] nsec, byte[] c, ulong clen, byte[] ad, ulong adlen, byte[] npub, byte[] k);

            public delegate int Crypto_aead_xchacha20poly1305_ietf_encrypt(byte[] c, ref ulong clen_p, byte[] m, ulong mlen, byte[] ad, ulong adlen, byte[] nsec, byte[] npub, byte[] k);

            public delegate int Crypto_aead_xchacha20poly1305_ietf_decrypt(byte[] m, ref ulong mlen_p, byte[] nsec, byte[] c, ulong clen, byte[] ad, ulong adlen, byte[] npub, byte[] k);

            public delegate int Crypto_aead_aes256gcm_encrypt(byte[] c, ref ulong clen_p, byte[] m, ulong mlen, byte[] ad, ulong adlen, byte[] nsec, byte[] npub, byte[] k);

            public delegate int Crypto_aead_aes256gcm_decrypt(byte[] m, ref ulong mlen_p, byte[] nsec, byte[] c, ulong clen, byte[] ad, ulong adlen, byte[] npub, byte[] k);

            #endregion

            #region Stream

            public delegate int Crypto_stream_salsa20_xor_ic(byte[] c, byte[] m, ulong mlen, byte[] n, ulong ic, byte[] k);

            public delegate int Crypto_stream_chacha20_xor_ic(byte[] c, byte[] m, ulong mlen, byte[] n, ulong ic, byte[] k);

            public delegate int Crypto_stream_chacha20_ietf_xor_ic(byte[] c, byte[] m, ulong mlen, byte[] n, uint ic, byte[] k);

            #endregion
        }

        public static class DelegateOpenSSL
        {
            public delegate IntPtr EVP_CIPHER_CTX_new();

            public delegate void EVP_CIPHER_CTX_free(IntPtr ctx);

            public delegate int EVP_CIPHER_CTX_reset(IntPtr ctx);

            public delegate int EVP_CipherInit_ex(IntPtr ctx, IntPtr type, IntPtr impl, byte[] key, byte[] iv, int enc);

            public delegate int EVP_CipherUpdate(IntPtr ctx, byte[] outb, out int outl, byte[] inb, int inl);

            public delegate int EVP_CipherFinal_ex(IntPtr ctx, byte[] outm, ref int outl);

            public delegate int EVP_CIPHER_CTX_set_padding(IntPtr x, int padding);

            public delegate int EVP_CIPHER_CTX_set_key_length(IntPtr x, int keylen);

            public delegate int EVP_CIPHER_CTX_ctrl(IntPtr ctx, int type, int arg, IntPtr ptr);

            /// <summary>
            /// simulate NUL-terminated string
            /// </summary>
            public delegate IntPtr EVP_get_cipherbyname(byte[] name);
        }
    }

    namespace Util
    {
        public static class DelegateUtil
        {
            public delegate IntPtr LoadLibrary(string path);

            public delegate bool SetProcessWorkingSetSize(IntPtr process, UIntPtr minimumWorkingSetSize, UIntPtr maximumWorkingSetSize);
        }
    }

    namespace Model
    {
        public interface IDelegatesInit
        {
            public void Init();
        }
    }
}
