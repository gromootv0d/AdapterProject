// Program.cs

using System;
using System.Text;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Генерация данных для матриц А и В и запись их в файл F2
            Console.WriteLine("Программа П2: Генерация данных матриц и запись их в файл F2");

            MatrixGenerator matrixGenerator = new MatrixGenerator();
            matrixGenerator.GenerateAndSaveMatrices("../../../F2.txt");

            Console.WriteLine("Данные матриц А и В записаны в файл F2.");

            // Использование адаптера для вызова программы П1 (И1)
            Console.WriteLine("Вызов программы П1 (И1) для сложения матриц А и В из файла F2.");
            MatrixOperationsAdapter adapter = new MatrixOperationsAdapter();
            adapter.AddMatricesFromFile("../../../F2.txt");

            Console.WriteLine("Программа П2: Выполнение завершено.");
        }
    }
}
