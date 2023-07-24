using System;
using System.IO;

namespace Program1
{
    public class MatrixOperations
    {
        public void AddMatricesFromFile(string filePath)
        {
            int[,] matrixA, matrixB;
            ReadMatricesFromFile(filePath, out matrixA, out matrixB);

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

            string resultFilePath = "../../../F1.txt";
            SaveMatrixToFile(resultFilePath, resultMatrix);
        }

        private void ReadMatricesFromFile(string filePath, out int[,] matrixA, out int[,] matrixB)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line = reader.ReadLine();
                    string[] dimensions = line.Split(' ');

                    int rows = int.Parse(dimensions[0]);
                    int cols = int.Parse(dimensions[1]);

                    matrixA = new int[rows, cols];
                    matrixB = new int[rows, cols];

                    // Читаем данные для матрицы A
                    for (int i = 0; i < rows; i++)
                    {
                        line = reader.ReadLine();
                        string[] values = line.Split(' ');
                        for (int j = 0; j < cols; j++)
                        {
                            matrixA[i, j] = int.Parse(values[j]);
                        }
                    }

                    // Читаем данные для матрицы B
                    for (int i = 0; i < rows; i++)
                    {
                        line = reader.ReadLine();
                        string[] values = line.Split(' ');
                        for (int j = 0; j < cols; j++)
                        {
                            matrixB[i, j] = int.Parse(values[j]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // В случае ошибки, выбросим исключение для обработки в вызывающем коде
                throw new Exception("Ошибка чтения данных из файла.", ex);
            }
        }

        private void SaveMatrixToFile(string filePath, int[,] matrix)
        {
            // Сохранение матрицы в файл
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);

                writer.WriteLine($"{rows} {cols}");

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
}
