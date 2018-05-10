using System;

namespace MatrixHierarchy
{
    /// <summary>
    /// Class that describes symmetrical matrix of T type elements and event that occurs when a matrix element changes with indices (i, j)
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public class SymmetricalMatrix<T> : BaseMatrix<T>
    {
        private int size;

        private T[][] symmetricalValues;

        /// <summary>
        /// Constructor for creating instance of Symmetrical matrix by accepted rank
        /// </summary>
        /// <param name="sideOfMatrix">Matrix rank</param>
        public SymmetricalMatrix(int sideOfMatrix) : base(sideOfMatrix)
        {
            this.size = sideOfMatrix;
            this.symmetricalValues = new T[sideOfMatrix][];
            for (int i = 0; i < sideOfMatrix; i++)
            {
                this.symmetricalValues[i] = new T[i + 1];
            }
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
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    this.symmetricalValues[i] = new T[array[i].Length];
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        this.symmetricalValues[i][j] = array[i][j];
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
        /// Property for getting size of square matrix
        /// </summary>
        public override int Size => this.size;

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
                if (i >= j)
                {
                    return this.symmetricalValues[i][j];
                }
                else
                {
                    return this.symmetricalValues[j][i];
                }
            }

            set
            {
                this.IndicesValidation(i, j);
                if (i >= j)
                {
                    this.symmetricalValues[i][j] = value;
                }
                else
                {
                    this.symmetricalValues[j][i] = value;
                }

                this.OnChanging(this, new ChangingMatrixElementEventArgs<T>(i, j));
            }
        }

        /// <summary>
        /// Method for converting matrix to array
        /// </summary>        
        /// <returns>Array that contains matrix elements</returns>
        public override T[,] ToArray()
        {
            T[,] array = new T[this.Size, this.Size];
            for (int i = 0; i < this.symmetricalValues.GetLength(0); i++)
            {
                for (int j = 0; j < this.symmetricalValues[i].Length; j++)
                {
                    if (i == j)
                    {
                        array[i, j] = this.symmetricalValues[i][j];
                    }
                    else
                    {
                        array[i, j] = this.symmetricalValues[i][j];
                        array[j, i] = this.symmetricalValues[i][j];
                    }
                }
            }

            return array;
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
