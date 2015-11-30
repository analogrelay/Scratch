using System;
using System.IO;
using System.Diagnostics;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var psi = new ProcessStartInfo()
            {
                FileName = args[0],
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            var process = new Process() { StartInfo = psi };

            process.OutputDataReceived += (sender, a) =>
            {
                ProcessData(a.Data, Console.Out);
            };

            process.ErrorDataReceived += (sender, a) =>
            {
                ProcessData(a.Data, Console.Error);
            };

            process.EnableRaisingEvents = true;
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
        }

        private static void ProcessData(string data, TextWriter forward)
        {
            if (data == null)
            {
                return;
            }

            forward.Write(data);
        }
    }
}
