using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Int.Repository
{
    [Serializable]
    internal class RepositoryException : Exception
    {
        public RepositoryException() : base() { }

        public RepositoryException(string message) : base(message) { }

        public RepositoryException(string message, Exception innerException) : base(message, innerException) { }

        public RepositoryException(string format, params object[] args) : base(string.Format(format, args)) { }

        protected RepositoryException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
