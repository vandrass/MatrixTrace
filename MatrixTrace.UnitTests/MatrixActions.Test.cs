// -----------------------------------------------------------------------
// <copyright file="MatrixActionsTests.Test.cs" company="Ivan Goncharov">
// Copyright (c) Ivan Goncharov. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MatrixTrace.UnitTests
{
    using MatrixTrace.Application;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit Tests for MatrixActions class methods: GetMatrixTrace,
    /// GetMAtrixSnake.
    /// </summary>
    [TestClass]
    public class MatrixActionsTests
    {
        private readonly ServiceCollection _serviceCollection = new ServiceCollection();
        private ServiceProvider _provider;
        private IMatrixActions _service;

        /// <summary>
        /// Method build service by IMatrixActions and MatrixActions, for using by tests.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _serviceCollection.AddScoped<IMatrixActions, MatrixActions>();
            _provider = _serviceCollection.BuildServiceProvider();
            _service = _provider.GetRequiredService<IMatrixActions>();
        }

        /// <summary>
        /// Input matrix 3x4 size, and get right matrix trace,
        /// In Our variant is: 9.
        /// </summary>
        [TestMethod]
        public void GetMatrixTrace_InputMatrixThreeByFour_MatrixTrace()
        {
            // Arrange
            int[,] matrix = { { 1, 2, 3, 4 }, { 1, 2, 3, 4 }, { 4, 5, 6, 7 } };
            Matrix inputMatrix = new Matrix(matrix);
            int expected = 9;

            // Act
            var actual = _service.GetMatrixTrace(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 3x4 size, and get snake of matrix,
        /// numbers from beginnig to center of matrix.
        /// </summary>
        [TestMethod]
        public void GetSnake_InputMatrixThreeByThree_StringOfMatrixSnake()
        {
            // Arrange
            int[,] matrix = { { 1, 2, 3, 4 }, { 1, 2, 3, 4 }, { 4, 5, 6, 7 } };
            Matrix inputMatrix = new Matrix(matrix);
            const string expected = "1 2 3 4 4 7 6 5 4 1 2 3 ";

            // Act
            var actual = _service.GetMatrixSnake(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
