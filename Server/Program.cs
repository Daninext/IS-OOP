using System;

namespace Server
{
    internal class Program
    {
        static private void Main(string[] args)
        {
            var server = new Server();

            server.StartServer();
        }
    }
}
