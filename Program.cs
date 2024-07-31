using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaveSessionLogin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "]: Input Session > ");
            try
            {
                string newValue = Console.ReadLine();

                using (RegistryKey session = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\KasperskyLab", true))
                {
                    if (session == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n[" + DateTime.Now.ToString("HH:mm:ss") + "]: Session key doesnt exist, launch Wave, login (or create an account) then close it and retry.");
                    }
                    else
                    {
                        session.SetValue("Session", newValue, RegistryValueKind.String);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n[" + DateTime.Now.ToString("HH:mm:ss") + "]: Logged in! Open Wave then press 'Would you like to continue with the last session?'.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[" + DateTime.Now.ToString("HH:mm:ss") + "]: Exception!: " + ex.ToString());
            }
            Console.WriteLine("\nClosing in 5 seconds..");
            Thread.Sleep(1000);
            Console.WriteLine("Closing in 4 seconds..");
            Thread.Sleep(1000);
            Console.WriteLine("Closing in 3 seconds..");
            Thread.Sleep(1000);
            Console.WriteLine("Closing in 2 seconds..");
            Thread.Sleep(1000);
            Console.WriteLine("Closing in 1 second..");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
    }
}
