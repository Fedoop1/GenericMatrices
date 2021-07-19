using System;
using System.Collections;
using System.Collections.Generic;
using GenericMatrices.MatrixEventArgs;
using GenericMatrices.MatrixExcepions;

namespace GenericMatrices.Matrices
{
    // TODO: Add XML documentation.
    public abstract class Matrix<T> : IEnumerable<T>, IEnumerable
    {
        protected Matrix(int size) => this.Size = size > 0 ? size : throw new ArgumentException("Matrix size can't be lower than zero.");

        public event EventHandler<CellChangeEventArgs<T>> CellChange;

        public int Size { get; private set; }

        public T this[int i, int j]
        {
            get
            {
                if (!this.IsValidIndex(i, j))
                {
                    throw new MatrixIndexException("Matrix indexes can't be greater than matrix size and lower than zero.");
                }

                return this.GetValue(i, j);
            }

            set
            {
                if (!this.IsValidIndex(i, j))
                {
                    throw new MatrixIndexException("Matrix indexes can't be greater than matrix size and lower than zero.");
                }

                var oldValue = this.GetValue(i, j);
                this.SetValue(i, j, value);

                this.OnCellChange(new CellChangeEventArgs<T>((i, j), oldValue, value));
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int indexI = 0; indexI < this.Size; indexI++)
            {
                for (int indexJ = 0; indexJ < this.Size; indexJ++)
                {
                    yield return this[indexI, indexJ];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        protected virtual void OnCellChange(CellChangeEventArgs<T> eventArgs)
        {
            this.CellChange?.Invoke(this, eventArgs);
        }

        protected abstract T GetValue(int i, int j);

        protected abstract void SetValue(int i, int j, T value);

        protected bool IsValidIndex(int i, int j) => (i >= 0 && i < this.Size) && (j >= 0 && j < this.Size);
    }
}
