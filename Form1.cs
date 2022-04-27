using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NostaleUselessTrainer
{
    public static class Client
    {
        public static TcpClient TcpClientVar;
        public static int Port;
        public static bool Status;

        public static bool Connect()
        {
            Port = getPort();
            
            TcpClientVar = new TcpClient();
            
            try
            {
                TcpClientVar.Connect("127.0.0.1", Port);
                Status = true;
                return true;
            }
            catch (Exception e)
            {
                Status = false;
                return false;
            }
            
        }
        
        private static int getPort()
        {
            var listDic = SystemFunctions.GetOpenWindows().ToList();
            foreach (var p in listDic)
                if (p.Value.Contains("NosTale PacketLogger - Server: 127.0.0.1"))
                    return Convert.ToInt32(p.Value.Split(':')[2]);

            throw new Exception("Port not found / packet logger not running");
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConnectToPacketLogger();
        }

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
    }
}