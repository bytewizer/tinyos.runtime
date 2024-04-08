﻿namespace Bytewizer.TinyOS.Pipeline
{
    /// <summary>
    /// Represents a function that can process a request.
    /// </summary>
    /// <param name="context">The context for the request.</param>
    public delegate void RequestDelegate(IContext context);
}