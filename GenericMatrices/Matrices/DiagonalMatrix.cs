using GenericMatrices.MatrixExcepions;

namespace GenericMatrices.Matrices
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        private readonly T[] matrixDiagonalValues;

        public DiagonalMatrix(int size)
            : base(size) => this.matrixDiagonalValues = new T[size];

        protected override T GetValue(int i, int j)
        {
            if (i == j)
            {
                return this.matrixDiagonalValues[i];
            }

            return default(T);
        }

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
