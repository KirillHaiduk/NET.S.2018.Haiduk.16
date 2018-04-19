using System;

namespace MatrixHierarchy
{
    /// <summary>
    /// Class that describes square matrix of T type elements and event that occurs when a matrix element changes with indices (i, j)
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public class SquareMatrix<T>
    {
        protected int size;

        private T[,] squareMatrix;

        /// <summary>
        /// Constructor for Square matrix
        /// </summary>
        /// <param name="s">Matrix rank</param>
        public SquareMatrix(int s)
        {
            if (s <= 0)
            {
                throw new ArgumentException($"{nameof(s)} must be greater than 0.");
            }

            size = s;
            squareMatrix = new T[s, s];
        }

        /// <summary>
        /// Property for getting size of square matrix
        /// </summary>
        public int Size => size;

        /// <summary>
        /// Indexer for Square matrix, also initiates event and sends information in it
        /// </summary>
        /// <param name="i">Index i of square matrix</param>
        /// <param name="j">Index j of square matrix</param>
        /// <returns>Access to matrix elements by indices</returns>
        public virtual T this[int i, int j]
        {
            get
            {
                IndicesValidation(i, j);
                return squareMatrix[i, j];
            }

            set
            {
                IndicesValidation(i, j);
                squareMatrix[i, j] = value;
                OnChanging(this, new ChangingMatrixElementEventArgs<T>(i, j));
            }
        }

        #region Event of changing Matrix element

        /// <summary>
        /// Delegate for handling event
        /// </summary>
        /// <param name="sender">Name of event broadcaster</param>
        /// <param name="e">Information about event</param>
        public delegate void ChangingMatrixElementEventHandler(object sender, ChangingMatrixElementEventArgs<T> e);

        /// <summary>
        /// Event member
        /// </summary>
        public event ChangingMatrixElementEventHandler Changing = delegate { };

        protected virtual void OnChanging(object sender, ChangingMatrixElementEventArgs<T> e) => Changing?.Invoke(sender, e);

        #endregion

        #region Private methods

        protected virtual void IndicesValidation(int i, int j)
        {
            if (i < 0 || j < 0 || i >= size || j >= size)
            {
                throw new ArgumentOutOfRangeException($"Index cannot be less than zero or more than actual matrix length.");
            }
        }

        #endregion
    }
}
