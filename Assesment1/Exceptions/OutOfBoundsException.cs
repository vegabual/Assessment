﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment1.Exceptions
{
    public class OutOfBoundsException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the OutOfBoundsException class.
        /// </summary>
        public OutOfBoundsException(){ }

        /// <summary>
        ///     Initializes a new instance of the OutOfBoundsException class with a specified errormessage.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public OutOfBoundsException(string? message) : base(message){ }

        /// <summary>
        ///     Initializes a new instance of the OutOfBoundsException class with a specified error
        ///     message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message"The error message that explains the reason for the exception.></param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference
        ///     (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        public OutOfBoundsException(string? message, Exception? innerException) : base(message, innerException) { }
    }
}
