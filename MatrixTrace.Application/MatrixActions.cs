// -----------------------------------------------------------------------
// <copyright file="MatrixActions.cs" company="Ivan Goncharov">
// Copyright (c) Ivan Goncharov. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MatrixTrace.Application
{
    using System;
    using System.Text;

    public class MatrixActions : IMatrixActions
    {
        public int GetMatrixTrace(Matrix matrix)
        {
            int matrixTrace = 0;
            for (int i = 0; i < matrix.GetMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetMatrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        matrixTrace += matrix.GetMatrix[i, j];
                    }
                }
            }

            return matrixTrace;
        }

        public void PrintMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.GetMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetMatrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write($"{matrix.GetMatrix[i, j]} ", ConsoleColor.Red);

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
            }
        }

        public string GetMatrixSnake(Matrix matrix)
        {
            int hightRowIndex = matrix.GetMatrix.GetLength(0) - 1;
            int hightColumnIndex = matrix.GetMatrix.GetLength(1) - 1;
            int lowRowIndex = 0;
            int lowColumnIndex = 0;
            int interationCounter = GetInterationCounter(matrix.GetMatrix.GetLength(0), matrix.GetMatrix.GetLength(0));
            int i, j;
            StringBuilder snakeString = new StringBuilder();

            while (interationCounter != 0)
            {
                for (i = lowRowIndex, j = lowColumnIndex; j <= hightColumnIndex; j++)
                {
                    snakeString.Append(matrix.GetMatrix[i, j] + " ");
                }

                for (i = lowRowIndex + 1, j = hightColumnIndex; i <= hightRowIndex; i++)
                {
                    snakeString.Append(matrix.GetMatrix[i, j] + " ");
                }

                for (i = hightRowIndex, j = hightColumnIndex - 1; j >= lowColumnIndex && hightRowIndex > lowRowIndex; j--)
                {
                    snakeString.Append(matrix.GetMatrix[i, j] + " ");
                }

                for (i = hightRowIndex - 1, j = lowColumnIndex; i > lowRowIndex && hightColumnIndex > lowColumnIndex; i--)
                {
                    snakeString.Append(matrix.GetMatrix[i, j] + " ");
                }

                hightRowIndex--;
                hightColumnIndex--;
                lowRowIndex++;
                lowColumnIndex++;
                interationCounter--;
            }

            return snakeString.ToString();
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
