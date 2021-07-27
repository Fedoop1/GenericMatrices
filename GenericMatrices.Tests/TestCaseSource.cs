using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericMatrices.Matrices;
using NUnit.Framework;

namespace GenericMatrices.Tests
{
    public static class TestCaseSource
    {
        private const int MatrixSize = 3;

        public static IEnumerable<TestCaseData> MatrixTestCases
        {
            get
            {
                yield return new TestCaseData(new SquareMatrix<int>(MatrixSize));
                yield return new TestCaseData(new DiagonalMatrix<int>(MatrixSize));
                yield return new TestCaseData(new SymmetricMatrix<int>(MatrixSize));
            }
        }
    }
}
