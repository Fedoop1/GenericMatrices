using System;
using GenericMatrices.Matrices;

namespace GenericMatrices.MatrixEventArgs
{
    /// <summary>
    /// Class storage which store information about changed cell in <see cref="Matrix{T}"/>.
    /// </summary>
    /// <typeparam name="T">Type of cell data.</typeparam>
    /// <seealso cref="System.EventArgs" />
    public class CellChangeEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CellChangeEventArgs{T}"/> class and set event details.
        /// </summary>
        /// <param name="cellIndex">Index of changed cell.</param>
        /// <param name="oldValue">The old value of changed cell.</param>
        /// <param name="newValue">The new value of changed cell.</param>
        public CellChangeEventArgs((int i, int j) cellIndex, T oldValue, T newValue) => (this.CellIndex, this.OldValue, this.NewValue) = (cellIndex, oldValue, newValue);

        /// <summary>
        /// Gets the index of the changed cell.
        /// </summary>
        /// <value>
        /// The index of the changed cell.
        /// </value>
        public (int i, int j) CellIndex { get; }

        /// <summary>
        /// Gets the old value of changed cell.
        /// </summary>
        /// <value>
        /// The old value of changed cell.
        /// </value>
        public T OldValue { get; }

        /// <summary>
        /// Gets the new value of changed cell.
        /// </summary>
        /// <value>
        /// The new value of changed cell.
        /// </value>
        public T NewValue { get; }
    }
}
