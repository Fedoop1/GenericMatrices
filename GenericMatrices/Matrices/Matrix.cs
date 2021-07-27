using System;
using System.Collections;
using System.Collections.Generic;
using GenericMatrices.MatrixEventArgs;
using GenericMatrices.MatrixExcepions;

namespace GenericMatrices.Matrices
{
    /// <summary>
    /// Class which is the base class for all square matrices and provides common abilities.
    /// </summary>
    /// <typeparam name="T">Type of data in matrix.</typeparam>
    /// <seealso cref="System.Collections.Generic.IEnumerable&lt;T&gt;" />
    /// <seealso cref="System.Collections.IEnumerable" />
    public abstract class Matrix<T> : IEnumerable<T>, IEnumerable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix{T}"/> class and set matrix size.
        /// </summary>
        /// <param name="size">The matrix size.</param>
        /// <exception cref="System.ArgumentException">Throws when matrix size lower than zero.</exception>
        protected Matrix(int size) => this.Size = size > 0 ? size : throw new ArgumentException("Matrix size can't be lower than zero.");

        /// <summary>
        /// Occurs when matrix cell change.
        /// </summary>
        public event EventHandler<CellChangeEventArgs<T>> CellChange;

        /// <summary>
        /// Gets the matrix size.
        /// </summary>
        /// <value>
        /// The matrix size value.
        /// </value>
        public int Size { get; private set; }

        /// <summary>
        /// Gets or sets the matrix cell value in specific cell i, j.
        /// </summary>
        /// <value>
        /// <see cref="T"/> value.
        /// </value>
        /// <param name="i">Matrix row.</param>
        /// <param name="j">Matrix column.</param>
        /// <returns>The matrix cell value</returns>
        /// <exception cref="MatrixIndexException">
        /// Throws when index greater than matrix size or lower than zero.
        /// or
        /// Throws when index does not follow the implementation-side validation rules.
        /// </exception>
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

                if (!this.IsValidCustomRules(i, j))
                {
                    throw new MatrixIndexException("Indexes does not follow the implementation-side validation rules.");
                }

                var oldValue = this.GetValue(i, j);
                this.SetValue(i, j, value);

                this.OnCellChange(new CellChangeEventArgs<T>((i, j), oldValue, value));
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
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

        /// <summary>
        /// Raises the <see cref="E:CellChange" /> event when cell was changed.
        /// </summary>
        /// <param name="eventArgs">The <see cref="CellChangeEventArgs{T}"/> instance containing the event data.</param>
        protected virtual void OnCellChange(CellChangeEventArgs<T> eventArgs)
        {
            this.CellChange?.Invoke(this, eventArgs);
        }

        /// <summary>
        /// Method which defines getter access logic to matrix cells.
        /// </summary>
        /// <param name="i">Matrix row.</param>
        /// <param name="j">Matrix column.</param>
        /// <returns>The value of specific cell.</returns>
        protected abstract T GetValue(int i, int j);

        /// <summary>
        /// Method which defines setter access logic to matrix cells.
        /// </summary>
        /// <param name="i">Matrix row.</param>
        /// <param name="j">Matrix column.</param>
        /// <param name="value">Value to set in specific cell.</param>
        protected abstract void SetValue(int i, int j, T value);

        /// <summary>
        /// Determines whether indexes are valid in according to a special condition.
        /// </summary>
        /// <param name="i">Matrix row.</param>
        /// <param name="j">Matrix column.</param>
        /// <returns>
        ///   <c>true</c> if indexes are valid; otherwise, <c>false</c>.
        /// </returns>
        protected abstract bool IsValidCustomRules(int i, int j);

        private bool IsValidIndex(int i, int j) => (i >= 0 && i < this.Size) && (j >= 0 && j < this.Size);
    }
}
