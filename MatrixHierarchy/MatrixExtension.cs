namespace MatrixHierarchy
{
    public static class MatrixExtension<T>
    {
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
