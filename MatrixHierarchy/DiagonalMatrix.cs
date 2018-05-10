using System;

namespace MatrixHierarchy
{
    /// <summary>
    /// Class that describes diagonal matrix of T type elements and event that occurs when a matrix element changes with indices (i, j)
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public class DiagonalMatrix<T> : BaseMatrix<T>
    {
        private int size;

        private T[] diagonalValues;

        /// <summary>
        /// Constructor for creating instance of Diagonal matrix by accepted rank
        /// </summary>
        /// <param name="sideOfMatrix">Matrix rank</param>
        public DiagonalMatrix(int sideOfMatrix) : base(sideOfMatrix)
        {
            this.size = sideOfMatrix;
            this.diagonalValues = new T[sideOfMatrix];
        }

        /// <summary>
        /// Constructor for creating instance of Diagonal matrix from accepted sz-array
        /// </summary>
        /// <param name="array">Accepted sz-array</param>
        public DiagonalMatrix(T[] array)
        {
            this.diagonalValues = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                this.diagonalValues[i] = array[i];
            }

            this.size = array.Length;
        }

        /// <summary>
        /// Property for getting size of square matrix
        /// </summary>
        public override int Size => this.size;

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
                    this.diagonalValues[i] = value;
                    this.OnChanging(this, new ChangingMatrixElementEventArgs<T>(i, j));
                }
                else if (i != j)
                {
                    throw new ArgumentException("Elements which are not on main diagonal of Diagonal matrix must have their default value");
                }
            }
        }

        /// <summary>
        /// Method for converting matrix to array
        /// </summary>        
        /// <returns>Array that contains matrix elements</returns>
        public override T[,] ToArray()
        {
            T[,] array = new T[this.Size, this.Size];
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    if (i == j)
                    {
                        array[i, j] = this.diagonalValues[i];
                    }
                    else
                    {
                        array[i, j] = default(T);
                    }
                }
            }

            return array;
        }
    }
}
