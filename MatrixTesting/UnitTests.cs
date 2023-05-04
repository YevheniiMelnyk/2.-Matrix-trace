using ConsoleApp;

namespace MatrixTesting
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void MatrixConstructor_WithCorrectRowsAndColumns()
        {
            int _rows = 4;
            int _columns = 4;

            var matrix = new Matrix(_rows, _columns);

            var matrixCopy = matrix.GetMatrixCopy();
            int matrixCopyRows = matrixCopy.GetLength(0);
            int matrixCopyColumns = matrixCopy.GetLength(1);

            Assert.AreEqual(_rows, matrixCopyRows);
            Assert.AreEqual(_columns, matrixCopyColumns);
            Assert.IsNotNull(matrix);
            Assert.IsNotNull(matrixCopy);
        }

        [TestMethod]
        public void MatrixTrace_CheckCountOfNumbersForSquareMatrix()
        {
            int _rows = 4;
            int _columns = 4;

            var matrix = new Matrix(_rows, _columns);

            Assert.IsTrue(matrix.GetMatrixTrace().Count == 4);
        }

        [TestMethod]
        public void MatrixTrace_CheckCountOfNumbersForRectangleMatrix()
        {
            int _rows = 3;
            int _columns = 4;

            var matrix = new Matrix(_rows, _columns);

            Assert.IsTrue(matrix.GetMatrixTrace().Count == 3);
        }

        [TestMethod]
        public void MatrixTrace_CheckSum()
        {
            int _rows = 2;
            int _columns = 2;

            var matrix = new Matrix(_rows, _columns);
            var matrixCopy = matrix.GetMatrixCopy();
            int matrixCopyRows = matrixCopy.GetLength(0);

            int expectedSumOfMainDiagonal = matrix.GetMatrixTraceSum();

            int actualSum = 0;
            for (int i = 0; i < matrixCopyRows; i++)
            {
                actualSum += matrix.GetMatrixElement(i, i);
            }
            Assert.AreEqual(expectedSumOfMainDiagonal, actualSum);
        }

        [TestMethod]
        public void Matrix_CheckEachNumber()
        {
            int _rows = 4;
            int _columns = 4;
            bool res = true;

            var matrix = new Matrix(_rows, _columns);
            var matrixCopy = matrix.GetMatrixCopy();
            int matrixCopyRows = matrixCopy.GetLength(0);
            int matrixCopyColumns = matrixCopy.GetLength(1);

            for (int i = 0; i < matrixCopyRows; i++)
            {
                for (int j = 0; j < matrixCopyColumns; j++)
                {
                    if (matrixCopy[i, j] < 1 || matrixCopy[i, j] > 100)
                    {
                        res = false;
                    }
                }
            }
            Assert.IsTrue(res);
        }
    }
}