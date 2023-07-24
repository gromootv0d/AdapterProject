// MatrixGenerator.cs

using System;
using System.IO;

namespace Program2
{
    public class MatrixGenerator
    {
        public void GenerateAndSaveMatrices(string filePath)
        {
            int[,] matrixA = GenerateRandomMatrix(3, 3); // Пример: генерация 3x3 матрицы
            int[,] matrixB = GenerateRandomMatrix(3, 3); // Пример: генерация 3x3 матрицы

            SaveMatrixToFile(filePath, matrixA, matrixB);
        }

        private int[,] GenerateRandomMatrix(int rows, int cols)
        {
            // Генерация случайной матрицы
            int[,] matrix = new int[rows, cols];
            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(1, 10); // Случайные числа от 1 до 9
                }
            }

            return matrix;
        }

        private void SaveMatrixToFile(string filePath, int[,] matrixA, int[,] matrixB)
        {
            // Сохранение матриц в файл
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("3 3");
                //writer.WriteLine("Matrix A:");
                WriteMatrixToFile(writer, matrixA);

                //writer.WriteLine("Matrix B:");
                WriteMatrixToFile(writer, matrixB);
            }
        }

        private void WriteMatrixToFile(StreamWriter writer, int[,] matrix)
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
