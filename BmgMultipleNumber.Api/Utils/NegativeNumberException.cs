using System.Diagnostics;
using System.Runtime.Serialization;

namespace BmgMultipleNumber.Api.Utils
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    [Serializable]
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException()
        {
        }

        public NegativeNumberException(string? message) : base(message)
        {
        }

        public NegativeNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NegativeNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}