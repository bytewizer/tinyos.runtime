using System.Net;
using System.Net.Sockets;

namespace Bytewizer.TinyOS.Sockets.Channel
{
    /// <summary>
    /// Represents a socket connection between two end points.
    /// </summary>
    public class ConnectionInfo
    {
        /// <summary>
        /// Get the identity of this channel.
        /// </summary>
        public Guid Id { get; internal set; } = Guid.NewGuid();

        /// <summary>
        /// Gets endpoint of the local end point.
        /// </summary>
        public EndPoint? LocalEndpoint { get; internal set; }

        /// <summary>
        /// Gets address of the local end point.
        /// </summary>
        public IPAddress LocalIpAddress => ((IPEndPoint)LocalEndpoint).Address;

        /// <summary>
        /// Gets port of the local end point.
        /// </summary>
        public int LocalPort => ((IPEndPoint)LocalEndpoint).Port;

        /// <summary>
        /// Gets endpoint of the connected end point.
        /// </summary>
        public EndPoint? RemoteEndpoint { get; internal set; }

        /// <summary>
        /// Gets address of the connected end point.
        /// </summary>
        public IPAddress RemoteIpAddress => ((IPEndPoint)RemoteEndpoint).Address;

        /// <summary>
        /// Gets port of the connected end point.
        /// </summary>
        public int RemotePort => ((IPEndPoint)RemoteEndpoint).Port;

        /// <summary>
        /// Assign a connection information to this channel.
        /// </summary>
        /// <param name="socket">The connected socket for channel.</param>
        internal void Assign(Socket socket)
        {
            LocalEndpoint = socket.LocalEndPoint;
            RemoteEndpoint = socket.RemoteEndPoint;
        }

        /// <summary>
        /// Assign a connection information to this channel.
        /// </summary>
        /// <param name="socket">The connected socket for channel. </param>
        /// <param name="endpoint">The remote endpoint of the connected socket. </param>
        internal void Assign(Socket socket, EndPoint endpoint)
        {
            LocalEndpoint = socket.LocalEndPoint;
            RemoteEndpoint = endpoint;
        }
    }
}