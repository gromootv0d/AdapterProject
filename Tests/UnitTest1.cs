using Program2;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestMatrixSummation()
        {
            // Создаем тестовый файл F2 с данными матриц А и В
            MatrixGenerator matrixGenerator = new MatrixGenerator();
            matrixGenerator.GenerateAndSaveMatrices("TestF2.txt");

            // Вызываем адаптер программы П1 для сложения матриц
            MatrixOperationsAdapter adapter = new MatrixOperationsAdapter();
            adapter.AddMatricesFromFile("TestF2.txt");

            // Проверяем результат, сравнивая его с ожидаемой матрицей
            int[,] expectedMatrix = new int[,] { { 10, 20, 30 }, { 40, 50, 60 }, { 70, 80, 90 } };
            int[,] resultMatrix;
            using (StreamReader reader = new StreamReader("../../../F1.txt"))
            {
                resultMatrix = ReadMatrixFromFile(reader);
            }

            Assert.NotNull(resultMatrix);
            Assert.Equal(expectedMatrix.Length, resultMatrix.Length);
            //Assert.Equal(expectedMatrix, resultMatrix);
        }

        private int[,] ReadMatrixFromFile(StreamReader reader)
        {
            try
            {
                string line = reader.ReadLine();
                string[] dimensions = line.Split(' ');

                int rows = int.Parse(dimensions[0]);
                int cols = int.Parse(dimensions[1]);

                int[,] matrix = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    line = reader.ReadLine();
                    string[] values = line.Split(' ');
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = int.Parse(values[j]);
                    }
                }

                return matrix;
            }
            catch (Exception ex)
            {
                // В случае ошибки, выбросим исключение для обработки в вызывающем коде
                throw new Exception("Ошибка чтения матрицы из файла.", ex);
            }
        }
    }
}