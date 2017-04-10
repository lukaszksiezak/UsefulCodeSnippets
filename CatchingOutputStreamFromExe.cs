using System;
using System.Diagnostics;

///Simple and useful - starts external executable and handles output stream from it.
///Full credits goes to http://stackoverflow.com/users/4086/ferruccio -> http://stackoverflow.com/a/4291965

namespace CatchOutputStream
{
    class Program
    {
        static void Main(string[] args)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"Path_to_exe",
                    Arguments = @"Args",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }
    }
}
