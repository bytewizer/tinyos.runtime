﻿using Bytewizer.TinyOS.Sockets.Channel;

namespace Bytewizer.TinyOS.Sockets
{
    /// <summary>
    /// A delegate which is executed when a client has connected.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="channel">The socket channel for the connected end point.</param>
    public delegate void ConnectedHandler(object sender, SocketChannel channel);
}