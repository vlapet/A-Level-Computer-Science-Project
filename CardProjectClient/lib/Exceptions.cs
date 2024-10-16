using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardProjectClient.lib
{
    [Serializable]
    public class UriIsEmptyException : Exception 
    {
        public UriIsEmptyException() { }

        public UriIsEmptyException(string message) : base (message) { }

        public UriIsEmptyException(string message, Exception innerException) : base(message, innerException) { }
    }
}
