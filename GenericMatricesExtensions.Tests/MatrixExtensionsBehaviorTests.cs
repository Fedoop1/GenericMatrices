using System;
using GenericMatrices.Matrices;
using NUnit.Framework;
using GenericMatricesExtensions;
using GenericMatricesExtensions.MatrixExceptions;

namespace GenericMatricesExtensions.Tests
{
    internal class MatrixExtensionsBehaviorTests
    {
        private readonly int[] source = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private const int MatrixSize = 3;

        [Test]
        public void Add_SquareAndSquareMatrix_ReturnSquareMatrix()
        {
            var lhs = new SquareMatrix<int>(MatrixSize);
            var rhs = new SquareMatrix<int>(MatrixSize);

            FillMatrix(lhs, source);
            FillMatrix(rhs, source);

            var actual = lhs.Add(rhs);

            Assert.IsTrue(actual is SquareMatrix<int>);
        }

        [Test]
        public void Add_DiagonalAndDiagonalMatrix_ReturnDiagonalMatrix()
        {
            var lhs = new DiagonalMatrix<int>(MatrixSize);
            var rhs = new DiagonalMatrix<int>(MatrixSize);

            FillMatrix(lhs, source);
            FillMatrix(rhs, source);

            var actual = lhs.Add(rhs);

            Assert.IsTrue(actual is DiagonalMatrix<int>);
        }

        [Test]
        public void Add_DiagonalAndSquareMatrix_ReturnSquareMatrix()
        {
            var lhs = new DiagonalMatrix<int>(MatrixSize);
            var rhs = new SquareMatrix<int>(MatrixSize);

            FillMatrix(lhs, source);
            FillMatrix(rhs, source);

            var actual = lhs.Add(rhs);

            Assert.IsTrue(actual is SquareMatrix<int>);
        }

        [Test]
        public void Add_SymmetricAndDiagonalMatrix_ReturnSymmetricMatrix()
        {
            var lhs = new SymmetricMatrix<int>(MatrixSize);
            var rhs = new DiagonalMatrix<int>(MatrixSize);

            FillMatrix(lhs, source);
            FillMatrix(rhs, source);

            var actual = lhs.Add(rhs);

            Assert.IsTrue(actual is SymmetricMatrix<int>);
        }

        [Test]
        public void Add_SymmetricAndSymmetricMatrix_ReturnSymmetricMatrix()
        {
            var lhs = new SymmetricMatrix<int>(MatrixSize);
            var rhs = new SymmetricMatrix<int>(MatrixSize);

            FillMatrix(lhs, source);
            FillMatrix(rhs, source);

            var actual = lhs.Add(rhs);

            Assert.IsTrue(actual is SymmetricMatrix<int>);
        }

        [Test]
        public void Add_SymmetricAndSquareMatrix_ReturnSquareMatrix()
        {
            var lhs = new SymmetricMatrix<int>(MatrixSize);
            var rhs = new SquareMatrix<int>(MatrixSize);

            FillMatrix(lhs, source);
            FillMatrix(rhs, source);

            var actual = lhs.Add(rhs);

            Assert.IsTrue(actual is SquareMatrix<int>);
        }

        [TestCase(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' })]
        public void Add_SquareMatrix_ElementDoesntSupportAddOperatorion_ThrowMatrixInvalidExtensionException(char[] source)
        {
            var lhs = new SquareMatrix<char>(MatrixSize);
            var rhs = new SquareMatrix<char>(MatrixSize);

            FillMatrix(lhs, source);
            FillMatrix(rhs, source);

            Assert.Throws<MatrixInvalidExtensionException>(() => lhs.Add(rhs), $"{typeof(char)} doesn't support the addition operation, try to override plus operator or use another type of elements in matrix.");
        }

        public void FillMatrix<TSource>(SquareMatrix<TSource> matrix, TSource[] source)
        {
            int index = 0;
            for (int indexI = 0; indexI < MatrixSize; indexI++)
            {
                for (int indexJ = 0; indexJ < MatrixSize; indexJ++)
                {
                    matrix[indexI, indexJ] = source[index++];
                }
            }
        }
        public void FillMatrix<TSource>(DiagonalMatrix<TSource> matrix, TSource[] source)
        {
            for (int index = 0; index < MatrixSize; index++)
            {
                matrix[index, index] = source[index];
            }
        }
        public void FillMatrix<TSource>(SymmetricMatrix<TSource> matrix, TSource[] source)
        {
            int index = 0;
            for (int indexI = 0; indexI < MatrixSize; indexI++)
            {
                for (int indexJ = 0; indexJ <= indexI; indexJ++)
                {
                    matrix[indexI, indexJ] = source[index++];
                }
            }
        }
    }
}
