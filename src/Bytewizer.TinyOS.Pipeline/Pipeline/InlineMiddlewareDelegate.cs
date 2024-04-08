namespace Bytewizer.TinyOS.Pipeline
{
    /// <summary>
    /// Represents a function that can process an inline pipeline middleware.
    /// </summary>
    public delegate void InlineDelegate(IContext context, RequestDelegate next);
}