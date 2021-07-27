using System;

namespace GenericMatrices.Matrices
{
    /// <summary>
    /// Class that represent the symmetric matrix where values at lower half symmetric to values at upper half. Example: cell[i, j] = cell[j, i].
    /// </summary>
    /// <typeparam name="T">Type of data in matrix.</typeparam>
    /// <seealso cref="GenericMatrices.Matrices.Matrix&lt;T&gt;" />
    public class SymmetricMatrix<T> : Matrix<T>
    {
        private readonly T[][] lowerHalfOfMatix;

        /// <summary>
        /// Initializes a new instance of the <see cref="SymmetricMatrix{T}"/> class and set the matrix size.
        /// </summary>
        /// <param name="size">The matrix size.</param>
        /// <exception cref="ArgumentException">Throws when size lower than zero.</exception>
        public SymmetricMatrix(int size)
                : base(size) => this.lowerHalfOfMatix = GenerateLowerHalfOfMatrix(size);

        /// <inheritdoc/>
        protected override T GetValue(int i, int j)
        {
            if (j > i)
            {
                Swap(ref j, ref i);
            }

            return this.lowerHalfOfMatix[i][j];
        }

        /// <inheritdoc/>
        protected override bool IsValidCustomRules(int i, int j) => i < this.Size && j < this.Size;

        /// <inheritdoc/>
        protected override void SetValue(int i, int j, T value)
        {
            if (j > i)
            {
                Swap(ref j, ref i);
            }

            this.lowerHalfOfMatix[i][j] = value;
        }

        private static void Swap(ref int a, ref int b) => (a, b) = (b, a);

        private static T[][] GenerateLowerHalfOfMatrix(int size)
        {
            var result = new T[size][];

            for (int arrayIndex = 0; arrayIndex < size; arrayIndex++)
            {
                result[arrayIndex] = new T[arrayIndex + 1];
            }

            return result;
        }
    }
}
