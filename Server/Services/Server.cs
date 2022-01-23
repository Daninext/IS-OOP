using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading;
using Server.Services.Commands;
using Transformer;
using Transformer.JsonTemplate;

namespace Server
{
    public class Server : IDisposable
    {
        private const string IP = "127.0.0.1";
        private const int PORT = 8888;

        private TcpListener _listener;
        private StaffContext _database;

        private bool _disposed = false;

        public void StartServer()
        {
            _database = new StaffContext();
            var readCommandThread = new Thread(new ThreadStart(ReadCommand));
            readCommandThread.Start();

            try
            {
                _listener = new TcpListener(IPAddress.Parse(IP), PORT);
                _listener.Start();

                Console.WriteLine("Server active");

                while (true)
                {
                    TcpClient tcp = _listener.AcceptTcpClient();
                    var client = new Client(tcp, this);
                    Console.WriteLine("New connection " + tcp.Connected.ToString());

                    var clientThread = new Thread(new ThreadStart(client.GetCommand));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Dispose();
            }
        }

        public void ProcessCommand(Client client, string command)
        {
            ProcessJsonCommand(client, command);
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
                    _database.Dispose();

                    if (_listener != null)
                        _listener.Stop();
                }

                _disposed = true;
            }
        }

        private void ReadCommand()
        {
            while (true)
            {
                string command = TransformClass.TransformToJson(Console.ReadLine() + "|", 2);

                ProcessJsonCommand(null, command);
            }
        }

        private void ProcessJsonCommand(Client client, string command)
        {
            try
            {
                string[] args = command.Split(' ');

                if (args[0] != "auth" && client != null)
                {
                    UserTemplate enterData = JsonSerializer.Deserialize<UserTemplate>(args[args.Length - 1]);
                    if (_database.Users.FirstOrDefault(u => u.Password == enterData.password && u.Id == enterData.intId) == null)
                    {
                        client.SendAnswer("Incorrect active user");
                        client = null;
                        return;
                    }
                }

                ICommand serverCommand = null;
                switch (args[0])
                {
                    case "auth":
                        serverCommand = new AuthorisationCommand(_database, client, args);
                        break;

                    case "create":
                        serverCommand = new CreateCommand(_database, client, args);
                        break;

                    case "find":
                        serverCommand = new FindCommand(_database, client, args);
                        break;

                    case "update":
                        serverCommand = new UpdateCommand(_database, client, args);
                        break;

                    case "set":
                        serverCommand = new SetCommand(_database, client, args);
                        break;

                    case "resolve":
                        serverCommand = new ResolveCommand(_database, client, args);
                        break;

                    case "delete":
                        if (client != null)
                            return;

                        serverCommand = new DeleteCommand(_database, client, args);
                        break;

                    default:
                        if (client == null)
                            Console.WriteLine("Incorrect coommand");
                        else
                            client.SendAnswer("Incorrect coommand");
                        return;
                }

                serverCommand.Execute();
            }
            catch (Exception ex)
            {
                if (client == null)
                    Console.WriteLine(ex.Message);
                else
                    client.SendAnswer(ex.Message);
            }
        }
    }
}
