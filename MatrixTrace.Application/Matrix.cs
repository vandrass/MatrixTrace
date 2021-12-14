﻿// -----------------------------------------------------------------------
// <copyright file="Matrix.cs" company="Ivan Goncharov">
// Copyright (c) Ivan Goncharov. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MatrixTrace.Application
{
    using System;

    /// <summary>
    /// Matrix object, that build random matrix by input rows and columns number.
    /// And can to receive a ready matrix (for tests using).
    /// MinRandValue and MaxRandValue - interval for random numbers.
    /// </summary>
    public class Matrix
    {
        private const int MinRandValue = 1;
        private const int MaxRandValue = 9;
        private int[,] _matrix;

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class by ready matrix.
        /// </summary>
        /// <param name="matrix">multidimensional int array.</param>
        public Matrix(int[,] matrix)
        {
            _matrix = matrix;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="rowsNumber">number of matrix rows.</param>
        /// <param name="columnNumber">number of matrix columns.</param>
        public Matrix(int rowsNumber, int columnNumber)
        {
            FillMatrix(rowsNumber, columnNumber);
        }

        /// <summary>
        /// Gets matrix.
        /// </summary>
        public int[,] GetMatrix
        {
            get
            {
                return _matrix;
            }
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
