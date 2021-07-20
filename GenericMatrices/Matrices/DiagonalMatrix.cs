using System;
using GenericMatrices.MatrixExcepions;

namespace GenericMatrices.Matrices
{
    /// <summary>
    /// Class that represent diagonal matrix where all elements except main diagonal equals default of <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T">Type of data in matrix.</typeparam>
    /// <seealso cref="GenericMatrices.Matrices.Matrix&lt;T&gt;" />
    public class DiagonalMatrix<T> : Matrix<T>
    {
        private readonly T[] matrixDiagonalValues;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagonalMatrix{T}"/> class and set the matrix size.
        /// </summary>
        /// <param name="size">The matrix size.</param>
        /// <exception cref="ArgumentException">Throws when size lower than zero.</exception>
        public DiagonalMatrix(int size)
            : base(size) => this.matrixDiagonalValues = new T[size];

        /// <inheritdoc/>
        protected override T GetValue(int i, int j)
        {
            if (i == j)
            {
                return this.matrixDiagonalValues[i];
            }

            return default(T);
        }

        /// <summary>
        /// Method which defines setter access logic to matrix cells.
        /// </summary>
        /// <param name="i">Matrix row.</param>
        /// <param name="j">Matrix column.</param>
        /// <param name="value">Value to set in specific cell.</param>
        /// <exception cref="GenericMatrices.MatrixExcepions.MatrixIndexException">Throws when trying to set value outside of main diagonal.</exception>
        protected override void SetValue(int i, int j, T value)
        {
            if (i != j)
            {
                throw new MatrixIndexException("Diagonal matrix doesn't support the ability to set elements outside the main diagonal.");
            }

            this.matrixDiagonalValues[i] = value;
        }
    }
}
