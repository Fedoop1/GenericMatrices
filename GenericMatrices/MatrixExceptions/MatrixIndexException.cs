using System;
using GenericMatrices.Matrices;

namespace GenericMatrices.MatrixExcepions
{
    /// <summary>
    /// Custom exception of <see cref="Matrix{T}"/> class which throws when index operation on a matrix fail.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class MatrixIndexException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixIndexException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public MatrixIndexException(string message) 
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatrixIndexException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public MatrixIndexException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
