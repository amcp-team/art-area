using System;

namespace ArtArea.Parse.Psd.Builder
{
    /// <summary>
    /// Thrown if the rules of the PSD/PSB file format have been violated.
    /// </summary>
    public class PsdBuildException : Exception
    {
        public PsdBuildException()
            : base()
        {
        }
        
        public PsdBuildException(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}
