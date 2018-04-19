using System;

namespace MatrixHierarchy
{
    /// <summary>
    /// Class that describes symmetrical matrix of T type elements and event that occurs when a matrix element changes with indices (i, j)
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public class SymmetricalMatrix<T> : SquareMatrix<T>
    {
        private T[,] symmetricalMatrix;

        /// <summary>
        /// Constructor for Symmetrical matrix
        /// </summary>
        /// <param name="s">Matrix rank</param>
        public SymmetricalMatrix(int s) : base(s)
        {
            if (s <= 0)
            {
                throw new ArgumentException($"{nameof(s)} must be greater than 0.");
            }

            size = s;
            symmetricalMatrix = new T[s, s];
        }

        /// <summary>
        /// Indexer for Symmetrical matrix, also initiates event and sends information in it
        /// </summary>
        /// <param name="i">Index i of symmetrical matrix</param>
        /// <param name="j">Index j of symmetrical matrix</param>
        /// <returns>Access to matrix elements by indices</returns>
        public override T this[int i, int j]
        {
            get
            {
                IndicesValidation(i, j);
                return symmetricalMatrix[i, j];
            }

            set
            {
                IndicesValidation(i, j);
                symmetricalMatrix[i, j] = value;
                symmetricalMatrix[j, i] = value;
                OnChanging(this, new ChangingMatrixElementEventArgs<T>(i, j));
            }
        }        
    }
}
