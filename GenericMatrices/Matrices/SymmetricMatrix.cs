using System;

namespace GenericMatrices.Matrices
{
    public class SymmetricMatrix<T> : Matrix<T>
    {
        private readonly T[][] lowerHalfOfMatix;

        public SymmetricMatrix(int size)
                : base(size) => this.lowerHalfOfMatix = GenerateLowerHalfOfMatrix(size);

        protected override T GetValue(int i, int j)
        {
            if (j > i)
            {
                Swap(ref j, ref i);
            }

            return this.lowerHalfOfMatix[i][j];
        }

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
