// -----------------------------------------------------------------------
// <copyright file="Matrix.cs" company="Ivan Goncharov">
// Copyright (c) Ivan Goncharov. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MatrixTrace.Application
{
    using System;

    public class Matrix
    {
        private const int MinRandValue = 1;
        private const int MaxRandValue = 9;
        private int[,] _matrix;
        private int _matrixTrace = 0;

        public int MatrixTrace
        {
            get
            {
                return _matrixTrace;
            }
        }

        public Matrix(int rowsNumber, int columnNumber)
        {
            _matrix = new int[rowsNumber, columnNumber];
            var rand = new Random();
            for (int i = 0; i < rowsNumber; i++)
            {
                for (int j = 0; j < columnNumber; j++)
                {
                    _matrix[i, j] = rand.Next(MinRandValue, MaxRandValue);

                    if (i == j)
                    {
                        _matrixTrace += _matrix[i, j];
                    }
                }
            }
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
    }
}
