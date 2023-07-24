// Program.cs

using System;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Интерфейс вызова программы П1 (И1)
            Console.WriteLine("Программа П1: Сложение матриц");
            Console.Write("Введите путь к файлу F0: ");
            string filePath = Console.ReadLine();

            MatrixOperations matrixOps = new MatrixOperations();
            matrixOps.AddMatricesFromFile(filePath);

            Console.WriteLine("Матрицы сложены. Результат сохранен в файле F1.");
        }
    }
}
