using Program1;

namespace Program2
{
    public class MatrixOperationsAdapter
    {
        public void AddMatricesFromFile(string filePath)
        {
            MatrixOperations matrixOps = new MatrixOperations();
            matrixOps.AddMatricesFromFile(filePath);
        }
    }
}
