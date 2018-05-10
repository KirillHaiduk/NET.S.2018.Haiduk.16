using System;

namespace MatrixHierarchy
{
    /// <summary>
    /// Describes square matrix of T type elements and event that occurs when a matrix element changes with indices (i, j)
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public class SquareMatrix<T> : BaseMatrix<T>
    {
        private int size;

        private T[,] squareMatrix;
                
        /// <summary>
        /// Constructor for creating instance of Square matrix by accepted rank
        /// </summary>
        /// <param name="sideOfMatrix">Matrix rank</param>
        public SquareMatrix(int sideOfMatrix) : base(sideOfMatrix)
        {
            this.size = sideOfMatrix;
            this.squareMatrix = new T[sideOfMatrix, sideOfMatrix];
        }

        /// <summary>
        /// Constructor for creating instance of Square matrix from accepted array
        /// </summary>
        /// <param name="s">Accepted square array</param>
        public SquareMatrix(T[,] array)
        {            
            if (this.IsArraySquare(array))
            {
                this.squareMatrix = new T[array.GetLength(0), array.GetLength(0)];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        this.squareMatrix[i, j] = array[i, j];
                    }
                }

                this.size = array.GetLength(0);
            }
            else
            {
                throw new ArgumentException("Array is not square");
            }
        }

        /// <summary>
        /// Property for getting size of square matrix
        /// </summary>
        public override int Size => this.size;

        /// <summary>
        /// Indexer for Square matrix, also initiates event and sends information in it
        /// </summary>
        /// <param name="i">Index i of square matrix</param>
        /// <param name="j">Index j of square matrix</param>
        /// <returns>Access to matrix elements by indices</returns>
        public override T this[int i, int j]
        {
            get
            {
                this.IndicesValidation(i, j);
                return this.squareMatrix[i, j];
            }

            set
            {
                this.IndicesValidation(i, j);
                this.squareMatrix[i, j] = value;
                OnChanging(this, new ChangingMatrixElementEventArgs<T>(i, j));
            }
        }

        /// <summary>
        /// Method for converting matrix to array
        /// </summary>        
        /// <returns>Array that contains matrix elements</returns>
        public override T[,] ToArray()
        {
            if (this is null)
            {
                throw new ArgumentNullException("Matrix is null");
            }

            T[,] array = new T[this.Size, this.Size];
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    array[i, j] = this[i, j];
                }
            }

            return array;
        }

        private bool IsArraySquare(T[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
