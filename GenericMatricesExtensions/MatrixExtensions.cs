using System;
using System.Linq.Expressions;
using GenericMatrices.Matrices;
using GenericMatricesExtensions.MatrixExceptions;

namespace GenericMatricesExtensions
{
    /// <summary>
    /// Class than provides <see cref="Matrix{T}"/> class extension methods.
    /// </summary>
    public static class MatrixExtensions
    {
        /// <summary>
        /// Adds left-hand side matrix to right-hand side matrix.
        /// </summary>
        /// <typeparam name="T">Type of elements in matrix.</typeparam>
        /// <param name="lhs">The left-hand side matrix.</param>
        /// <param name="rhs">The right-hand side matrix.</param>
        /// <returns>The result of the adding of two matrices.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Throws when left-hand side matrix is null.
        /// or
        /// Throws when right-hand side matrix is null.
        /// </exception>
        /// <exception cref="MatrixInvalidExtensionException">
        /// Throws when left-hand side matrix size differ of right-hand side matrix.
        /// or 
        /// Throws when type of matrix element doesn't support the addition operation.
        /// </exception>
        public static Matrix<T> Add<T>(this Matrix<T> lhs, Matrix<T> rhs)
        {
            if (lhs is null)
            {
                throw new ArgumentNullException(nameof(lhs), "Left-hand side matrix is null");
            }

            if (rhs is null)
            {
                throw new ArgumentNullException(nameof(rhs), "Right-hand side matrix is null");
            }

            if (lhs.Size != rhs.Size)
            {
                throw new MatrixInvalidExtensionException("Extension methods doesn't support addition of two matrices of different size");
            }

            return Add((dynamic)lhs, (dynamic)rhs);
        }
        
        private static SquareMatrix<T> Add<T>(this SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            try
            {
                var result = new SquareMatrix<T>(lhs.Size);
                for (int indexI = 0; indexI < lhs.Size; indexI++)
                {
                    for (int indexJ = 0; indexJ < lhs.Size; indexJ++)
                    {
                        result[indexI, indexJ] = Add(lhs[indexI, indexJ], rhs[indexI, indexJ]);
                    }
                }

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new MatrixInvalidExtensionException($"{typeof(T)} doesn't support the addition operation, try to override plus operator or use another type of elements in matrix.");
            }
        }

        private static SquareMatrix<T> Add<T>(this SquareMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            try
            {
                var result = new SquareMatrix<T>(lhs.Size);
                for (int index = 0; index < lhs.Size; index++)
                {
                    result[index, index] = Add(lhs[index, index], rhs[index, index]);
                }

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new MatrixInvalidExtensionException($"{typeof(T)} doesn't support the addition operation, try to override plus operator or use another type of elements in matrix.");
            }
        }

        private static SquareMatrix<T> Add<T>(this SquareMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            try
            {
                var result = new SquareMatrix<T>(lhs.Size);
                for (int indexI = 0; indexI < lhs.Size; indexI++)
                {
                    for (int indexJ = 0; indexJ < lhs.Size; indexJ++)
                    {
                        result[indexI, indexJ] = Add(lhs[indexI, indexJ], rhs[indexI, indexJ]);
                    }
                }

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new MatrixInvalidExtensionException($"{typeof(T)} doesn't support the addition operation, try to override plus operator or use another type of elements in matrix.");
            }
        }

        private static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            try
            {
                var result = new DiagonalMatrix<T>(lhs.Size);
                for (int index = 0; index < lhs.Size; index++)
                {
                    result[index, index] = Add(lhs[index, index], rhs[index, index]);
                }

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new MatrixInvalidExtensionException($"{typeof(T)} doesn't support the addition operation, try to override plus operator or use another type of elements in matrix.");
            }
        }

        private static SquareMatrix<T> Add<T>(this DiagonalMatrix<T> lhs, SquareMatrix<T> rhs) => rhs.Add(lhs);

        private static SymmetricMatrix<T> Add<T>(this DiagonalMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            try
            {
                var result = new SymmetricMatrix<T>(lhs.Size);
                for (int indexI = 0; indexI < lhs.Size; indexI++)
                {
                    for (int indexJ = 0; indexJ < lhs.Size; indexJ++)
                    {
                        result[indexI, indexJ] = Add(lhs[indexI, indexJ], rhs[indexI, indexJ]);
                    }
                }

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new MatrixInvalidExtensionException($"{typeof(T)} doesn't support the addition operation, try to override plus operator or use another type of elements in matrix.");
            }
        }

        private static SymmetricMatrix<T> Add<T>(this SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            try
            {
                var result = new SymmetricMatrix<T>(lhs.Size);
                for (int indexI = 0; indexI < lhs.Size; indexI++)
                {
                    for (int indexJ = 0; indexJ < lhs.Size; indexJ++)
                    {
                        result[indexI, indexJ] = Add(lhs[indexI, indexJ], rhs[indexI, indexJ]);
                    }
                }

                return result;
            }
            catch (InvalidOperationException)
            {
                throw new MatrixInvalidExtensionException($"{typeof(T)} doesn't support the addition operation, try to override plus operator or use another type of elements in matrix.");
            }
        }

        private static SymmetricMatrix<T> Add<T>(this SymmetricMatrix<T> lhs, DiagonalMatrix<T> rhs) => rhs.Add(lhs);

        private static SquareMatrix<T> Add<T>(this SymmetricMatrix<T> lhs, SquareMatrix<T> rhs) => rhs.Add(lhs);

        private static T Add<T>(T lhs, T rhs)
        {
            var firstArgument = Expression.Parameter(typeof(T), "lhs");
            var secondArgument = Expression.Parameter(typeof(T), "rhs");

            var method = Expression.Add(firstArgument, secondArgument);
            var lambda = Expression.Lambda<Func<T, T, T>>(method, firstArgument, secondArgument);

            return lambda.Compile()(lhs, rhs);
        }
    }
}
