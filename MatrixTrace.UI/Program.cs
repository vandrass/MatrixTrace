﻿// -----------------------------------------------------------------------
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

            var provider = serviceCollection.BuildServiceProvider();

            Matrix matrix = new Matrix(columnNumb, rowNumb);

            Console.ReadLine();
        }
    }
}
