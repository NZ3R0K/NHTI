using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedResources;

namespace ConnectionResources
{
    public class Connection
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream serverStream;

        string _ip;
        string _port;
        Player _player;

        public Connection(string ip, string port, Player player)
        {
            _ip = ip;
            _port = port;
            _player = player;

            Connect(_ip, _port, player);
        }

        void Connect(string ipAddress, string port, Player player)
        {
            // Connect to a remote device.  
            try
            {
                if (!clientSocket.ConnectAsync(ipAddress, int.Parse(port)).Wait(1000)) 
                    throw new Exception($"Could not connect to server - {ipAddress}:{port}. \nDid you use the proper ip and port?");

                serverStream = clientSocket.GetStream();

                byte[] outStream = player.getBytes();

                serverStream.Write(outStream, 0, outStream.Length);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Server Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Needed for ServerConnectionForm to prevent form from proceeding to GameList
                throw new Exception(e.Message); 
            }
        }

        public void Disconnect()
        {
            if (clientSocket == null || !clientSocket.Connected) return;

            byte[] outStream = UnicodeEncoding.Unicode.GetBytes("D");

            serverStream.Write(outStream, 0, outStream.Length);

            clientSocket.Close();
        }

        public bool WriteSteam(string stream)
        {
            try
            {
                byte[] outStream =stream.ToBytes();

                serverStream.Write(outStream, 0, outStream.Length);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ReadStream(out byte[] inStream, out char type)
        {
            inStream = new byte[1024];
            type = '#';

            try
            {
                serverStream.Read(inStream, 0, SocketDataObject.BufferSize);

                if (inStream[0] == 0) return false;

                serverStream.Flush();

                type = (char)inStream[0];

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}