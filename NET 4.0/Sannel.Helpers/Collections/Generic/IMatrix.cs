using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sannel.Collections.Generic
{
	/// <summary>
	/// Represents a 2 dementinal array
	/// </summary>
	/// <typeparam name="T">The type of object in this 2 demential array</typeparam>
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
	public interface IMatrix<T> : IEnumerable<T>
	{
		/// <summary>
		/// Gets or sets the value at <paramref name="row"/> and <paramref name="column"/>
		/// </summary>
		/// <param name="row"></param>
		/// <param name="column"></param>
		/// <returns></returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1023:IndexersShouldNotBeMultidimensional")]
		T this[int row, int column]
		{
			get;
			set;
		}

		/// <summary>
		/// Adds a row to the matrix
		/// </summary>
		void AddRow();

		/// <summary>
		/// Adds <paramref name="count"/> rows to the matrix
		/// </summary>
		/// <param name="count">The number of rows to add</param>
		void AddRows(int count);

		/// <summary>
		/// Removes a row from the matrix
		/// </summary>
		void RemoveRow();
		
		/// <summary>
		/// Removes <paramref name="count"/> rows from the matrix
		/// </summary>
		/// <param name="count">The number of rows to remove</param>
		void RemoveRows(int count);

		/// <summary>
		/// Adds a column to the matrix
		/// </summary>
		void AddColumn();

		/// <summary>
		/// Adds <paramref name="count"/> columns to the matrix
		/// </summary>
		/// <param name="count">The number of columns to add</param>
		void AddColumns(int count);

		/// <summary>
		/// Removes a column from the matrix
		/// </summary>
		void RemoveColumn();

		/// <summary>
		/// Removes <paramref name="count"/> columns from the matrix
		/// </summary>
		/// <param name="count"></param>
		void RemoveColumns(int count);

		/// <summary>
		/// Resizes the matrix to <paramref name="rows"/> rows and <paramref name="columns"/>
		/// if rows or columns are less then 0 a MatrixException is thrown
		/// </summary>
		/// <param name="rows">The number of rows</param>
		/// <param name="columns">The number of columns</param>
		void Resize(int rows, int columns);

		/// <summary>
		/// The number of Rows in the matrix
		/// </summary>
		int Rows
		{
			get;
		}

		/// <summary>
		/// The number of Columns in the matrix
		/// </summary>
		int Columns
		{
			get;
		}

	}
}
