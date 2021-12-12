// -----------------------------------------------------------------------
// <copyright file="MatrixActions.cs" company="Ivan Goncharov">
// Copyright (c) Ivan Goncharov. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MatrixTrace.Application
{
    using System;

    public class MatrixActions : IMatrix
    {
        private const int MinRandValue = 1;
        private const int MaxRandValue = 9;
        private int[,] _matrix;

        public void FillMatrix(int rowsNumber, int columnNumber)
        {
            _matrix = new int[rowsNumber, columnNumber];
            var rand = new Random();
            for (int i = 0; i < rowsNumber; i++)
            {
                for (int j = 0; j < columnNumber; j++)
                {
                    _matrix[i, j] = rand.Next(MinRandValue, MaxRandValue);
                }
            }
        }

        public int MatrixTraceSearch()
        {
            int matrixTrace = 0;
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        matrixTrace += _matrix[i, j];
                    }
                }
            }

            return matrixTrace;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write($"{_matrix[i, j]} ", ConsoleColor.Red);

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
            }
        }

        public void PrintMatrixSnake()
        {
            int hightRowIndex = _matrix.GetLength(0) - 1;
            int hightColumnIndex = _matrix.GetLength(1) - 1;
            int lowRowIndex = 0;
            int lowColumnIndex = 0;
            int interationCounter = GetInterationCounter(_matrix.GetLength(0), _matrix.GetLength(0));
            int i, j;

            while (interationCounter != 0)
            {
                for (i = lowRowIndex, j = lowColumnIndex; j <= hightColumnIndex; j++)
                {
                    Console.Write(_matrix[i, j] + " ");
                }

                for (i = lowRowIndex + 1, j = hightColumnIndex; i <= hightRowIndex; i++)
                {
                    Console.Write(_matrix[i, j] + " ");
                }

                for (i = hightRowIndex, j = hightColumnIndex - 1; j >= lowColumnIndex; j--)
                {
                    Console.Write(_matrix[i, j] + " ");
                }

                for (i = hightRowIndex - 1, j = lowColumnIndex; i > lowRowIndex; i--)
                {
                    Console.Write(_matrix[i, j] + " ");
                }

                hightRowIndex--;
                hightColumnIndex--;
                lowRowIndex++;
                lowColumnIndex++;
                interationCounter--;
            }
        }

        private int GetInterationCounter(int rows, int columns)
        {
            if (rows < columns)
            {
                if (rows % 2 == 0)
                {
                   return rows / 2;
                }

                return (rows + 1) / 2;
            }
            else
            {
                if (rows % 2 == 0)
                {
                    return columns / 2;
                }

                return (columns + 1) / 2;
            }
        }
    }
}
