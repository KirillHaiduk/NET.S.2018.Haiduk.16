using System;

namespace MatrixHierarchy
{
    /// <summary>
    /// Identify the type of information that stores information, which is passed to the subscribers of the event notification.
    /// </summary>
    /// <typeparam name="T">Parameter type</typeparam>
    public class ChangingMatrixElementEventArgs<T> : EventArgs
    {
        private int indexI;

        private int indexJ;

        /// <summary>
        /// Consructor for event information handler
        /// </summary>
        /// <param name="i">Index i of square matrix</param>
        /// <param name="j">Index j of square matrix</param>
        public ChangingMatrixElementEventArgs(int i, int j)
        {
            this.indexI = i;
            this.indexJ = j;
        }

        /// <summary>
        /// Property for getting index i of square matrix
        /// </summary>
        public int IndexI => this.indexI;

        /// <summary>
        /// Property for getting index j of square matrix
        /// </summary>
        public int IndexJ => this.indexJ;
    }
}
