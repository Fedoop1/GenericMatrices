using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GenericMatrices.Matrices;
using GenericMatrices.MatrixEventArgs;
using GenericMatrices.MatrixExcepions;
using NUnit.Framework;

namespace GenericMatrices.Tests
{
    [TestFixture]
    internal class MatrixTests
    {
        private const int MatrixSize = 3;
        private static Random random = new Random();

        public void Indexer_InvalidValue_ThrowsMatrixIndexException() => Assert.Throws<MatrixIndexException>(() => new SquareMatrix<int>(MatrixSize)[-1, -1] = 0, "Matrix indexes can't be greater than matrix size and lower than zero.");

        [TestCase(1, 1)]
        [TestCase(0, 2)]
        [TestCase(2, 2)]
        public void CellChange_InvokeEventTests(int indexI, int indexJ)
        {
            var matrix = new SquareMatrix<int>(MatrixSize);

            for (int matrixIndexI = 0; matrixIndexI < MatrixSize; matrixIndexI++)
            {
                for (int matrixIndexJ = 0; matrixIndexJ < MatrixSize; matrixIndexJ++)
                {
                    matrix[matrixIndexI, matrixIndexJ] = random.Next();
                }
            }

            CellChangeEventArgs<int> actualEventData = null;
            matrix.CellChange += (sender, eventArgs) => actualEventData = eventArgs;
            matrix[indexI, indexJ]++;

            Assert.AreEqual(actualEventData.CellIndex, (indexI, indexJ));
            Assert.AreEqual(actualEventData.NewValue, actualEventData.OldValue + 1);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void GetEnumerator_ReturnIterator(int[] source)
        {
            var matrix = new SquareMatrix<int>(MatrixSize);

            FillMatrix(matrix, source);

            int index = 0;
            foreach (var value in matrix)
            {
                if(value != source[index++])
                {
                    Assert.Fail();
                }
            }

            Assert.True(true);
        }

        private static void FillMatrix<T>(Matrix<T> matrix, T[] source)
        {
            int index = 0;
            for (int matrixIndexI = 0; matrixIndexI < MatrixSize; matrixIndexI++)
            {
                for (int matrixIndexJ = 0; matrixIndexJ < MatrixSize; matrixIndexJ++)
                {
                    matrix[matrixIndexI, matrixIndexJ] = source[index++];
                }
            }
        }
    }
}
