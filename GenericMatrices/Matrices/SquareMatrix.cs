using System;

namespace GenericMatrices.Matrices
{
    public class SquareMatrix<T> : Matrix<T>
    {
        private readonly T[,] matrix;

        public SquareMatrix(int size)
            : base(size) => this.matrix = new T[size, size];

        protected override T GetValue(int i, int j) => this.matrix[i, j];

        protected override void SetValue(int i, int j, T value) => this.matrix[i, j] = value;
    }
}
