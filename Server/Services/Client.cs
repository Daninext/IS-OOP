using System;
using System.Text;
using System.Net.Sockets;

namespace Server
{
    public class Client
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private Server _server;

        public Client(TcpClient client, Server server)
        {
            _client = client;
            _stream = _client.GetStream();
            _server = server;
        }

        public void GetCommand()
        {
            try
            {
                byte[] data = new byte[64];
                while (true)
                {
                    var builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = _stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (_stream.DataAvailable);

                    _server.ProcessCommand(this, builder.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (_stream != null)
                    _stream.Close();
                if (_client != null)
                    _client.Close();
            }
        }

        public void SendAnswer(string message)
        {
            if (_stream.CanWrite)
                try
                {
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    _stream.Write(data, 0, data.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        }
    }
}
