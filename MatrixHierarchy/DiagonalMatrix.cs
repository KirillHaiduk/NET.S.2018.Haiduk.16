using System;

namespace MatrixHierarchy
{
    /// <summary>
    /// Class that describes diagonal matrix of T type elements and event that occurs when a matrix element changes with indices (i, j)
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        private T[,] diagonalMatrix;

        /// <summary>
        /// Constructor for creating instance of Diagonal matrix by accepted rank
        /// </summary>
        /// <param name="s">Matrix rank</param>
        public DiagonalMatrix(int s) : base(s)
        {
            if (s <= 0)
            {
                throw new ArgumentException($"{nameof(s)} must be greater than 0.");
            }

            this.size = s;
            this.diagonalMatrix = new T[s, s];
        }

        /// <summary>
        /// Constructor for creating instance of Diagonal matrix from accepted array
        /// </summary>
        /// <param name="s">Accepted diagonal array</param>
        public DiagonalMatrix(T[,] array) : base(array)
        {
            if (this.IsArraySquare(array) && this.IsArrayDiagonal(array))
            {
                this.diagonalMatrix = new T[array.GetLength(0), array.GetLength(0)];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        this.diagonalMatrix[i, j] = array[i, j];
                    }
                }

                this.size = array.GetLength(0);
            }
            else
            {
                throw new ArgumentException("Array is not diagonal");
            }
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
                return this.diagonalMatrix[i, j];
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

        private bool IsArrayDiagonal(T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        if (!array[i, j].Equals(array[j, i]) && !array[i, j].Equals(default(T)))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
