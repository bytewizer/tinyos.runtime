using Bytewizer.TinyOS.Pipeline;
using Bytewizer.TinyOS.Sockets.Channel;

namespace Bytewizer.TinyOS.Sockets
{
    /// <summary>
    /// An interface for <see cref="SocketContext"/>.
    /// </summary>
    public interface ISocketContext : IContext
    {
        /// <summary>
        /// Gets or sets information about the underlying connection for this request.
        /// </summary>
        SocketChannel Channel { get; set; }
    }
}