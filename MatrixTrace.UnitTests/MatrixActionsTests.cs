// -----------------------------------------------------------------------
// <copyright file="MatrixActionsTests.cs" company="Ivan Goncharov">
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
        private readonly ServiceCollection _serviceCollection = new ();
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
        /// Input matrix 2x2 size, and get right matrix trace,
        /// In Our variant is: 9.
        /// </summary>
        [TestMethod]
        public void GetMatrixTrace_InputMatrixTwoByTwo_MatrixTrace()
        {
            // Arrange
            int[,] matrix = { { 1, 2 }, { 1, 2 } };
            var inputMatrix = new Matrix(matrix);
            int expected = 3;

            // Act
            var actual = _service.GetMatrixTrace(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 1x1 size, and get right matrix trace,
        /// In Our variant is: 1.
        /// </summary>
        [TestMethod]
        public void GetMatrixTrace_InputMatrixOneByOne_MatrixTrace()
        {
            // Arrange
            int[,] matrix = { { 1 } };
            var inputMatrix = new Matrix(matrix);
            int expected = 1;

            // Act
            var actual = _service.GetMatrixTrace(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 3x3 size, and get right matrix trace,
        /// In Our variant is: 9.
        /// </summary>
        [TestMethod]
        public void GetMatrixTrace_InputMatrixThreeByThree_MatrixTrace()
        {
            // Arrange
            int[,] matrix = { { 1, 2, 3 }, { 1, 2, 3 }, { 4, 5, 6 } };
            var inputMatrix = new Matrix(matrix);
            int expected = 9;

            // Act
            var actual = _service.GetMatrixTrace(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
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
            var inputMatrix = new Matrix(matrix);
            int expected = 9;

            // Act
            var actual = _service.GetMatrixTrace(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 4x4 size, and get right matrix trace,
        /// In Our variant is: 16.
        /// </summary>
        [TestMethod]
        public void GetMatrixTrace_InputMatrixFourByFour_MatrixTrace()
        {
            // Arrange
            int[,] matrix = { { 1, 2, 3, 4 }, { 1, 2, 3, 4 }, { 4, 5, 6, 7 }, { 5, 6, 7, 7 } };
            var inputMatrix = new Matrix(matrix);
            int expected = 16;

            // Act
            var actual = _service.GetMatrixTrace(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 3x5 size, and get right matrix trace,
        /// In Our variant is: 14.
        /// </summary>
        [TestMethod]
        public void GetMatrixTrace_InputMatrixThreeByFive_MatrixTrace()
        {
            // Arrange
            int[,] matrix = { { 3, 2, 3, 4, 9 }, { 1, 5, 3, 4, 8 }, { 4, 5, 6, 7, 4 } };
            var inputMatrix = new Matrix(matrix);
            int expected = 14;

            // Act
            var actual = _service.GetMatrixTrace(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 5x3 size, and get right matrix trace,
        /// In Our variant is: 14.
        /// </summary>
        [TestMethod]
        public void GetMatrixTrace_InputMatrixFiveByThree_MatrixTrace()
        {
            // Arrange
            int[,] matrix = { { 3, 2, 3 }, { 1, 5, 3 }, { 4, 5, 6 }, { 6, 6, 6 }, { 5, 3, 1 } };
            var inputMatrix = new Matrix(matrix);
            int expected = 14;

            // Act
            var actual = _service.GetMatrixTrace(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 5x1 size, and get right matrix trace,
        /// In Our variant is: 3.
        /// </summary>
        [TestMethod]
        public void GetMatrixTrace_InputMatrixFiveByOne_MatrixTrace()
        {
            // Arrange
            int[,] matrix = { { 3 }, { 1 }, { 4 }, { 6 }, { 5 } };
            var inputMatrix = new Matrix(matrix);
            int expected = 3;

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
            var inputMatrix = new Matrix(matrix);
            const string expected = "1 2 3 4 4 7 6 5 4 1 2 3 ";

            // Act
            var actual = _service.GetMatrixSnake(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 1x1 size, and get snake of matrix,
        /// is a one number.
        /// </summary>
        [TestMethod]
        public void GetSnake_InputMatrixOneByOne_StringOfMatrixSnake()
        {
            // Arrange
            int[,] matrix = { { 1 } };
            var inputMatrix = new Matrix(matrix);
            const string expected = "1 ";

            // Act
            var actual = _service.GetMatrixSnake(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 1x2 size, and get snake of matrix,
        /// numbers from beginnig to center of matrix.
        /// </summary>
        [TestMethod]
        public void GetSnake_InputMatrixOneByTwo_StringOfMatrixSnake()
        {
            // Arrange
            int[,] matrix = { { 1, 2 } };
            var inputMatrix = new Matrix(matrix);
            const string expected = "1 2 ";

            // Act
            var actual = _service.GetMatrixSnake(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 2x1 size, and get snake of matrix,
        /// numbers from beginnig to center of matrix.
        /// </summary>
        [TestMethod]
        public void GetSnake_InputMatrixTwoByOne_StringOfMatrixSnake()
        {
            // Arrange
            int[,] matrix = { { 1 }, { 1 } };
            var inputMatrix = new Matrix(matrix);
            const string expected = "1 1 ";

            // Act
            var actual = _service.GetMatrixSnake(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 2x2 size, and get snake of matrix,
        /// numbers from beginnig to center of matrix.
        /// </summary>
        [TestMethod]
        public void GetSnake_InputMatrixTwoByTwo_StringOfMatrixSnake()
        {
            // Arrange
            int[,] matrix = { { 1, 2 }, { 1, 2 } };
            var inputMatrix = new Matrix(matrix);
            const string expected = "1 2 2 1 ";

            // Act
            var actual = _service.GetMatrixSnake(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 3x2 size, and get snake of matrix,
        /// numbers from beginnig to center of matrix.
        /// </summary>
        [TestMethod]
        public void GetSnake_InputMatrixThreeByTwo_StringOfMatrixSnake()
        {
            // Arrange
            int[,] matrix = { { 1, 1 }, { 2, 2 }, { 3, 3 } };
            var inputMatrix = new Matrix(matrix);
            const string expected = "1 1 2 3 3 2 ";

            // Act
            var actual = _service.GetMatrixSnake(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 4x4 size, and get snake of matrix,
        /// numbers from beginnig to center of matrix.
        /// </summary>
        [TestMethod]
        public void GetSnake_InputMatrixFourByFour_StringOfMatrixSnake()
        {
            // Arrange
            int[,] matrix = { { 1, 1, 1, 1 }, { 2, 2, 2, 2 }, { 3, 3, 3, 3 }, { 4, 4, 4, 4 } };
            var inputMatrix = new Matrix(matrix);
            const string expected = "1 1 1 1 2 3 4 4 4 4 3 2 2 2 3 3 ";

            // Act
            var actual = _service.GetMatrixSnake(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 7x5 size, and get snake of matrix,
        /// numbers from beginnig to center of matrix.
        /// </summary>
        [TestMethod]
        public void GetSnake_InputMatrixSevenByFive_StringOfMatrixSnake()
        {
            // Arrange
            int[,] matrix = { { 1, 1, 1, 1, 1 }, { 2, 2, 2, 2, 2 }, { 3, 3, 3, 3, 3 }, { 4, 4, 4, 4, 4 }, { 5, 5, 5, 5, 5 }, { 6, 6, 6, 6, 6 }, { 7, 7, 7, 7, 7 } };
            var inputMatrix = new Matrix(matrix);
            const string expected = "1 1 1 1 1 2 3 4 5 6 7 7 7 7 7 6 5 4 3 2 2 2 2 3 4 5 6 6 6 5 4 3 3 4 5 ";

            // Act
            var actual = _service.GetMatrixSnake(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Input matrix 5x7 size, and get snake of matrix,
        /// numbers from beginnig to center of matrix.
        /// </summary>
        [TestMethod]
        public void GetSnake_InputMatrixFiveBySeven_StringOfMatrixSnake()
        {
            // Arrange
            int[,] matrix = { { 1, 1, 1, 1, 1, 1, 1 }, { 2, 2, 2, 2, 2, 2, 2 }, { 3, 3, 3, 3, 3, 3, 3 }, { 4, 4, 4, 4, 4, 4, 4 }, { 5, 5, 5, 5, 5, 5, 5 } };
            var inputMatrix = new Matrix(matrix);
            const string expected = "1 1 1 1 1 1 1 2 3 4 5 5 5 5 5 5 5 4 3 2 2 2 2 2 2 3 4 4 4 4 4 3 3 3 3 ";

            // Act
            var actual = _service.GetMatrixSnake(inputMatrix);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
