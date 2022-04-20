﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AIS.Server.Utils
{
    public static class MD5UtilExtension
    {
        public static string ToMD5Hash(this string str) {
            if (string.IsNullOrEmpty(str)) {
                return null;
            }

            return Encoding.UTF8.GetBytes(str).ToMD5Hash();
        }

        public static string ToMD5Hash(this byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                return null;
            }

            using (var md5 = MD5.Create())
            {
                return string.Join("", md5.ComputeHash(bytes).Select(x => x.ToString("x2")));
            }
        }
    }
}
