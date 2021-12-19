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
            int rowNumb;
            int columnNumb;

            do
            {
                Console.WriteLine("Enter Number of Rows: ");
                int.TryParse(Console.ReadLine(), out rowNumb);
            }
            while (rowNumb <= 0);

            do
            {
                Console.WriteLine("Enter Number of Columns: ");
                int.TryParse(Console.ReadLine(), out columnNumb);
            }
            while (columnNumb <= 0);

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
