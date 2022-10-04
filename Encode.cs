using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace FinalTest
{
    class Encode
    {
        public static string getEncodedPsw(string psw)
        {
            //明文密码由字符串转换为byte数组
            byte[] clearBytes = Encoding.Default.GetBytes(psw);

            //由明文的byte数组计算出MD5密文byte数组
            byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);

            string result = "";

            for (int i = 0; i < hashedBytes.Length; i++)
            {
                result = result + Convert.ToString(hashedBytes[i]);
            }

            return result;
        }
    }

}
