using System;
using System.Data.Common;
using System.Text;

namespace ConsoleApp
{
    public class Matrix
    {
        private readonly int[,] _matrixArray;
        private readonly int _columns;
        private readonly int _rows;

        public Matrix(int numberOfrows, int numberOfColumns)
        {
            if(numberOfrows <= 0 || numberOfColumns <= 0)
            {
                throw new ArgumentException("The matrix dimensions specified are incorrect: the number of rows and columns should be greater than zero.");
            }

            _rows = numberOfrows;
            _columns = numberOfColumns;
            _matrixArray = new int[numberOfrows, numberOfColumns];

            Random random = new();

            for (int i = 0; i < numberOfrows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    int randomNumber = random.Next(0, 101);
                    _matrixArray.SetValue(randomNumber, i, j);
                }
            }
        }

        public void PrintMatrix()
        {
            Console.WriteLine();
            for (int i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
                {
                    int value = _matrixArray[i, j];
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write(value.ToString().PadLeft(4, ' '));

                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(value.ToString().PadLeft(4, ' '));
                    }
                }
                Console.WriteLine();
            }
        }

        public int[,] GetMatrixCopy()
        {
            return (int[,])_matrixArray.Clone();
        }

        public int GetMatrixTraceSum()
        {
            int sum = 0;
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    if (i == j)
                    {
                        sum += _matrixArray[i, j];
                    }
                }
            }
            return sum;
        }

        public List<int> GetMatrixTrace()
        {
            List<int> matrixTrace = new();

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    if (i == j)
                    {
                        matrixTrace.Add(_matrixArray[i, j]);
                    }
                }
            }
            return matrixTrace;
        }

        public int GetMatrixElement(int row, int column)
        {
            if (row < 0 || row >= _rows || column < 0 || column >= _columns)
            {
                throw new ArgumentOutOfRangeException("Argument is out of the valid range. The parameters row and/or column are out of the matrix dimensions.");
            }
            return _matrixArray[row, column];
        }

        public void PrintSumOfMatrixTrace()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(string.Concat("Matrix trace: ", GetMatrixTraceSum()));
            Console.ResetColor();
            Console.WriteLine();
        }

        public void PrintMatrixTrace()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(string.Join(", ", GetMatrixTrace()));
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}