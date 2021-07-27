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

        /// <inheritdoc/>
        protected override void SetValue(int i, int j, T value) => this.matrixDiagonalValues[i] = value;

        /// <summary>
        /// Determines whether indexes are valid in according to a special condition.
        /// </summary>
        /// <param name="i">Matrix row.</param>
        /// <param name="j">Matrix column.</param>
        /// <remarks>Diagonal matrix must have default values in all cells except main diagonal.</remarks>
        /// <returns>
        /// <c>true</c> if indexes are the same; otherwise, <c>false</c>.
        /// </returns>
        protected override bool IsValidCustomRules(int i, int j) => i == j;
    }
}
