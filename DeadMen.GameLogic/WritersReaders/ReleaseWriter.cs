using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace DeadMen.GameLogic.WritersReaders
{
    public class ReleaseWriter : IWriter
    {
        public static string rootDataDirectory = @"%AppData%\DeadMen\";
        public static string saveDataDirectory = rootDataDirectory + @"saves\";
        public static string gameDataDirectory = rootDataDirectory + @"data\";
        private static byte[] KEY = Encoding.UTF8.GetBytes("Dead Men Tell No Tales");

        static ReleaseWriter()
        {

        }

        public void Write(string data,string fileFullPath)
        {
            using (Rijndael Encryptor = Rijndael.Create())
            {
                byte[] encryptedData = EncryptStringToBytes(data, KEY, Encryptor.IV);
                WriteRawBytes(encryptedData, fileFullPath);
            }
        }

        private void WriteRawBytes(byte[] data, string fileFullPath)
        {
            File.WriteAllBytes(fileFullPath, data);
        }

        private byte[] EncryptStringToBytes(string data, byte[] Key, byte[] IV)
        {
            byte[] encrypted;

            using (Rijndael algorithm = Rijndael.Create())
            {
                algorithm.Key = Key;
                algorithm.IV = IV;

                ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);

                using (MemoryStream memoryStreamEncryptor = new MemoryStream())
                {
                    using (CryptoStream cryptostreamEncryptor = new CryptoStream(memoryStreamEncryptor, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriterEncryptor = new StreamWriter(cryptostreamEncryptor))
                        {
                            streamWriterEncryptor.Write(data);
                        }
                        encrypted = memoryStreamEncryptor.ToArray();
                    }
                }
                return encrypted;
            }
        }

        static private string DecryptBytesToString(string data, byte[] Key, byte[] IV)
        {
            string decrypted;

            using (Rijndael algorithm = Rijndael.Create())
            {
                algorithm.Key = Key;
                algorithm.IV = IV;

                ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);

                using (MemoryStream memoryStreamDecryptor = new MemoryStream())
                {
                    using (CryptoStream cryptoStreamDecryptor = new CryptoStream(memoryStreamDecryptor, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReaderDecryptor = new StreamReader(cryptoStreamDecryptor))
                        {
                            decrypted = streamReaderDecryptor.ReadToEnd();
                        }
                    }
                }
                return decrypted;
            }
        }
    }
}
