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
        private Random random = new Random();

        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.MatrixTestCases))]
        public void Indexer_InvalidValue_ThrowsMatrixIndexException(Matrix<int> matrix)
        {
            Assert.Throws<MatrixIndexException>(() => matrix[-1, -1] = 0, "Matrix indexes can't be greater than matrix size and lower than zero.");
        }

        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.MatrixTestCases))]
        public void Indexer_ValidValue_MustReturnMatrixCellValue(Matrix<int> matrix)
        {
            var indexI = random.Next(0, MatrixSize);
            var indexJ = random.Next(0, MatrixSize);
            var value = random.Next();

            // Special implementation-side validation rule (all cells except main diagonal must equals default value)
            if(matrix is DiagonalMatrix<int>)
            {
                indexI = indexJ;
            }

            matrix[indexI, indexJ] = value;

            Assert.IsTrue(matrix[indexI, indexJ] == value);
        }

        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.MatrixTestCases))]
        public void Event_CellChange_MustInvokeEvent(Matrix<int> matrix)
        {
            int countOfCalls = 0;
            CellChangeEventArgs<int> eventArgs = null;

            matrix.CellChange += (sender, cellEventArgs) =>
            {
                countOfCalls++;
                eventArgs = cellEventArgs;
            };

            var indexI = random.Next(0, MatrixSize);
            var indexJ = random.Next(0, MatrixSize);
            var value = random.Next();

            // Special implementation-side validation rule (all cells except main diagonal must equals default value)
            if (matrix is DiagonalMatrix<int>)
            {
                indexI = indexJ;
            }

            matrix[indexI, indexJ] = value;

            Assert.IsTrue(countOfCalls == 1 && eventArgs.CellIndex == (indexI, indexJ));
        }

        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.MatrixTestCases))]
        public void Size_ValidSize_ReturnSize(Matrix<int> matrix)
        {
            var actualMatrixSize = 0;

            foreach (var item in matrix)
            {
                actualMatrixSize++;
            }

            actualMatrixSize = (int)Math.Sqrt(actualMatrixSize);

            Assert.AreEqual(matrix.Size, actualMatrixSize);
        }
    }
}
