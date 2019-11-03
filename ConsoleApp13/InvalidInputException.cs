using System;

namespace ConsoleApp13
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base (message)
        {

        }
    }
}
