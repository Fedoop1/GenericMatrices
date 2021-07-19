using System;

namespace GenericMatrices.MatrixExcepions
{
    public class MatrixIndexException : Exception
    {
        public MatrixIndexException(string message) 
            : base(message)
        {
        }

        public MatrixIndexException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
