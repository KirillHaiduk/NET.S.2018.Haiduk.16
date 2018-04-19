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
        /// Constructor for Diagonal matrix
        /// </summary>
        /// <param name="s">Matrix rank</param>
        public DiagonalMatrix(int s) : base(s)
        {
            if (s <= 0)
            {
                throw new ArgumentException($"{nameof(s)} must be greater than 0.");
            }

            size = s;
            diagonalMatrix = new T[s, s];
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
                IndicesValidation(i, j);
                return diagonalMatrix[i, j];
            }

            set
            {
                IndicesValidation(i, j);
                if (i == j)
                {
                    diagonalMatrix[i, j] = value;
                    OnChanging(this, new ChangingMatrixElementEventArgs<T>(i, j));
                }
                else if (i != j)
                {                    
                    diagonalMatrix[i, j] = default(T);
                    diagonalMatrix[j, i] = default(T);
                    throw new InvalidOperationException("All elements of Diagonal matrix which are outside the main diagonal are equal to zero");
                }                
            }
        }
    }
}
