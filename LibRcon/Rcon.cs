using System.Net.Sockets;

namespace LibRcon
{
    public class Rcon : IDisposable
    {
        private Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public Rcon(string host, int port, string passwd)
        {
            server.Connect(host, port);
            Login(passwd);
        }

        public void Dispose()
        {
            if (server.Connected)
                server.Dispose();
        }

        private void Login(string passwd)
        {
            var src = new Packet(0, 3, passwd).ToStream();
            server.Send(src);
            var resp = new byte[1024];
            int reced=server.Receive(resp);
            var res=Packet.Stream2Packet(resp);
        }
        public string Command(string cmd)
        {
            server.Send(new Packet(0, 2, cmd).ToStream());
            Thread.Sleep(100);
            var resp = new byte[1024*10];
            server.Receive(resp);
            var res = Packet.Stream2Packet(resp);
            return res.Body;
        }
    }
}