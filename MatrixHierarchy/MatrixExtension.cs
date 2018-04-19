using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixHierarchy
{
    public class MatrixExtension<T> where T : struct
    {
        public SquareMatrix<T> Add(SquareMatrix<T> matrixA, SquareMatrix<T> matrixB)
        {
            if (matrixA.Size >= matrixB.Size)
            {
                var newMatrix = matrixA;
                for (int i = 0; i < matrixB.Size; i++)
                {
                    for (int j = 0; j < matrixB.Size; j++)
                    {
                        newMatrix[i, j] += matrixB[i, j];
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
                        newMatrix[i, j] += matrixA[i, j];
                    }
                }

                return newMatrix;
            }
        }
    }
}