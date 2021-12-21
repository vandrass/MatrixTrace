namespace MatrixTrace.Application
{
    /// <summary>
    /// interface for implementing actions on a matrix.
    /// </summary>
    public interface IMatrixActions
    {
        /// <summary>
        /// Matrix Output by rows and columns.
        /// </summary>
        /// <param name="matrix">Matrix object For output.</param>
        void PrintMatrix(Matrix matrix);

        /// <summary>
        /// Should Calculate Matrix Trace and will Return an Answer.
        /// </summary>
        /// <param name="matrix">Matrix object for calculating.</param>
        /// <returns>matrix trace.</returns>
        int GetMatrixTrace(Matrix matrix);

        /// <summary>
        /// Must to build a snake string by input matrix.
        /// </summary>
        /// <param name="matrix">Matrix object for snake building. </param>
        /// <returns>string with finished snake from input matrix.</returns>
        string GetMatrixSnake(Matrix matrix);
    }
}
