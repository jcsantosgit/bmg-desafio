using System.Diagnostics;
using System.Runtime.Serialization;

namespace BmgMultipleNumber.Api.Utils
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    [Serializable]
    public class EmptyListException : Exception
    {
        public EmptyListException()
        {
        }

        public EmptyListException(string? message) : base(message)
        {
        }

        public EmptyListException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmptyListException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}