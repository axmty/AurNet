using System;

namespace AurNet.Logging
{
    /// <summary>
    /// IDisposable that does nothing.
    /// </summary>
    public class VoidDisposable : IDisposable
    {
        public void Dispose() { }
    }
}
