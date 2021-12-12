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
            Matrix matrix = new Matrix(rowNumb, columnNumb);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IMatrixActions, MatrixActions>();
            var provider = serviceCollection.BuildServiceProvider();
            var service = provider.GetRequiredService<IMatrixActions>();

            service.PrintMatrix(matrix);
            Console.WriteLine(service.GetMatrixTrace(matrix));
            Console.WriteLine(service.GetMatrixSnake(matrix));

            Console.ReadLine();
        }
    }
}
