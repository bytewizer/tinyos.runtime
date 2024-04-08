using System.Net;
using Bytewizer.TinyOS.Sockets;

using Bytewizer.Playground.Sockets;

internal class Program
{
    private static SocketServer? _server;

    private static void Main(string[] args)
    {        
        _server = new SocketServer(options =>
        {
            options.Listen(IPAddress.Any, 8080);
            options.Pipeline(app =>
            {
                app.UseHttpResponse();
            });
        });

        _server.Start();
    }
}