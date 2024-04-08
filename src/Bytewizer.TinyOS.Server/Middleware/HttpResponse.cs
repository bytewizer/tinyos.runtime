using System;
using System.Text;
using System.Net.Sockets;

using System.Diagnostics;

using Bytewizer.TinyOS.Pipeline;
using Bytewizer.TinyOS.Sockets;


namespace Bytewizer.Playground.Sockets
{
    public class HttpResponse : Middleware
    {
        protected override void Invoke(IContext context, RequestDelegate next)
        {
            var ctx = context as ISocketContext;

            try
            {
                if (ctx?.Channel.InputStream == null)
                {
                    return;
                }

                //read request 
                byte[] requestBytes = new byte[1024];
                int bytesRead = ctx.Channel.InputStream.Read(requestBytes, 0, requestBytes.Length);

                string request = Encoding.UTF8.GetString(requestBytes, 0, bytesRead);
                var requestHeaders = ParseHeaders(request);

                string[] requestFirstLine = requestHeaders.requestType.Split(" ");

                if (requestFirstLine[0].StartsWith("GET"))
                {
                    string response = "HTTP/1.1 200 OK\r\nContent-Type: text/html; charset=UTF-8\r\n\r\n" +
                         "<doctype !html><html><head><meta http-equiv='refresh' content='3'><title>Hello, world!</title>" +
                         "<style>body { background-color: #111 } h1 { font-size:2cm; text-align: center; color: white;}</style></head>" +
                         "<body><h1>" + DateTime.Now.Ticks.ToString() + "</h1></body></html>";

                    // send the response to browser
                    ctx.Channel.Write(response);
                }
            }
            catch
            {
                // try to manage all unhandled exceptions in the pipeline
                Debug.WriteLine("Unhandled exception message in the pipeline");
            }
        }


        private static (Dictionary<string, string> headers, string requestType) ParseHeaders(string headerString)
        {
            var headerLines = headerString.Split('\r', '\n');
            string firstLine = headerLines[0];
            var headerValues = new Dictionary<string, string>();
            foreach (var headerLine in headerLines)
            {
                var headerDetail = headerLine.Trim();
                var delimiterIndex = headerLine.IndexOf(':');
                if (delimiterIndex >= 0)
                {
                    var headerName = headerLine.Substring(0, delimiterIndex).Trim();
                    var headerValue = headerLine.Substring(delimiterIndex + 1).Trim();
                    headerValues.Add(headerName, headerValue);
                }
            }
            return (headerValues, firstLine);
        }

        private static void SendHeaders(string? httpVersion, int statusCode, string statusMsg, string? contentType, string? contentEncoding,
            int byteLength, ref NetworkStream networkStream)
        {
            string responseHeaderBuffer = "";

            responseHeaderBuffer = $"HTTP/1.1 {statusCode} {statusMsg}\r\n" +
                $"Connection: Keep-Alive\r\n" +
                $"Date: {DateTime.UtcNow.ToString()}\r\n" +
                $"Server: MacOs PC \r\n" +
                $"Content-Encoding: {contentEncoding}\r\n" +
                "X-Content-Type-Options: nosniff" +
                $"Content-Type: application/signed-exchange;v=b3\r\n\r\n";

            byte[] responseBytes = Encoding.UTF8.GetBytes(responseHeaderBuffer);
            networkStream.Write(responseBytes, 0, responseBytes.Length);
        }
    }
}
