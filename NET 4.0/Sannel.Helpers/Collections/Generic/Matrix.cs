/*
Copyright 2013 Sannel Software, L.L.C.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sannel.Collections.Generic
{
	/// <summary>
	/// This class is basically a wrapper around the .net multidemential arrays. It also handles resizing the array.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
	public class Matrix<T> : IMatrix<T>
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Member")]
		private T[,] internalMatrix;

		/// <summary>
		/// Creates a matrix with 0 Rows and 0 Columns
		/// </summary>
		public Matrix()
		{
			internalMatrix = new T[0, 0];
		}

		/// <summary>
		/// Create a matrix with <paramref name="rows"/> Rows and <paramref name="columns"/> Columns
		/// </summary>
		/// <param name="rows">The number of rows this matrix should begin with.</param>
		/// <param name="columns">The number of columsn this matrix should begin with.</param>
		public Matrix(int rows, int columns)
		{
			if (rows < 0)
			{
				throw new ArgumentOutOfRangeException("rows", "Rows must be greater then or equal to 0.");
			}

			if (columns < 0)
			{
				throw new ArgumentOutOfRangeException("columns", "Columns must be greater then or equal to 0.");
			}

			internalMatrix = new T[rows, columns];
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		public T this[int row, int column]
		{
			get
			{
				if (row < 0 || row >= Rows)
				{
					throw new ArgumentOutOfRangeException("row", "row must be greater then or equal to 0 and less then the number of Rows");
				}

				if (column < 0 || column >= Columns)
				{
					throw new ArgumentOutOfRangeException("column", "column must be greater then or equal to 0 and less then the number of Columns");
				}
				lock (internalMatrix)
				{
					return internalMatrix[row, column];
				}
			}
			set
			{
				if (row < 0 || row >= Rows)
				{
					throw new ArgumentOutOfRangeException("row", "row must be greater then or equal to 0 and less then the number of Rows");
				}
				
				if (column < 0 || column >= Columns)
				{
					throw new ArgumentOutOfRangeException("column", "column must be greater then or equal to 0 and less then the number of Columns");
				}

				lock (internalMatrix)
				{
					internalMatrix[row, column] = value;
				}
			}
		}

		/// <summary>
		/// Adds another row to this matrix
		/// </summary>
		public void AddRow()
		{
			Resize(Rows + 1, Columns);
		}

		/// <summary>
		/// Adds <paramref name="count"></paramref> rows to this matrix
		/// </summary>
		/// <param name="count">The number of rows</param>
		public void AddRows(int count)
		{
			Resize(Rows + count, Columns);
		}

		/// <summary>
		/// Removes 1 row from the matrix
		/// </summary>
		public void RemoveRow()
		{
			Resize(Rows - 1, Columns);
		}

		/// <summary>
		/// Removes <paramref name="count"/> rows from the matrix
		/// </summary>
		/// <param name="count">The number of rows to count</param>
		public void RemoveRows(int count)
		{
			Resize(Rows - count, Columns);
		}

		/// <summary>
		/// Adds one column to this matrix
		/// </summary>
		public void AddColumn()
		{
			Resize(Rows, Columns + 1);
		}

		/// <summary>
		/// Adds <paramref name="count"/> columns to this matrix
		/// </summary>
		/// <param name="count">The number of columns to add</param>
		public void AddColumns(int count)
		{
			Resize(Rows, Columns + count);
		}

		/// <summary>
		/// Removes a column from the matrix
		/// </summary>
		public void RemoveColumn()
		{
			Resize(Rows, Columns - 1);
		}

		/// <summary>
		/// Removes <paramref name="count"/> columns from the matrix
		/// </summary>
		/// <param name="count">The number of columns to remove</param>
		public void RemoveColumns(int count)
		{
			Resize(Rows, Columns - count);
		}

		/// <summary>
		/// The number of Rows in this matrix
		/// </summary>
		public int Rows
		{
			get 
			{
				lock (internalMatrix)
				{
					return internalMatrix.GetLength(0);
				}
			}
		}

		/// <summary>
		/// The number of Columns in this matrix
		/// </summary>
		public int Columns
		{
			get 
			{
				lock (internalMatrix)
				{
					return internalMatrix.GetLength(1);
				}
			}
		}

		/// <summary>
		/// Enumerates through the matrix returning every column in a row then going to the next row.
		/// </summary>
		/// <returns></returns>
		public IEnumerator<T> GetEnumerator()
		{
			lock (internalMatrix)
			{
				int r = 0, c = 0;
				while (r < Rows)
				{
					c = 0;
					while (c < Columns)
					{
						yield return internalMatrix[r, c++];
					}
					r++;
				}
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			lock (internalMatrix)
			{
				int r = 0, c = 0;
				while (r < Rows)
				{
					c = 0;
					while (c < Columns)
					{
						yield return internalMatrix[r, c++];
					}
					r++;
				}
			}
		}

		/// <summary>
		/// Resizes the matrix to <paramref name="rows"/> rows and <paramref name="columns"/>
		/// if rows or columns are less then 0 a MatrixException is thrown
		/// </summary>
		/// <param name="rows">The number of rows</param>
		/// <param name="columns">The number of columns</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Body")]
		public void Resize(int rows, int columns)
		{
			if (rows < 0)
			{
				throw new MatrixException("That would cause rows to be less then zero.");
			}
			
			if (columns < 0)
			{
				throw new MatrixException("That would cause columns to be less then zero.");
			}

			lock (internalMatrix)
			{
				int rCount = (internalMatrix.GetLength(0) > rows) ? rows : internalMatrix.GetLength(0);
				int cCount = (internalMatrix.GetLength(1) > columns) ? columns : internalMatrix.GetLength(1);

				T[,] newMatrix = new T[rows, columns];

				for (int r = 0; r < rCount; r++)
				{
					for (int c = 0; c < cCount; c++)
					{
						newMatrix[r, c] = internalMatrix[r, c];
					}
				}

				internalMatrix = newMatrix;
			}
		}
	}
}
