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
        /// Constructor for creating instance of Square matrix by accepted rank
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
        /// Constructor for creating instance of Square matrix from accepted array
        /// </summary>
        /// <param name="s">Accepted square array</param>
        public SquareMatrix(T[,] array)
        {            
            if (IsArraySquare(array))
            {
                squareMatrix = new T[array.GetLength(0), array.GetLength(0)];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        squareMatrix[i, j] = array[i, j];
                    }
                }

                size = array.GetLength(0);
            }
            else
            {
                throw new ArgumentException("Array is not square");
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

        /// <summary>
        /// Method for converting matrix to array
        /// </summary>
        /// <param name="matrix">Accepted square matrix</param>
        /// <returns>Array that contains matrix elements</returns>
        public static T[,] ToArray(SquareMatrix<T> matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix));
            }

            T[,] array = new T[matrix.Size, matrix.Size];
            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    array[i, j] = matrix[i, j];
                }
            }

            return array;
        }

        #region Private methods

        protected virtual void IndicesValidation(int i, int j)
        {
            if (i < 0 || j < 0 || i >= size || j >= size)
            {
                throw new ArgumentOutOfRangeException($"Index cannot be less than zero or more than actual matrix length.");
            }
        }

        protected bool IsArraySquare(T[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
