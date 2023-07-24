using System;
using System.IO;

class ProgramP2
{
    static void Main(string[] args)
    {
        try
        {
            // Генерация данных матриц А и В
            int[,] matrixA = GenerateRandomMatrix(3, 3);
            int[,] matrixB = GenerateRandomMatrix(3, 3);

            // Сохранение данных матриц в файл F2
            string outputFile = "F2.txt";
            SaveMatricesToFile(outputFile, matrixA, matrixB);

            Console.WriteLine("Матрицы сгенерированы и сохранены в файл F2.");

            // Адаптер вызова программы П1 для сложения матриц из файла F2
            string inputFile = "F2.txt";
            string outputFileP1 = "F1_from_P2.txt";
            CallProgramP1(inputFile, outputFileP1);

            Console.WriteLine("Матрицы успешно сложены и сохранены в файл F1_from_P2.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }

    // Метод для генерации случайной матрицы заданного размера
    static int[,] GenerateRandomMatrix(int rows, int cols)
    {
        Random random = new Random();
        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = random.Next(1, 10); // Генерируем случайное число от 1 до 9
            }
        }

        return matrix;
    }

    // Метод для сохранения данных матриц в файл
    static void SaveMatricesToFile(string filename, int[,] matrixA, int[,] matrixB)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            int rows = matrixA.GetLength(0);
            int cols = matrixA.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    writer.Write(matrixA[i, j] + " ");
                }
                writer.WriteLine();
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    writer.Write(matrixB[i, j] + " ");
                }
                writer.WriteLine();
            }
        }
    }

    // Метод для вызова программы П1 для сложения матриц из файла
    static void CallProgramP1(string inputFile, string outputFile)
    {
        string command = $"\"П1.exe\""; // Предполагается, что имя исполняемого файла программы П1 - "П1.exe"
        string arguments = $"\"{inputFile}\""; // Передаем имя входного файла через аргументы командной строки
        System.Diagnostics.Process.Start(command, arguments).WaitForExit();
    }
}
