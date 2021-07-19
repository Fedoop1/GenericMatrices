using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericMatrices.Matrices;
using NUnit.Framework;

namespace GenericMatrices.Tests
{
    [TestFixture(new[] { 74, 25, 44, 98, 120, 1000, 455, 99, 11 }, TypeArgs = new Type[] { typeof(int) })]
    [TestFixture(new[] { '7', '2', '4', '9', '1', '2', '5', '8', '1' }, TypeArgs = new Type[] { typeof(char) })]
    [TestFixture(new[] { 74.0f , 25.0f, 44.0f, 98.0f, 120.0f, 1000.0f, 455.0f, 247.0f, 111.0f }, TypeArgs = new Type[] { typeof(float) })]
    internal class SquareMatrixTests<T> 
    {
        private const int DiagonalMatrixSize = 3;
        private static readonly Random random = new Random();
        private readonly T[] source;

        public SquareMatrixTests(T[] source) => this.source = source;

        [TestCase(1, 1)]
        [TestCase(2, 0)]
        [TestCase(1, 2)]
        [TestCase(0, 0)]
        public void SetAndGet_ValidIndexesTests(int indexI, int IndexJ)
        {
            var matrix = new SquareMatrix<T>(DiagonalMatrixSize);

            int index = 0;
            for (int matrixIndexI = 0; matrixIndexI < DiagonalMatrixSize; matrixIndexI++)
            {
                for (int matrixIndexJ = 0; matrixIndexJ < DiagonalMatrixSize; matrixIndexJ++)
                {
                    matrix[matrixIndexI, matrixIndexJ] = source[index++];
                }
            }

            var actual = matrix[indexI, IndexJ];

            Assert.IsFalse(actual.Equals(default(T)));
        }

    }
}
