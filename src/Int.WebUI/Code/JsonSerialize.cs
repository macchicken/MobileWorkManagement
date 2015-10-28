using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace Int.WebUI
{
    public class JsonSerialize
    {
        public static string Serialize(Object obj)
        {
            string result = string.Empty;
            IFormatter fm = new BinaryFormatter();
            MemoryStream sm = new MemoryStream();
            fm.Serialize(sm, obj);
            sm.Seek(0, SeekOrigin.Begin);
            byte[] bt = sm.GetBuffer();
            result = System.Convert.ToBase64String(bt);
            return result;
        }

        public static Object Deserialize(string str)
        {
            byte[] bt = Convert.FromBase64String(str);
            MemoryStream smNew = new MemoryStream(bt);
            IFormatter fmNew = new BinaryFormatter();
            return fmNew.Deserialize(smNew);
        }
    }
}