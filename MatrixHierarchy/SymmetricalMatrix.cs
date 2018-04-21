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
        /// Constructor for creating instance of Symmetrical matrix by accepted rank
        /// </summary>
        /// <param name="s">Matrix rank</param>
        public SymmetricalMatrix(int s) : base(s)
        {
            if (s <= 0)
            {
                throw new ArgumentException($"{nameof(s)} must be greater than 0.");
            }

            this.size = s;
            this.symmetricalMatrix = new T[s, s];
        }

        /// <summary>
        /// Constructor for creating instance of Symmetrical matrix from accepted array
        /// </summary>
        /// <param name="s">Accepted symmetrical array</param>
        public SymmetricalMatrix(T[,] array) : base(array)
        {
            if (this.IsArraySquare(array) && this.IsArraySymmetrical(array))
            {
                this.symmetricalMatrix = new T[array.GetLength(0), array.GetLength(0)];
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        this.symmetricalMatrix[i, j] = array[i, j];
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

        private bool IsArraySymmetrical(T[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i != j && !array[i, j].Equals(array[j, i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
