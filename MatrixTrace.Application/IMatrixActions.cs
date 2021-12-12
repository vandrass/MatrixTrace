// -----------------------------------------------------------------------
// <copyright file="IMatrixActions.cs" company="Ivan Goncharov">
// Copyright (c) Ivan Goncharov. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MatrixTrace.Application
{
    public interface IMatrixActions
    {
        void PrintMatrix(Matrix matrix);

        int GetMatrixTrace(Matrix matrix);

        string GetMatrixSnake(Matrix matrix);
    }
}
