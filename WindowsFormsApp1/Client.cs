using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms.VisualStyles;


namespace WindowsFormsApp1
{
    public class Client
    {
        private string hostname_ = "localhost";
        private int port_ = 5250;
        private TcpClient myClient = (TcpClient)null;
        private NetworkStream myStream = (NetworkStream)null;
        private byte[] recvBuffer = new byte[1024];
        private int numberOfBytesRead;

        private string recvMessage = "";
        private List<string> fileNames = new List<string>();

        public Client() { }

        public void SetAdress(string ip, int port)
        {
            this.hostname_ = ip;
            this.port_ = port;
        }

        public bool Connect()
        {
            this.myClient = new TcpClient();
            try
            {
                this.myClient.Connect(this.hostname_, this.port_);
            }
            catch (SocketException e)
            {
                return false;
            }
            this.myStream = this.myClient.GetStream();
            LoadFilesInfo();
            return true;
        }

        public void Disconnect()
        {
            this.myClient.Close();
        }

        private void SendString(string message)
        {
            try
            {
                if (this.myStream != null && this.myStream.CanWrite)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(message + "\r\n");
                    myStream.Write(bytes, 0, bytes.Length);
                }
            }
        catch
        {
        }
        }

        private void LoadData()
        {
            if (myStream.CanRead)
            {
                StringBuilder myCompleteMessage = new StringBuilder();
                do
                {
                    numberOfBytesRead = myStream.Read(recvBuffer, 0,
                        recvBuffer.Length);
                    myCompleteMessage.Append(Encoding.UTF8.GetString(recvBuffer, 0, numberOfBytesRead));
                } while (this.myStream.DataAvailable);
                
                this.recvMessage = myCompleteMessage.ToString(12,myCompleteMessage.Length-13);
            }
        }

        private void LoadFilesInfo()
        {
            SendString("CLS");
            LoadData();
        }
        
        public List<string> GetFilesInfo()
        {
            string tempString = "";
            foreach (Match match in Regex.Matches(this.recvMessage, "\"(\\w+)"))
            {
                tempString = match.Value;
                fileNames.Add(tempString.Substring(1 , tempString.Length-1));
            }
            return fileNames;
        }

        public void LoadVideo(int ch, string video)
        {
            this.SendString("PLAY " + ch.ToString() + " " + video);
        }

    }
}
