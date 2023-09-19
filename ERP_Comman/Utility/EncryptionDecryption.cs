﻿using ERP_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DtyApi.Common
{
    public class EncryptionDecryption
    {
        #region Variable Declaration

        public static string keyString
        {
            get { return ConfigItems.GUIDKey; }
        }

        private static byte[] _keyByte = { };
        //Default Key
        //Default initial vector
        private static byte[] _ivByte = { 0x01, 0x12, 0x23, 0x34, 0x45, 0x56, 0x67, 0x78 };

        #endregion

        #region Methods/Functions

        /// <summary>
        /// Get Encrpted Value of Passed value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetEncrypt(string value)
        {
            return Encrypt(value);
        }

        /// <summary>
        /// Get Decrypted value of passed encrypted string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetDecrypt(string value)
        {
            return Decrypt(value);
        }

        /// <summary>
        /// Encrypt value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static string Encrypt(string value)
        {
            try
            {
                System.Security.Cryptography.TripleDES des = CreateDES();
                System.Security.Cryptography.ICryptoTransform ct = des.CreateEncryptor();
                //MStart: To make short code use Default
                byte[] input = Encoding.Default.GetBytes(value);
                //MEnd: To make short code use Default
                return Convert.ToBase64String(ct.TransformFinalBlock(input, 0, input.Length)).Replace("/", "_").Replace("+", "-");//.Replace("=", "%3D")
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static System.Security.Cryptography.TripleDES CreateDES()
        {
            string Key = keyString;
            System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
            System.Security.Cryptography.TripleDES des = new TripleDESCryptoServiceProvider();
            des.Key = md5.ComputeHash(Encoding.Unicode.GetBytes(Key));
            des.IV = new byte[des.BlockSize / 8];
            return des;
        }

        /// <summary>
        /// decrypt value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string Decrypt(string value)
        {
            try
            {
                value = value.Replace("_", "/").Replace("-", "+");//.Replace("%3D", "=")
                byte[] b = Convert.FromBase64String(value);
                System.Security.Cryptography.TripleDES des = CreateDES();
                System.Security.Cryptography.ICryptoTransform ct = des.CreateDecryptor();
                //des.Padding= PaddingMode.None;
                byte[] output = ct.TransformFinalBlock(b, 0, b.Length);
                //MStart: To make short code use Default
                //return Encoding.Unicode.GetString(output);
                return Encoding.Default.GetString(output);
                //MEnd: To make short code use Default
            }
            catch (Exception Ex)
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
