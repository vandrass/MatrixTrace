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

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter Number of Rows: ");
            int columnNumb = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Number of Columns: ");
            int rowNumb = Convert.ToInt32(Console.ReadLine());

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped<IMatrix, MatrixActions>();

            var provider = serviceCollection.BuildServiceProvider();

            IMatrix service = provider.GetRequiredService<IMatrix>();

            service.FillMatrix(rowNumb, columnNumb);

            service.PrintMatrix();

            Console.WriteLine(service.MatrixTraceSearch());

            service.PrintMatrixSnake();

            Console.ReadLine();
        }
    }
}
