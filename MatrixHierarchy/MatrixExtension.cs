using System;

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
        public static BaseMatrix<T> Add(BaseMatrix<T> matrixA, BaseMatrix<T> matrixB)
        {
            if (matrixA is null || matrixB is null)
            {
                throw new ArgumentNullException("Cannot operate addition with null");
            }

            dynamic dynMatrixA = matrixA;
            dynamic dynMatrixB = matrixB;
            if (matrixA.Size >= matrixB.Size)
            {
                return Addition(dynMatrixA, dynMatrixB);
            }
            else
            {
                return Addition(dynMatrixB, dynMatrixA);
            }
        }

        private static SquareMatrix<T> Addition(SquareMatrix<T> matrixA, SquareMatrix<T> matrixB)
        {
            var newMatrix = new SquareMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                }
            }

            return newMatrix;
        }

        private static SquareMatrix<T> Addition(SquareMatrix<T> matrixA, DiagonalMatrix<T> matrixB)
        {
            var newMatrix = new SquareMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    if (i == j)
                    {
                        newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                    }
                    else
                    {
                        newMatrix[i, j] = matrixA[i, j];
                    }
                }
            }

            return newMatrix;
        }

        private static SquareMatrix<T> Addition(DiagonalMatrix<T> matrixA, SquareMatrix<T> matrixB)
        {
            var newMatrix = new SquareMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    if (i == j)
                    {
                        newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                    }
                    else
                    {
                        newMatrix[i, j] = matrixB[i, j];
                    }
                }
            }

            return newMatrix;
        }

        private static SquareMatrix<T> Addition(SquareMatrix<T> matrixA, SymmetricalMatrix<T> matrixB)
        {
            var newMatrix = new SquareMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                }
            }

            return newMatrix;
        }

        private static SquareMatrix<T> Addition(SymmetricalMatrix<T> matrixA, SquareMatrix<T> matrixB)
        {
            var newMatrix = new SquareMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                }
            }

            return newMatrix;
        }

        private static SymmetricalMatrix<T> Addition(SymmetricalMatrix<T> matrixA, SymmetricalMatrix<T> matrixB)
        {
            var newMatrix = new SymmetricalMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                }
            }

            return newMatrix;
        }

        private static SymmetricalMatrix<T> Addition(SymmetricalMatrix<T> matrixA, DiagonalMatrix<T> matrixB)
        {
            var newMatrix = new SymmetricalMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    if (i == j)
                    {
                        newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                    }
                    else
                    {
                        newMatrix[i, j] = matrixA[i, j];
                    }
                }
            }

            return newMatrix;
        }

        private static SymmetricalMatrix<T> Addition(DiagonalMatrix<T> matrixA, SymmetricalMatrix<T> matrixB)
        {
            var newMatrix = new SymmetricalMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    if (i == j)
                    {
                        newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                    }
                    else
                    {
                        newMatrix[i, j] = matrixB[i, j];
                    }
                }
            }

            return newMatrix;
        }

        private static DiagonalMatrix<T> Addition(DiagonalMatrix<T> matrixA, DiagonalMatrix<T> matrixB)
        {
            var newMatrix = new DiagonalMatrix<T>(matrixA.Size);
            for (int i = 0; i < matrixB.Size; i++)
            {
                for (int j = 0; j < matrixB.Size; j++)
                {
                    if (i == j)
                    {
                        newMatrix[i, j] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                    }
                    else
                    {
                        newMatrix[i, j] = default(T);
                    }
                }
            }

            return newMatrix;
        }
    }
}