using System;
using System.Data;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Rocket.RDVQA.Tools.ODBC.Utils
{
    public class HashGenerator
    {
        public static string GenerateSha256(MemoryStream stream)
        {
            using HashAlgorithm hashAlgorithm = SHA256.Create();
            return ByteArrayToHexString(hashAlgorithm.ComputeHash(stream));
        }
        public static string GenerateSha256(FileStream stream)
        {
            using HashAlgorithm hashAlgorithm = SHA256.Create();
            return ByteArrayToHexString(hashAlgorithm.ComputeHash(stream));
        }
        public static string GenerateSha256(string data)
        {
            using HashAlgorithm hashAlgorithm = SHA256.Create();
            return ByteArrayToHexString(hashAlgorithm.ComputeHash(Encoding.ASCII.GetBytes(data)));
        }
        private static string ByteArrayToHexString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

        internal static string GenerateSha256(DataTable dt)
        {
            MemoryStream tempDataStream = new MemoryStream();
            StreamWriter fileWriter = new StreamWriter(tempDataStream);
            foreach (DataRow row in dt.Rows)
            {
                foreach (Object columnVal in row.ItemArray)
                {
                    fileWriter.Write(columnVal);
                }
            }
            fileWriter.Flush();
            tempDataStream.Position = 0;
            return GenerateSha256(tempDataStream);
        }
    }
}
