using System;
using NUnit.Framework;

namespace MatrixHierarchy.Tests
{
    [TestFixture]
    public class MatrixHierarchyTests
    {
        [Test]
        public void CreateNewMatrix_WithZeroOrNegativeSize_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(0));
            Assert.Throws<ArgumentException>(() => new SquareMatrix<string>(-10));
            Assert.Throws<ArgumentException>(() => new SymmetricalMatrix<double>(0));
            Assert.Throws<ArgumentException>(() => new SymmetricalMatrix<float>(-100));
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<char>(0));
            Assert.Throws<ArgumentException>(() => new DiagonalMatrix<object>(-20));
        }

        [Test]
        public void CreateSquareMatrix_FromNonSquareArray_ThrowsException()
        {
            var array = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 10, 11, 12 } };
            Assert.Throws<ArgumentException>(() => new SquareMatrix<int>(array));            
        }

        [Test]
        public void CreateSymmetricalMatrix_FromNonSymmetricalArray_ThrowsException()
        {
            var array = new int[][] { new int[] { 1, 1 }, new int[] { 2, 3 }, new int[] { 4, 5 }, new int[] { 7, 8, 9, 10 } };
            Assert.Throws<ArgumentException>(() => new SymmetricalMatrix<int>(array));            
        }

        [Test]
        public void MatrixHierarchyAdditionTest1()
        {
            var array1 = new int[,] { { 5, 6, -3 }, { 17, 7, 0 }, { 8, -5, 4 } };
            var array2 = new int[,] { { 2, 3, 0 }, { 6, 11, 1 }, { 3, 3, 7 } };
            var resultArray = new int[,] { { 7, 9, -3 }, { 23, 18, 1 }, { 11, -2, 11 } };
            var matrixA = new SquareMatrix<int>(array1);
            var matrixB = new SquareMatrix<int>(array2);
            var sum = MatrixExtension<int>.Add(matrixA, matrixB);
            CollectionAssert.AreEqual(resultArray, sum.ToArray());
        }

        [Test]
        public void MatrixHierarchyAdditionTest2()
        {
            var array1 = new string[][] { new string[] { "-3" }, new string[] { "6", "-5" }, new string[] { "5", "7", "4" } };
            var array2 = new string[] { "ab", "cd", "ef" };
            var resultArray = new string[,] { { "-3ab", "6", "5" }, { "6", "-5cd", "7" }, { "5", "7", "4ef" } };
            var matrixA = new SymmetricalMatrix<string>(array1);
            var matrixB = new DiagonalMatrix<string>(array2);
            var sum = MatrixExtension<string>.Add(matrixA, matrixB);
            CollectionAssert.AreEqual(resultArray, sum.ToArray());
        }
    }
}