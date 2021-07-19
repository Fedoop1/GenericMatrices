using System;
using System.Linq.Expressions;
using GenericMatrices.Matrices;
using GenericMatricesExtensions.MatrixExceptions;
using Microsoft.CSharp.RuntimeBinder;

namespace GenericMatricesExtensions
{
    public static class MatrixExtensions
    {
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
                throw new MatrixInvalidExtensionException("Extension methods do not support addition of two matrices of different size");
            }

            return Add((dynamic)lhs, (dynamic)rhs);
        }
        
        private static SquareMatrix<T> Add<T>(this SquareMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            try
            {
                for (int indexI = 0; indexI < lhs.Size; indexI++)
                {
                    for (int indexJ = 0; indexJ < lhs.Size; indexJ++)
                    {
                        lhs[indexI, indexJ] = Add(lhs[indexI, indexJ], rhs[indexI, indexJ]);
                    }
                }

                return lhs;
            }
            catch (RuntimeBinderException)
            {
                throw new MatrixInvalidExtensionException($"{typeof(T)} doesn't support the addition operation, try to override plus operator or use another type of elements in matrix.");
            }
        }

        private static SquareMatrix<T> Add<T>(this SquareMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            try
            {
                for (int index = 0; index < lhs.Size; index++)
                {
                    lhs[index, index] = Add(lhs[index, index], rhs[index, index]);
                }

                return lhs;
            }
            catch (RuntimeBinderException)
            {
                throw new MatrixInvalidExtensionException($"{typeof(T)} doesn't support the addition operation, try to override plus operator or use another type of elements in matrix.");
            }
        }

        private static SquareMatrix<T> Add<T>(this SquareMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            try
            {
                for (int indexI = 0; indexI < lhs.Size; indexI++)
                {
                    for (int indexJ = 0; indexJ < lhs.Size; indexJ++)
                    {
                        lhs[indexI, indexJ] = Add(lhs[indexI, indexJ], rhs[indexI, indexJ]);
                    }
                }

                return lhs;
            }
            catch (RuntimeBinderException)
            {
                throw new MatrixInvalidExtensionException($"{typeof(T)} doesn't support the addition operation, try to override plus operator or use another type of elements in matrix.");
            }
        }

        private static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> lhs, DiagonalMatrix<T> rhs)
        {
            try
            {
                for (int index = 0; index < lhs.Size; index++)
                {
                    lhs[index, index] = Add(lhs[index, index], rhs[index, index]);
                }

                return lhs;
            }
            catch (RuntimeBinderException)
            {
                throw new MatrixInvalidExtensionException($"{typeof(T)} doesn't support the addition operation, try to override plus operator or use another type of elements in matrix.");
            }
        }

        private static SquareMatrix<T> Add<T>(this DiagonalMatrix<T> lhs, SquareMatrix<T> rhs)
        {
            return rhs.Add(lhs);
        }

        private static SymmetricMatrix<T> Add<T>(this DiagonalMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            try
            {
                for (int indexI = 0; indexI < lhs.Size; indexI++)
                {
                    for (int indexJ = 0; indexJ < lhs.Size; indexJ++)
                    {
                        rhs[indexI, indexJ] = Add(lhs[indexI, indexJ], rhs[indexI, indexJ]);
                    }
                }

                return rhs;
            }
            catch (RuntimeBinderException)
            {
                throw new MatrixInvalidExtensionException($"{typeof(T)} doesn't support the addition operation, try to override plus operator or use another type of elements in matrix.");
            }
        }

        private static SymmetricMatrix<T> Add<T>(this SymmetricMatrix<T> lhs, SymmetricMatrix<T> rhs)
        {
            try
            {
                for (int indexI = 0; indexI < lhs.Size; indexI++)
                {
                    for (int indexJ = 0; indexJ < lhs.Size; indexJ++)
                    {
                        lhs[indexI, indexJ] = Add(lhs[indexI, indexJ], rhs[indexI, indexJ]);
                    }
                }

                return lhs;
            }
            catch (RuntimeBinderException)
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
