using System;

namespace Activities.Logic.Exceptions
{
    public class InvalidPersonException : Exception
    {
        public InvalidPersonException(string message) : base(message) { }
    }
}
