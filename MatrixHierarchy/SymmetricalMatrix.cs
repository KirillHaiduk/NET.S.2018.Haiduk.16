using System;

namespace MatrixHierarchy
{
    /// <summary>
    /// Class that describes symmetrical matrix of T type elements and event that occurs when a matrix element changes with indices (i, j)
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public class SymmetricalMatrix<T> : SquareMatrix<T>
    {
        private T[][] symmetricalValues;

        private T[,] symmetricalMatrix;

        /// <summary>
        /// Constructor for creating instance of Symmetrical matrix by accepted rank
        /// </summary>
        /// <param name="sideOfMatrix">Matrix rank</param>
        public SymmetricalMatrix(int sideOfMatrix)
        {
            if (sideOfMatrix <= 0)
            {
                throw new ArgumentException($"{nameof(sideOfMatrix)} must be greater than 0.");
            }

            this.size = sideOfMatrix;
            this.symmetricalValues = new T[sideOfMatrix][];
            this.symmetricalMatrix = new T[sideOfMatrix, sideOfMatrix];
        }

        /// <summary>
        /// Constructor for creating instance of Symmetrical matrix from accepted jagged array
        /// </summary>
        /// <param name="array">Accepted symmetrical jagged array</param>
        public SymmetricalMatrix(T[][] array)
        {
            if (this.IsArraySymmetrical(array))
            {
                this.symmetricalValues = new T[array.GetLength(0)][];
                this.symmetricalMatrix = new T[array.GetLength(0), array.GetLength(0)];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    this.symmetricalValues[i] = new T[array[i].Length];
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        this.symmetricalValues[i][j] = array[i][j];
                        this.symmetricalMatrix[array.GetLength(0) - 1 - i + j, j] = array[i][j];
                        this.symmetricalMatrix[j, array.GetLength(0) - 1 - i + j] = array[i][j];                        
                    }
                }

                this.size = array.GetLength(0);
            }
            else
            {
                throw new ArgumentException("Array is not symmetrical");
            }
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
                this.IndicesValidation(i, j);                
                return this.symmetricalMatrix[i, j];
            }

            set
            {
                this.IndicesValidation(i, j);
                this.symmetricalMatrix[i, j] = value;
                this.symmetricalMatrix[j, i] = value;
                this.OnChanging(this, new ChangingMatrixElementEventArgs<T>(i, j));
            }
        }

        private bool IsArraySymmetrical(T[][] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {                
                if (array[i].Length != i + 1)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
