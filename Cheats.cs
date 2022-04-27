using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace NostaleUselessTrainer
{
    public class Cheats
    {
        // Sends a series of packets and waits for response from the server, then results the average ping
        public static void TestPing(NetworkStream ns, StreamReader reader)
        {
            Stopwatch watch = new Stopwatch();
            for (int i = 0; i < 10; i++)
            {
                Client.SendPacket(ns, "1 rest 2 1 1 2 1");
                watch.Start();
                var currentTime = watch.ElapsedMilliseconds;
                while (true)
                {
                    // Timeout
                    if (watch.ElapsedMilliseconds - currentTime >= 2000)
                    {
                        MessageBox.Show(@"The test ping function has timed out", @"Exception");
                        return;
                    }
                    
                    if (reader.ReadLine().StartsWith("0 rest 1"))
                    {
                        watch.Stop();
                        break;
                    }
                }
                
                MessageBox.Show(String.Format(@"Your ping is {0}ms", watch.ElapsedMilliseconds), @"Exception");
            }
        }
    }
}