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
