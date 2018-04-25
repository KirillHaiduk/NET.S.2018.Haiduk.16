using System;

namespace MatrixHierarchy
{
    /// <summary>
    /// Class that describes diagonal matrix of T type elements and event that occurs when a matrix element changes with indices (i, j)
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        private T[] diagonalValues;

        private T[,] diagonalMatrix;

        /// <summary>
        /// Constructor for creating instance of Diagonal matrix by accepted rank
        /// </summary>
        /// <param name="sideOfMatrix">Matrix rank</param>
        public DiagonalMatrix(int sideOfMatrix)
        {
            if (sideOfMatrix <= 0)
            {
                throw new ArgumentException($"{nameof(sideOfMatrix)} must be greater than 0.");
            }

            this.size = sideOfMatrix;
            this.diagonalValues = new T[sideOfMatrix];
            this.diagonalMatrix = new T[sideOfMatrix, sideOfMatrix];
        }

        /// <summary>
        /// Constructor for creating instance of Diagonal matrix from accepted sz-array
        /// </summary>
        /// <param name="array">Accepted sz-array</param>
        public DiagonalMatrix(T[] array)
        {
            this.diagonalValues = new T[array.Length];
            this.diagonalMatrix = new T[array.Length, array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                this.diagonalValues[i] = array[i];
                this.diagonalMatrix[i, i] = array[i];
            }

            this.size = array.Length;
        }

        /// <summary>
        /// Indexer for Diagonal matrix, also initiates event and sends information in it
        /// </summary>
        /// <param name="i">Index i of diagonal matrix</param>
        /// <param name="j">Index j of diagonal matrix</param>
        /// <returns>Access to matrix elements by indices</returns>
        public override T this[int i, int j]
        {
            get
            {
                this.IndicesValidation(i, j);                
                if (i == j)
                {
                    return this.diagonalValues[i];
                }
                else
                {
                    return default(T);
                }
            }

            set
            {
                this.IndicesValidation(i, j);
                if (i == j)
                {
                    this.diagonalMatrix[i, j] = value;
                    this.OnChanging(this, new ChangingMatrixElementEventArgs<T>(i, j));
                }
                else if (i != j)
                {
                    this.diagonalMatrix[i, j] = default(T);
                    this.diagonalMatrix[j, i] = default(T);
                }
            }
        }
    }
}
