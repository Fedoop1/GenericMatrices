using System;
using System.Linq;
using GenericMatrices.Matrices;
using NUnit.Framework;

namespace GenericMatricesExtensions.Tests
{
    [TestFixture]
    internal class MatrixExtensionTests
    {
        private static int[] source = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private const int MatrixSize = 3;
        
        [Test]
        public void Add_SqauareMatrices_ReturnSquareMatrix()
        {
            var lhs = new SquareMatrix<int>(MatrixSize);
            var rhs = new SquareMatrix<int>(MatrixSize);

            FillMatrix(lhs, source);
            Array.Reverse(source);
            FillMatrix(rhs, source);

            var actual = lhs.Add(rhs);
            var expected = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10 };

            int index = 0;
            foreach (var value in actual)
            {
                if(value != expected[index++])
                {
                    Assert.Fail();
                }
            }

            Assert.True(true);
        }

        [Test]
        public void Add_DiagonalMatrices_ReturnDiagonalMatrix()
        {
            var lhs = new DiagonalMatrix<int>(MatrixSize);
            var rhs = new DiagonalMatrix<int>(MatrixSize);

            FillMatrix(lhs, source);
            Array.Reverse(source);
            FillMatrix(rhs, source);

            var actual = lhs.Add(rhs);
            var expected = new int[] { 10, 0, 0, 0, 10, 0, 0, 0, 10 };

            int index = 0;
            foreach (var value in actual)
            {
                if (value != expected[index++])
                {
                    Assert.Fail();
                }
            }

            Assert.True(true);
        }

        [Test]
        public void Add_SymmetricMatrices_ReturnSymmetricMatrix()
        {
            var lhs = new SymmetricMatrix<int>(MatrixSize);
            var rhs = new SymmetricMatrix<int>(MatrixSize);

            FillMatrix(lhs, source);
            Array.Reverse(source);
            FillMatrix(rhs, source);

            var actual = lhs.Add(rhs);
            var expected = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10 };

            int index = 0;
            foreach (var value in actual)
            {
                if (value != expected[index++])
                {
                    Assert.Fail();
                }
            }

            Assert.True(true);
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
