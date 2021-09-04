using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace phpFE
{
    internal static class General
    {
        //const string appPath = Application.StartupPath + "\\";
        public static string appPath;

        public static object[] RunFile(string cmd, string cmdArgs, string workDir)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    WorkingDirectory = appPath + workDir, //appPath + @"\php\",
                    FileName = appPath + cmd,
                    Arguments = cmdArgs
                };

                Process p = Process.Start(startInfo);

                System.Threading.Thread.Sleep(500);

                return new object[] { p.Id, p.MainWindowHandle };
            }
            catch { }

            return null;            
        }


        internal static string GetProcesses(string processName, out int processCount)
        { //https://stackoverflow.com/a/12237900
            //warning we cant query by process.MainModule.FileName as getting exception on some processes so going with ProcessName
            IEnumerable<Process> processList = from p in Process.GetProcesses()
                                               where p.ProcessName.Equals(processName, StringComparison.OrdinalIgnoreCase)
                                               select p;

            long total = 0;
            foreach (Process item in processList)
            { //https://stackoverflow.com/a/20747258
                total += item.PrivateMemorySize64;
            }

            //this.Text = Application.ProductName + " v" + Application.ProductVersion + " | " +
            //DateTime.Now.ToString("HH:mm:ss") + " | " + processList.Count() + " siebel processes in " +

            processCount = processList.Count();

            return FormatBytes(total) + " in " + processCount + (processCount < 2 ? " process" : " processes");
        }


        internal static string FormatBytes(long size)
        { // https://www.c-sharpcorner.com/article/csharp-convert-bytes-to-kb-mb-gb/
            string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };

            int counter = 0;
            decimal number = size;

            while (Math.Round(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }

            return string.Format("{0:n1}{1}", number, suffixes[counter]);
        }

        public static DialogResult Mes(string descr, MessageBoxIcon icon = MessageBoxIcon.Information, MessageBoxButtons butt = MessageBoxButtons.OK)
        {
            if (descr.Length > 0)
                return MessageBox.Show(descr, Application.ProductName, butt, icon);
            else
                return DialogResult.OK;

        }
    }
}
