using System;
using Sannel.Collections.Generic;

#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

#if NETFX_CORE
namespace Sannel.Helpers.WinRT.Tests
#else
namespace Sannel.Helpers.Tests
#endif
{
	[TestClass]
	public class MatrixTests
	{
		private Random rand = new Random();

		[TestMethod]
		public void ConstructorTest()
		{
			IMatrix<int> matrix = new Matrix<int>();
			Assert.IsNotNull(matrix);
			Assert.AreEqual(0, matrix.Rows);
			Assert.AreEqual(0, matrix.Columns);
		}

		[TestMethod]
		public void ConstructorTest2()
		{
			int columns = 50;
			int rows = 100;
			IMatrix<int> matrix = new Matrix<int>(rows, columns);
			Assert.IsNotNull(matrix);
			Assert.AreEqual(rows, matrix.Rows);
			Assert.AreEqual(columns, matrix.Columns);

			AssertHelpers.ThrowsException<ArgumentOutOfRangeException>(() => { new Matrix<int>(-1, 20); });
			AssertHelpers.ThrowsException<ArgumentOutOfRangeException>(() => { new Matrix<int>(20, -5); });
		}

		[TestMethod]
		public void IndexerTest()
		{
			IMatrix<int> matrix = new Matrix<int>(5, 5);
			Assert.IsNotNull(matrix);

			int expected1 = 50;
			int expected2 = 34;
			int expected3 = 9;
			matrix[0, 0] = expected1;
			matrix[1, 1] = expected2;
			matrix[2, 2] = expected3;

			Assert.AreEqual(expected1, matrix[0, 0]);
			Assert.AreEqual(expected2, matrix[1, 1]);
			Assert.AreEqual(expected3, matrix[2, 2]);

			for (int i = 0; i < 20; i++)
			{
				int expected = rand.Next();
				matrix[3, 3] = expected;
				Assert.AreEqual(expected, matrix[3, 3]);
			}

			Assert.AreEqual(expected1, matrix[0, 0]);
			Assert.AreEqual(expected2, matrix[1, 1]);
			Assert.AreEqual(expected3, matrix[2, 2]);

			AssertHelpers.ThrowsException<ArgumentOutOfRangeException>(() => { var v = matrix[10, 0]; });
			AssertHelpers.ThrowsException<ArgumentOutOfRangeException>(() => { matrix[10, 0] = 7; });
			AssertHelpers.ThrowsException<ArgumentOutOfRangeException>(() => { var v = matrix[-1, 0]; });
			AssertHelpers.ThrowsException<ArgumentOutOfRangeException>(() => { matrix[-1, 0] = 8; });
			AssertHelpers.ThrowsException<ArgumentOutOfRangeException>(() => { var v = matrix[0, 50]; });
			AssertHelpers.ThrowsException<ArgumentOutOfRangeException>(() => { matrix[0, 50] = 9; });
			AssertHelpers.ThrowsException<ArgumentOutOfRangeException>(() => { var v = matrix[0, -1]; });
			AssertHelpers.ThrowsException<ArgumentOutOfRangeException>(() => { matrix[0, -1] = 10; });
		}

		[TestMethod]
		public void GetEnumeratorTest()
		{
			IMatrix<int> matrix = new Matrix<int>(10, 10);
			int number = 0;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < matrix.Columns; c++)
				{
					matrix[r, c] = number++;
				}
			}

			number = 0;
			foreach (int i in matrix)
			{
				Assert.AreEqual(number++, i);
			}

			var en = matrix.GetEnumerator();
			number = 0;
			while (en.MoveNext())
			{
				Assert.AreEqual(number++, en.Current);
			}
		}

		[TestMethod]
		public void AddColumnTest()
		{
			IMatrix<int> matrix = new Matrix<int>(10, 10);

			int number = 0;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < matrix.Columns; c++)
				{
					matrix[r, c] = number++;
				}
			}

			int numOfColumns = matrix.Columns + 1;
			matrix.AddColumn();
			Assert.AreEqual(numOfColumns, matrix.Columns);

			int column = matrix.Columns - 1;
			for (int r = 0; r < matrix.Rows; r++)
			{
				matrix[r, column] = number++;
			}

			numOfColumns = matrix.Columns - 1;
			number = 0;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < numOfColumns; c++)
				{
					Assert.AreEqual(number++, matrix[r, c]);
				}
			}

			for (int r = 0; r < matrix.Rows; r++)
			{
				Assert.AreEqual(number++, matrix[r, numOfColumns]);
			}
		}

		[TestMethod]
		public void AddColumnsTest()
		{
			IMatrix<int> matrix = new Matrix<int>(10, 10);

			int number = 0;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < matrix.Columns; c++)
				{
					matrix[r, c] = number++;
				}
			}

			int numOfColumns = matrix.Columns + 50;
			matrix.AddColumns(50);
			Assert.AreEqual(numOfColumns, matrix.Columns);

			int column = matrix.Columns - 1;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = numOfColumns - 50; c < numOfColumns; c++)
				{
					matrix[r, c] = number++;
				}
			}

			numOfColumns = matrix.Columns - 50;
			number = 0;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < numOfColumns; c++)
				{
					Assert.AreEqual(number++, matrix[r, c]);
				}
			}

			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = numOfColumns; c < matrix.Columns; c++)
				{
					Assert.AreEqual(number++, matrix[r, c]);
				}
			}
			matrix.AddColumns(-50);
			Assert.AreEqual(10, matrix.Columns);
			AssertHelpers.ThrowsException<MatrixException>(() => { matrix.AddColumns(-100); });
		}

		[TestMethod]
		public void AddRowTest()
		{
			IMatrix<int> matrix = new Matrix<int>(10, 10);

			int number = 0;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < matrix.Columns; c++)
				{
					matrix[r, c] = number++;
				}
			}

			int numOfRows = matrix.Rows + 1;
			matrix.AddRow();
			Assert.AreEqual(numOfRows, matrix.Rows);

			int row = matrix.Rows - 1;
			for (int c = 0; c < matrix.Columns; c++)
			{
				matrix[row, c] = number++;
			}

			numOfRows = matrix.Rows - 1;
			number = 0;
			for (int r = 0; r < numOfRows; r++)
			{
				for (int c = 0; c < matrix.Columns; c++)
				{
					Assert.AreEqual(number++, matrix[r, c]);
				}
			}

			for (int c = 0; c < matrix.Columns; c++)
			{
				Assert.AreEqual(number++, matrix[numOfRows, c]);
			}
		}

		[TestMethod]
		public void AddRowsTest()
		{
			IMatrix<int> matrix = new Matrix<int>(10, 10);

			int number = 0;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < matrix.Columns; c++)
				{
					matrix[r, c] = number++;
				}
			}

			int numOfRows = matrix.Rows + 50;
			matrix.AddRows(50);
			Assert.AreEqual(numOfRows, matrix.Rows);

			int row = matrix.Rows - 50;
			for (int c = 0; c < matrix.Columns; c++)
			{
				for (int r = row; r < matrix.Rows; r++)
				{
					matrix[r, c] = number++;
				}
			}

			numOfRows = matrix.Rows - 50;
			number = 0;
			for (int r = 0; r < numOfRows; r++)
			{
				for (int c = 0; c < matrix.Columns; c++)
				{
					Assert.AreEqual(number++, matrix[r, c]);
				}
			}

			for (int c = 0; c < matrix.Columns; c++)
			{
				for (int r = numOfRows; r < matrix.Rows; r++)
				{
					Assert.AreEqual(number++, matrix[r, c]);
				}
			}
			matrix.AddRows(-50);
			Assert.AreEqual(10, matrix.Rows);
			AssertHelpers.ThrowsException<MatrixException>(() => { matrix.AddRows(-150); });
		}

		[TestMethod]
		public void RemoveRowTest()
		{
			IMatrix<int> matrix = new Matrix<int>(10, 10);

			int number = 0;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < matrix.Columns; c++)
				{
					matrix[r, c] = number++;
				}
			}

			int orgRows = matrix.Rows;
			matrix.RemoveRow();
			Assert.AreEqual(orgRows - 1, matrix.Rows);

			number = 0;
			for (int r = 0; r < orgRows; r++)
			{
				for (int c = 0; c < matrix.Columns; c++)
				{
					if (r < matrix.Rows)
					{
						Assert.AreEqual(number++, matrix[r, c]);
					}
					else
					{
						number++;
					}
				}
			}

			matrix.RemoveRow(); // 8
			Assert.AreEqual(8, matrix.Rows);
			matrix.RemoveRow(); // 7
			Assert.AreEqual(7, matrix.Rows);
			matrix.RemoveRow(); // 6
			Assert.AreEqual(6, matrix.Rows);
			matrix.RemoveRow(); // 5
			Assert.AreEqual(5, matrix.Rows);
			matrix.RemoveRow(); // 4
			Assert.AreEqual(4, matrix.Rows);
			matrix.RemoveRow(); // 3
			Assert.AreEqual(3, matrix.Rows);
			matrix.RemoveRow(); // 2
			Assert.AreEqual(2, matrix.Rows);
			matrix.RemoveRow(); // 1
			Assert.AreEqual(1, matrix.Rows);
			matrix.RemoveRow(); // 0
			Assert.AreEqual(0, matrix.Rows);
			AssertHelpers.ThrowsException<MatrixException>(() => { matrix.RemoveRow(); });
		}

		[TestMethod]
		public void RemoveRowsTest()
		{
			IMatrix<int> matrix = new Matrix<int>(10, 10);

			int number = 0;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < matrix.Columns; c++)
				{
					matrix[r, c] = number++;
				}
			}

			int orgRows = matrix.Rows;
			matrix.RemoveRows(5);
			Assert.AreEqual(orgRows - 5, matrix.Rows);

			number = 0;
			for (int r = 0; r < orgRows; r++)
			{
				for (int c = 0; c < matrix.Columns; c++)
				{
					if (r < matrix.Rows)
					{
						Assert.AreEqual(number++, matrix[r, c]);
					}
					else
					{
						number++;
					}
				}
			}

			matrix.RemoveRows(5); // 0
			Assert.AreEqual(0, matrix.Rows);
			AssertHelpers.ThrowsException<MatrixException>(() => { matrix.RemoveRows(1); });

			matrix.RemoveRows(-5);
			Assert.AreEqual(5, matrix.Rows);
		}

		[TestMethod]
		public void RemoveColumnTest()
		{
			IMatrix<int> matrix = new Matrix<int>(10, 10);

			int number = 0;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < matrix.Columns; c++)
				{
					matrix[r, c] = number++;
				}
			}

			int orgColumns = matrix.Columns;
			matrix.RemoveColumn();
			Assert.AreEqual(orgColumns - 1, matrix.Columns);

			number = 0;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < orgColumns; c++)
				{
					if (c < matrix.Columns)
					{
						Assert.AreEqual(number++, matrix[r, c]);
					}
					else
					{
						number++;
					}
				}
			}

			matrix.RemoveColumn(); // 8
			Assert.AreEqual(8, matrix.Columns);
			matrix.RemoveColumn(); // 7
			Assert.AreEqual(7, matrix.Columns);
			matrix.RemoveColumn(); // 6
			Assert.AreEqual(6, matrix.Columns);
			matrix.RemoveColumn(); // 5
			Assert.AreEqual(5, matrix.Columns);
			matrix.RemoveColumn(); // 4
			Assert.AreEqual(4, matrix.Columns);
			matrix.RemoveColumn(); // 3
			Assert.AreEqual(3, matrix.Columns);
			matrix.RemoveColumn(); //2
			Assert.AreEqual(2, matrix.Columns);
			matrix.RemoveColumn(); // 1
			Assert.AreEqual(1, matrix.Columns);
			matrix.RemoveColumn(); // 0
			Assert.AreEqual(0, matrix.Columns);
			AssertHelpers.ThrowsException<MatrixException>(() => { matrix.RemoveColumn(); });
		}

		[TestMethod]
		public void RemoveColumnsTest()
		{
			IMatrix<int> matrix = new Matrix<int>(10, 10);

			int number = 0;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < matrix.Columns; c++)
				{
					matrix[r, c] = number++;
				}
			}

			int orgColumns = matrix.Columns;
			matrix.RemoveColumns(6);
			Assert.AreEqual(orgColumns - 6, matrix.Columns);

			number = 0;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < orgColumns; c++)
				{
					if (c < matrix.Columns)
					{
						Assert.AreEqual(number++, matrix[r, c]);
					}
					else
					{
						number++;
					}
				}
			}

			matrix.RemoveColumns(4); // 0
			Assert.AreEqual(0, matrix.Columns);
			AssertHelpers.ThrowsException<MatrixException>(() => { matrix.RemoveColumns(1); });

			matrix.RemoveColumns(-5); // 5
			Assert.AreEqual(5, matrix.Columns);
		}

		[TestMethod]
		public void ResizeTest()
		{
			IMatrix<int> matrix = new Matrix<int>(10, 10);

			int number = 0;
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < matrix.Columns; c++)
				{
					matrix[r, c] = number++;
				}
			}

			int orgRows = matrix.Rows;
			int orgColumns = matrix.Columns;
			matrix.Resize(20, 20);
			Assert.AreEqual(20, matrix.Rows);
			Assert.AreEqual(20, matrix.Columns);

			number = 0;
			for (int r = 0; r < orgRows; r++)
			{
				for (int c = 0; c < orgColumns; c++)
				{
					Assert.AreEqual(number++, matrix[r, c]);
				}
			}

			matrix.Resize(5, 6);

			Assert.AreEqual(5, matrix.Rows);
			Assert.AreEqual(6, matrix.Columns);

			number = 0;
			for (int r = 0; r < orgRows; r++)
			{
				if (r < matrix.Rows)
				{
					for (int c = 0; c < orgColumns; c++)
					{
						if (c < matrix.Columns)
						{
							Assert.AreEqual(number++, matrix[r, c]);
						}
						else
						{
							number++;
						}
					}
				}
			}

			AssertHelpers.ThrowsException<MatrixException>(() => { matrix.Resize(-1, 50); });
			AssertHelpers.ThrowsException<MatrixException>(() => { matrix.Resize(50, -1); });
		}
	}
}
