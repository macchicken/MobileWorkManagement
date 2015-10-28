using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Int.Common
{
    public static class Utility
    {
        //1 先sha1加密成36位，
        //2 移除前后2位，使之变成一个32位数（看起来像一个MD5的加密值）
        //3 再将结果MD5一次
        public static string EncryptPwd(string pwd)
        {
            if (string.IsNullOrWhiteSpace(pwd))
                throw new ArgumentNullException(pwd, "密码不能为空");

            //建立SHA1对象
            SHA1 sha = new SHA1CryptoServiceProvider();
            //将mystr转换成byte[]
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] dataToHash = enc.GetBytes(pwd);
            //Hash运算
            byte[] dataHashed = sha.ComputeHash(dataToHash);
            string hash = BitConverter.ToString(dataHashed).Replace("-", "");

            //移除前后2位
            hash = hash.Substring(2).Substring(0, hash.Length - 2);

            //md5加密
            dataToHash = enc.GetBytes(hash);

            MD5 md5 = new MD5CryptoServiceProvider();
            dataHashed = md5.ComputeHash(dataToHash);
            hash = BitConverter.ToString(dataHashed).Replace("-", "");
            return hash;
        }
    }
}