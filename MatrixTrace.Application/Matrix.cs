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

        public int[,] GetMatrix
        {
            get
            {
                return _matrix;
            }
        }

        public Matrix(int[,] matrix)
        {
            _matrix = matrix;
        }

        public Matrix(int rowsNumber, int columnNumber)
        {
            FillMatrix(rowsNumber, columnNumber);
        }

        private void FillMatrix(int rowsNumber, int columnNumber)
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
    }
}
