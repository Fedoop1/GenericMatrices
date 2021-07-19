using System;

namespace GenericMatrices.MatrixEventArgs
{
    public class CellChangeEventArgs<T> : EventArgs
    {
        public CellChangeEventArgs((int i, int j) cellIndex, T oldValue, T newValue) => (this.CellIndex, this.OldValue, this.NewValue) = (cellIndex, oldValue, newValue);

        public (int i, int j) CellIndex { get; }

        public T OldValue { get; }

        public T NewValue { get; }
    }
}
