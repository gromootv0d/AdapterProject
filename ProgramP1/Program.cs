using System;
using System.IO;

class ProgramP1
{
    static void Main(string[] args)
    {
        try
        {
            // Чтение данных из файла F0
            string inputFile = "F0.txt";
            int[,] matrixA, matrixB;
            ReadMatricesFromFile(inputFile, out matrixA, out matrixB);

            // Проверка, что матрицы имеют одинаковый размер для возможности сложения
            if (matrixA.GetLength(0) != matrixB.GetLength(0) || matrixA.GetLength(1) != matrixB.GetLength(1))
            {
                Console.WriteLine("Матрицы должны иметь одинаковый размер для сложения.");
                return;
            }

            // Сложение матриц
            int[,] resultMatrix = AddMatrices(matrixA, matrixB);

            // Сохранение результата в файл F1
            string outputFile = "F1.txt";
            SaveMatrixToFile(outputFile, resultMatrix);

            Console.WriteLine("Матрицы успешно сложены и сохранены в файл F1.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }

    // Метод для чтения данных о матрицах из файла
    static void ReadMatricesFromFile(string filename, out int[,] matrixA, out int[,] matrixB)
    {
        // Предполагается, что файл содержит данные о двух матрицах в формате:
        // 1 2 3
        // 4 5 6
        // где числа разделены пробелами, а строки матриц разделены переносами строк.

        string[] lines = File.ReadAllLines(filename);
        string[] valuesA = lines[0].Split(' ');
        string[] valuesB = lines[1].Split(' ');

        int rows = lines.Length;
        int cols = valuesA.Length;

        matrixA = new int[rows, cols];
        matrixB = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            string[] rowValuesA = lines[i].Split(' ');
            string[] rowValuesB = lines[i + rows].Split(' ');

            for (int j = 0; j < cols; j++)
            {
                matrixA[i, j] = int.Parse(rowValuesA[j]);
                matrixB[i, j] = int.Parse(rowValuesB[j]);
            }
        }
    }

    // Метод для сложения двух матриц
    static int[,] AddMatrices(int[,] matrixA, int[,] matrixB)
    {
        int rows = matrixA.GetLength(0);
        int cols = matrixA.GetLength(1);

        int[,] resultMatrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                resultMatrix[i, j] = matrixA[i, j] + matrixB[i, j];
            }
        }

        return resultMatrix;
    }

    // Метод для сохранения матрицы в файл
    static void SaveMatrixToFile(string filename, int[,] matrix)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    writer.Write(matrix[i, j] + " ");
                }
                writer.WriteLine();
            }
        }
    }
}
