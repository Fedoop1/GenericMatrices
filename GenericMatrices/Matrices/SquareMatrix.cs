using System;

namespace GenericMatrices.Matrices
{
    /// <summary>
    /// Class that represent the square matrix where matrix width equals matrix height (NxN).
    /// </summary>
    /// <typeparam name="T">Type of data in matrix.</typeparam>
    /// <seealso cref="GenericMatrices.Matrices.Matrix&lt;T&gt;" />
    public class SquareMatrix<T> : Matrix<T>
    {
        private readonly T[,] matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareMatrix{T}"/> class and set the matrix size.
        /// </summary>
        /// <param name="size">The matrix size.</param>
        /// <exception cref="ArgumentException">Throws when size lower than zero.</exception>
        public SquareMatrix(int size)
            : base(size) => this.matrix = new T[size, size];

        /// <inheritdoc/>
        protected override T GetValue(int i, int j) => this.matrix[i, j];

        /// <inheritdoc/>
        protected override void SetValue(int i, int j, T value) => this.matrix[i, j] = value;
    }
}
