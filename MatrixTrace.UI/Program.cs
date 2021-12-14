// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Ivan Goncharov">
// Copyright (c) Ivan Goncharov. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MatrixTrace.UI
{
    using System;
    using MatrixTrace.Application;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Console User Interface of MatrixTrace.Application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Start the programm, for working with MatrixTrace.Application.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Enter Number of Rows: ");
            int rowNumb = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Number of Columns: ");
            int columnNumb = Convert.ToInt32(Console.ReadLine());
            var matrix = new Matrix(rowNumb, columnNumb);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IMatrixActions, MatrixActions>();
            var provider = serviceCollection.BuildServiceProvider();
            var service = provider.GetRequiredService<IMatrixActions>();

            service.PrintMatrix(matrix);
            Console.WriteLine("Matrix Trace is: " + service.GetMatrixTrace(matrix));
            Console.WriteLine("Matrix Snake: " + service.GetMatrixSnake(matrix));

            Console.ReadLine();
        }
    }
}
