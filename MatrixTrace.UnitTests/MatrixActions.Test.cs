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

        [TestMethod]
        public void Test()
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
    }
}
