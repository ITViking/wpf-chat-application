using System;
using System.Runtime.InteropServices;
using System.Security;

namespace ChatApp.Core
{
    public static class SecureStringHelpers
    {
        public static string Unsecure(this SecureString secureString)
        {
            if (secureString == null)
            {
                return string.Empty;
            }

            //Get location of password in memory
            var unmanagedString = IntPtr.Zero;

            try
            {
                //unsecures the password
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                //Convert the pointer to a string so we can work with it
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                //Clean the password from memory
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
