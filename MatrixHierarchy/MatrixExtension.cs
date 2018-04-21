namespace MatrixHierarchy
{
    /// <summary>
    /// Class that expand the functionality of Matrix Hierarchy 
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public static class MatrixExtension<T>
    {
        /// <summary>
        /// Method for addition of two matrices
        /// </summary>
        /// <param name="matrixA">1st matrix</param>
        /// <param name="matrixB">2nd matrix</param>
        /// <returns>New matrix as a result of addition of two accepted matrices</returns>
        public static SquareMatrix<T> Add(SquareMatrix<T> matrixA, SquareMatrix<T> matrixB)
        {
            if (matrixA.Size >= matrixB.Size)
            {
                var newMatrix = matrixA;
                for (int i = 0; i < matrixB.Size; i++)
                {
                    for (int j = 0; j < matrixB.Size; j++)
                    {
                        newMatrix[i, j] += (dynamic)matrixB[i, j];
                    }
                }

                return newMatrix;
            }
            else
            {
                var newMatrix = matrixB;
                for (int i = 0; i < matrixA.Size; i++)
                {
                    for (int j = 0; j < matrixA.Size; j++)
                    {
                        newMatrix[i, j] += (dynamic)matrixA[i, j];
                    }
                }

                return newMatrix;
            }
        }
    }
}