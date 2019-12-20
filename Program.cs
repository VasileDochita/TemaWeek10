using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaWeek10
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Matrix<T> : IEnumerable<T> where T : struct
    {
        private T[,] matrix;

        public Matrix(int row, int column)
        {
            this.matrix = new T[row, column];
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.matrix)
            {
                yield return item;
            }
        }

        private void Exception(int row, int column)
        {
            if (row < 0 || row >= matrix.GetLength(0) || column < 0 || column >= matrix.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("out of range");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public T this[int row, int column]
        {
            get
            {
                return this.matrix[row, column];
            }
            set
            {
                this.matrix[row, column] = value;
            }
        }
        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if ((firstMatrix.matrix.GetLength(0) != secondMatrix.matrix.GetLength(0)) ||
                (firstMatrix.matrix.GetLength(1) != secondMatrix.matrix.GetLength(1)))
            {
                throw new ArgumentException("Size is different");
            }
            Matrix<T> newMatrix = new Matrix<T>(firstMatrix.matrix.GetLength(0), firstMatrix.matrix.GetLength(1));

            for (int i = 0; i < firstMatrix.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.matrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = (dynamic)firstMatrix[i, j] + secondMatrix[i, j];
                }
            }

            return newMatrix;
        }
        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if ((firstMatrix.matrix.GetLength(0) != secondMatrix.matrix.GetLength(0)) ||
                (firstMatrix.matrix.GetLength(1) != secondMatrix.matrix.GetLength(1)))
            {
                throw new ArgumentException("Size is different");
            }

            Matrix<T> newMatrix = new Matrix<T>(firstMatrix.matrix.GetLength(0), firstMatrix.matrix.GetLength(1));
            for (int i = 0; i < firstMatrix.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.matrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = (dynamic)firstMatrix[i, j] - secondMatrix[i, j];
                }
            }

            return newMatrix;
        }
        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.matrix.GetLength(0) != secondMatrix.matrix.GetLength(1))
            {
                throw new ArgumentException("Size is different");
            }

            Matrix<T> newMatrix = new Matrix<T>(firstMatrix.matrix.GetLength(0), firstMatrix.matrix.GetLength(1));

            for (int i = 0; i < firstMatrix.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.matrix.GetLength(1); j++)
                {
                    for (int k = 0; k < firstMatrix.matrix.GetLength(1); k++)
                    {
                        newMatrix[k, j] = (dynamic)firstMatrix[k, k] * secondMatrix[k, j];
                    }
                }
            }
            return newMatrix;
        }
    }
}
