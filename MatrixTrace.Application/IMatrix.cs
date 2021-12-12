// -----------------------------------------------------------------------
// <copyright file="IMatrix.cs" company="Ivan Goncharov">
// Copyright (c) Ivan Goncharov. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MatrixTrace.Application
{
    public interface IMatrix
    {
        void FillMatrix(int rowsNumber, int columnNumber);

        void PrintMatrix();

        int MatrixTraceSearch();

        void PrintMatrixSnake();
    }
}
