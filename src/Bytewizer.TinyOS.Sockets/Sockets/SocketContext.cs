﻿using Bytewizer.TinyOS.Sockets.Channel;

namespace Bytewizer.TinyOS.Sockets
{
    /// <summary>
    /// Encapsulates all socket specific information about an individual request.
    /// </summary>
    public class SocketContext : ISocketContext
    {
        /// <inheritdoc/>
        public SocketChannel Channel { get; set; } = new SocketChannel();

        /// <summary>
        /// Aborts the connection underlying this request.
        /// </summary>
        public void Abort()
        {
            Channel?.Client?.Close();
        }

        /// <inheritdoc/>
        public void Clear() 
        {
            Channel?.Clear();
        }
    }
}