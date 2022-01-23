using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Transformer;

namespace App.Services
{
    public class AppClient : IDisposable
    {
        private const string IP = "127.0.0.1";
        private const int PORT = 8888;
        private TcpClient _client;
        private NetworkStream _stream;

        private Authorization _authForm;
        private MenuForm _menuForm;

        private bool _disposed = false;

        public AppClient(Authorization form)
        {
            _authForm = form;
            Connect();
        }

        public AppClient(MenuForm form)
        {
            _menuForm = form;
            Connect();
        }

        ~AppClient()
        {
            Dispose(false);
        }

        public void SendMessage(string message, int startJsonIndex)
        {
            try
            {
                string jsonMessage = TransformClass.TransformToJson(message, startJsonIndex);
                byte[] data = Encoding.Unicode.GetBytes(jsonMessage);
                _stream.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection lost \n" + ex.Message);
                Exit();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Disconnect();
                }

                _disposed = true;
            }
        }

        private void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64];
                    var builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = _stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (_stream.DataAvailable);

                    if (_authForm != null)
                        _authForm.ProcessMessage(builder.ToString());
                    else
                        _menuForm.ProcessMessage(builder.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection lost \n" + ex.Message);
                    Exit();
                }
            }
        }

        private void Connect()
        {
            _client = new TcpClient();

            try
            {
                _client.Connect(IP, PORT);
                _stream = _client.GetStream();

                var receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error \n" + ex.Message);
                Exit();
            }
        }

        private void Disconnect()
        {
            if (_client != null)
                _client.Close();
            if (_stream != null)
                _stream.Close();
        }

        private void Exit()
        {
            Disconnect();
            Environment.Exit(0); ;
        }
    }
}
