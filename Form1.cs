using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NostaleUselessTrainer
{
    // Simple class used to store the TcpClient which we use to communicate with the packet logger
    public static class Client
    {
        public static TcpClient TcpClientVar;
        public static int Port;
        public static bool Connected;
        public static NetworkStream NetworkStream;
        public static StreamReader SReader;

        // Tries to connect to the packet logger, and returns true or false based on if the connection was successful
        public static bool Connect()
        {
            Port = GetPort();
            if (Port == -1)
                return false;

            TcpClientVar = new TcpClient();
            
            try
            {
                TcpClientVar.Connect("127.0.0.1", Port);
                NetworkStream = TcpClientVar.GetStream();
                SReader = new StreamReader(NetworkStream, Encoding.UTF8);
                Connected = true;
                return true;
            }
            catch (Exception e)
            {
                Connected = false;
                return false;
            }
        }
        
        // Finds the packet logger window and extracts the port from its name
        private static int GetPort()
        {
            var listDic = SystemFunctions.GetOpenWindows().ToList();
            foreach (var p in listDic)
                if (p.Value.Contains("NosTale PacketLogger - Server: 127.0.0.1"))
                    return Convert.ToInt32(p.Value.Split(':')[2]);

            MessageBox.Show(@"Port not found / packet logger not running", @"Error");
            return -1;
        }
        
        // Sends a packet to the packet logger stream
        public static void SendPacket(NetworkStream ns, string packet)
        {
            packet += "\u000D";
            byte[] bytes = Encoding.UTF8.GetBytes(packet);
            ns.Write(bytes, 0, bytes.Length);
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConnectToPacketLogger();
        }

        // Connects to the packet logger and updates the user interface
        private void ConnectToPacketLogger()
        {
            if (Client.Connect())
            {
                connectionStatusLabel.Text = "Connected";
                connectionStatusLabel.ForeColor = Color.Lime;

                portLabel.Text = Client.Port.ToString();
            }
            else
            {
                connectionStatusLabel.Text = "Not Connected";
                connectionStatusLabel.ForeColor = Color.Red;
                
                portLabel.Text = "unknown";
            }
        }
        
        private void reconnectButton_Click(object sender, EventArgs e)
        {
            ConnectToPacketLogger();
        }

        private void TestPingButton_Click(object sender, EventArgs e)
        {
            if (Client.Connected)
                Cheats.TestPing(Client.NetworkStream, Client.SReader);
            else
                MessageBox.Show(@"Packet logger not found", @"Error");
        }
    }
}