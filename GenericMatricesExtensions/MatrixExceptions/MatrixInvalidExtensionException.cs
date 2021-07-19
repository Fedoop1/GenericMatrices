using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatricesExtensions.MatrixExceptions
{
    public class MatrixInvalidExtensionException : Exception
    {
        public MatrixInvalidExtensionException(string message) 
            : base(message)
        {
        }

        public MatrixInvalidExtensionException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
