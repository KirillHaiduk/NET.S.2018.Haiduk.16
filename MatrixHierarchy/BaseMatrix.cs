using System;

namespace MatrixHierarchy
{
    /// <summary>
    /// Description of square matrix types
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public abstract class BaseMatrix<T>
    {
        private int size;

        private T[,] baseMatrix;

        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public BaseMatrix()
        {
        }

        /// <summary>
        /// Base constructor for matrix types
        /// </summary>
        /// <param name="sideOfMatrix">Matrix rank</param>
        public BaseMatrix(int sideOfMatrix)
        {
            if (sideOfMatrix <= 0)
            {
                throw new ArgumentException($"{nameof(sideOfMatrix)} must be greater than 0.");
            }
                        
            this.size = sideOfMatrix;
            baseMatrix = new T[sideOfMatrix, sideOfMatrix];
        }

        /// <summary>
        /// Property for getting size of square matrix
        /// </summary>
        public virtual int Size => this.size;

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
                return baseMatrix[i, j];
            }

            set
            {
                IndicesValidation(i, j);
                baseMatrix[i, j] = value;
                OnChanging(this, new ChangingMatrixElementEventArgs<T>(i, j));
            }
        }

        /// <summary>
        /// Method for converting matrix to array
        /// </summary>        
        /// <returns>Array that contains matrix elements</returns>
        public abstract T[,] ToArray();        

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
            if (i < 0 || j < 0 || i >= Size || j >= Size)
            {
                throw new ArgumentOutOfRangeException($"Index cannot be less than zero or more than actual matrix length.");
            }
        }       

        #endregion
    }
}
