using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HorasExtra.Blazor.Helpers
{
    public class CryptHelper
    {
        private string _key;
        private readonly RijndaelManaged _algorithm;
        private readonly byte[] _cryptProvider;

        public CryptHelper()
        {
            _key = "E546C8DF278CD5931069B522E695D4F2";
            _algorithm = new RijndaelManaged();
            _cryptProvider = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc };
        }

        public virtual byte[] GetKey()
        {
            string salt = string.Empty;

            if (_algorithm.LegalKeySizes.Length > 0)
            {
                int keySize = _key.Length * 8;
                int minSize = _algorithm.LegalKeySizes[0].MinSize;
                int maxSize = _algorithm.LegalKeySizes[0].MaxSize;
                int skipSize = _algorithm.LegalKeySizes[0].SkipSize;

                if (keySize > maxSize)
                {
                    // Busca o valor máximo da chave
                    _key = _key.Substring(0, maxSize / 8);
                }

                else if (keySize < maxSize)
                {
                    // Seta um tamanho válido
                    int validSize = (keySize <= minSize) ? minSize : (keySize - keySize % skipSize) + skipSize;
                    if (keySize < validSize)
                    {
                        // Preenche a chave com arterisco para corrigir o tamanho
                        _key = _key.PadRight(validSize / 8, '*');
                    }
                }
            }

            PasswordDeriveBytes key = new PasswordDeriveBytes(_key, Encoding.ASCII.GetBytes(salt));
            return key.GetBytes(_key.Length);
        }

        public string Encrypt(string texto)
        {
            byte[] plainByte = Encoding.UTF8.GetBytes(texto);
            byte[] keyByte = GetKey();

            // Seta a chave privada
            _algorithm.Key = keyByte;
            _algorithm.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc };

            // Interface de criptografia / Cria objeto de criptografia
            ICryptoTransform cryptoTransform = _algorithm.CreateEncryptor();
            MemoryStream _memoryStream = new MemoryStream();
            CryptoStream _cryptoStream = new CryptoStream(_memoryStream, cryptoTransform, CryptoStreamMode.Write);

            // Grava os dados criptografados no MemoryStream
            _cryptoStream.Write(plainByte, 0, plainByte.Length);
            _cryptoStream.FlushFinalBlock();

            // Busca o tamanho dos bytes encriptados
            byte[] cryptoByte = _memoryStream.ToArray();

            // Converte para a base 64 string para uso posterior em um xml
            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0));
        }

        public string Decrypt(string textoCriptografado)
        {
            // Converte a base 64 string em num array de bytes
            byte[] cryptoByte = Convert.FromBase64String(textoCriptografado);
            byte[] keyByte = GetKey();

            // Seta a chave privada
            _algorithm.Key = keyByte;
            _algorithm.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc };

            // Interface de criptografia / Cria objeto de descriptografia
            ICryptoTransform cryptoTransform = _algorithm.CreateDecryptor();

            try
            {
                MemoryStream _memoryStream = new MemoryStream(cryptoByte, 0, cryptoByte.Length);
                CryptoStream _cryptoStream = new CryptoStream(_memoryStream, cryptoTransform, CryptoStreamMode.Read);

                // Busca resultado do CryptoStream
                StreamReader _streamReader = new StreamReader(_cryptoStream);
                return _streamReader.ReadToEnd();
            }
            catch
            {
                return null;
            }
        }
    }
}
