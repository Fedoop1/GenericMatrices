using System;
using NUnit.Framework;
using GenericMatrices.Matrices;
using GenericMatrices.MatrixExcepions;

namespace GenericMatrices.Tests
{
    [TestFixture(new [] { 1, 3, 5 }, TypeArgs = new Type[] { typeof(int) })]
    [TestFixture(new [] { '1', '3', '5' }, TypeArgs = new Type[] { typeof(char) })]
    [TestFixture(new [] { 5.0f, 3.0f, 1.0f }, TypeArgs = new Type[] { typeof(float) })]
    internal class DiagonalMatrixTests<T>
    {
        private const int DiagonalMatrixSize = 3;
        private readonly T[] source;

        public DiagonalMatrixTests(T[] source) => this.source = source;

        [Test]
        public void Set_DifferentIndexes_ThrowMatrixIndexException() => Assert.Throws<MatrixIndexException>(() => new DiagonalMatrix<T>(DiagonalMatrixSize)[0, 1] = source[1], "Indexes does not follow the implementation-side validation rules.");

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        public void SetAndGet_ValidIndexTests(int indexI, int indexJ)
        {
            var matrix = new DiagonalMatrix<T>(DiagonalMatrixSize);

            for (int index = 0; index < DiagonalMatrixSize; index++)
            {
                matrix[index, index] = source[index];
            }

            var actual = matrix[indexI, indexJ];

            Assert.IsFalse(actual.Equals(default(T)));
        }
    }
}
