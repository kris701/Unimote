using System.Net.Sockets;
using System.Net;

TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 42566);

server.Start();
Console.WriteLine("Server has started on 127.0.0.1:42566.{0}Waiting for a connection…", Environment.NewLine);

TcpClient client = server.AcceptTcpClient();



Console.WriteLine("A client connected.");