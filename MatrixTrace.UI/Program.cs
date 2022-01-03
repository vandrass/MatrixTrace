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
            var rowNumb = InputRowsOrColumns();

            Console.WriteLine("Enter Number of Columns: ");
            var columnNumb = InputRowsOrColumns();

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

        private static int InputRowsOrColumns()
        {
            int number;
            do
            {
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    if (number > 25000)
                    {
                        Console.WriteLine("Enter the number no more than 25000: ");
                        number = 0;
                    }
                    else if (number <= 0)
                    {
                        Console.WriteLine("Wrong input value! Enter the number greater than zero: ");
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input value! Enter the numbers only and no more than 25000: ");
                }
            }
            while (number <= 0);

            return number;
        }
    }
}
