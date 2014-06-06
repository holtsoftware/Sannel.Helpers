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
using System.Text;
using System.Collections.Generic;
using System.Linq;
#if NETFX_CORE || WP8
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
	/// <summary>
	/// Summary description for StringExtensionsTests
	/// </summary>
	[TestClass]
	public class StringExtensionsTests
	{
		private static Random random = new Random();

		[TestMethod]
		public void ToGuidNullTest()
		{
			Guid? actual = StringExtensions.ToGuid(null);

			Assert.IsNull(actual);
		}

		[TestMethod]
		public void ToGuidTest()
		{
			Guid? actual = StringExtensions.ToGuid(null);

			Assert.IsNull(actual);

			actual = StringExtensions.ToGuid("");

			Assert.IsNull(actual);

			actual = StringExtensions.ToGuid("cheese");

			Assert.IsNull(actual);

			actual = StringExtensions.ToGuid("1487A45K14304ECF86EE17B54AF9B9B0");

			Assert.IsNull(actual);

			Guid? expected = new Guid("1487A451-1430-4ECF-86EE-17B54AF9B9B0");

			actual = StringExtensions.ToGuid("1487A45114304ECF86EE17B54AF9B9B0");

			Assert.IsNotNull(actual);

			Assert.AreEqual(expected, actual);

			expected = new Guid("E61F9893-950F-44E3-BA25-D380BF85640B");

			actual = StringExtensions.ToGuid("E61F9893-950F-44E3-BA25-D380BF85640B");

			Assert.IsNotNull(actual);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToGuidOrDefaultTest()
		{
			var expected = Guid.NewGuid();

			Guid actual = StringExtensions.ToGuidOrDefault(null, expected);

			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToGuidOrDefault(expected.ToString(), Guid.Empty);

			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToGuidOrDefault("test", expected);

			Assert.AreEqual(expected, actual);

			expected = default(Guid);

			actual = StringExtensions.ToGuidOrDefault("test2");

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToInt16Test()
		{
			Int16? actual = StringExtensions.ToInt16(null);

			Assert.IsNull(actual);

			actual = StringExtensions.ToInt16("");

			Assert.IsNull(actual);

			actual = StringExtensions.ToInt16("abc");

			Assert.IsNull(actual);

			Int16? expected = (Int16)random.Next(0, Int16.MaxValue);

			actual = StringExtensions.ToInt16(expected.ToString());

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);

			expected = (Int16)random.Next(0, Int16.MaxValue);
			expected *= -1;

			actual = StringExtensions.ToInt16(expected.ToString());

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToInt32Test()
		{
			int? actual = StringExtensions.ToInt32(null);

			Assert.IsNull(actual);

			actual = StringExtensions.ToInt32("");

			Assert.IsNull(actual);

			actual = StringExtensions.ToInt32("abc");

			Assert.IsNull(actual);

			int? expected = random.Next();

			actual = StringExtensions.ToInt32(expected.ToString());

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);

			expected = random.Next() * -1;

			actual = StringExtensions.ToInt32(expected.ToString());

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToInt64Test()
		{
			Int64? actual = StringExtensions.ToInt64(null);

			Assert.IsNull(actual);

			actual = StringExtensions.ToInt64("");

			Assert.IsNull(actual);

			actual = StringExtensions.ToInt64("abc");

			Assert.IsNull(actual);

			Int64? expected = random.Next();

			actual = StringExtensions.ToInt64(expected.ToString());

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);

			expected = random.Next() * -1;

			actual = StringExtensions.ToInt64(expected.ToString());

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToSingleTest()
		{
			Single? actual = StringExtensions.ToSingle(null);

			Assert.IsNull(actual);

			actual = StringExtensions.ToSingle("");

			Assert.IsNull(actual);

			actual = StringExtensions.ToSingle("abc");

			Assert.IsNull(actual);

			Single? expected = (Single)Math.Round(random.NextDouble() * 100, 5);

			actual = StringExtensions.ToSingle(expected.ToString());

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);

			expected = (Single)Math.Round(random.NextDouble() * -100, 5);

			actual = StringExtensions.ToSingle(expected.ToString());

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToDoubleTest()
		{
			Double? actual = StringExtensions.ToDouble(null);

			Assert.IsNull(actual);

			actual = StringExtensions.ToDouble("");

			Assert.IsNull(actual);

			actual = StringExtensions.ToDouble("abc");

			Assert.IsNull(actual);

			Double? expected = 322.234234234;

			actual = StringExtensions.ToDouble(expected.ToString());

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);

			expected = -10000.3243;

			actual = StringExtensions.ToDouble(expected.ToString());

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToDecimalTest()
		{
			Decimal? actual = StringExtensions.ToDecimal(null);

			Assert.IsNull(actual);

			actual = StringExtensions.ToDecimal("");

			Assert.IsNull(actual);

			actual = StringExtensions.ToDecimal("abs");

			Assert.IsNull(actual);

			Decimal? expected = (Decimal)random.NextDouble();

			actual = StringExtensions.ToDecimal(expected.ToString());

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);

			expected = (Decimal)random.NextDouble();

			actual = StringExtensions.ToDecimal(expected.ToString());

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToInt16OrDefaultTest()
		{
			Int16 expected = 5;
			Int16 actual = StringExtensions.ToInt16OrDefault(null, expected);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToInt16OrDefault("", expected);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToInt16OrDefault("abc", expected);
			Assert.AreEqual(expected, actual);

			expected = (Int16)random.Next(Int16.MaxValue);
			actual = StringExtensions.ToInt16OrDefault(expected.ToString(), -500);
			Assert.AreEqual(expected, actual);

			expected = default(Int16);
			actual = StringExtensions.ToInt16OrDefault(null);
			Assert.AreEqual(expected, actual);

			expected = -600;
			actual = StringExtensions.ToInt16OrDefault(null, expected);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToInt32OrDefaultTest()
		{
			Int32 expected = 5;
			Int32 actual = StringExtensions.ToInt32OrDefault(null, expected);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToInt32OrDefault("", expected);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToInt32OrDefault("abc", expected);
			Assert.AreEqual(expected, actual);

			expected = (Int32)random.Next(Int32.MaxValue);
			actual = StringExtensions.ToInt32OrDefault(expected.ToString(), -500);
			Assert.AreEqual(expected, actual);

			expected = default(Int32);
			actual = StringExtensions.ToInt32OrDefault(null);
			Assert.AreEqual(expected, actual);

			expected = -600;
			actual = StringExtensions.ToInt32OrDefault(null, expected);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToInt64OrDefaultTest()
		{
			Int64 expected = 5;
			Int64 actual = StringExtensions.ToInt64OrDefault(null, expected);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToInt64OrDefault("", expected);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToInt64OrDefault("abc", expected);
			Assert.AreEqual(expected, actual);

			expected = (Int64)random.Next();
			actual = StringExtensions.ToInt64OrDefault(expected.ToString(), -500);
			Assert.AreEqual(expected, actual);

			expected = default(Int64);
			actual = StringExtensions.ToInt64OrDefault(null);
			Assert.AreEqual(expected, actual);

			expected = -600;
			actual = StringExtensions.ToInt64OrDefault(null, expected);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToSingleOrDefaultTest()
		{
			Single expected = 5;
			Single actual = StringExtensions.ToSingleOrDefault(null, expected);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToSingleOrDefault("", expected);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToSingleOrDefault("abc", expected);
			Assert.AreEqual(expected, actual);

			expected = (Single)32.23424;

			actual = StringExtensions.ToSingleOrDefault(expected.ToString(), -500);
			Assert.AreEqual(expected, actual);

			expected = default(Single);
			actual = StringExtensions.ToSingleOrDefault(null);
			Assert.AreEqual(expected, actual);

			expected = -600;
			actual = StringExtensions.ToSingleOrDefault(null, expected);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToDoubleOrDefaultTest()
		{
			Double expected = 5;
			Double actual = StringExtensions.ToDoubleOrDefault(null, expected);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToDoubleOrDefault("", expected);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToDoubleOrDefault("abc", expected);
			Assert.AreEqual(expected, actual);

			expected = Math.Round(random.NextDouble() * 1000, 5); // Double.TryParse does not always produce the exact number as expected so round to 5 points precision points
			actual = StringExtensions.ToDoubleOrDefault(expected.ToString(), -500);
			Assert.AreEqual(expected, actual);

			expected = default(Double);
			actual = StringExtensions.ToDoubleOrDefault(null);
			Assert.AreEqual(expected, actual);

			expected = -600;
			actual = StringExtensions.ToDoubleOrDefault(null, expected);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToDecimalOrDefaultTest()
		{
			Decimal expected = 5;
			Decimal actual = StringExtensions.ToDecimalOrDefault(null, expected);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToDecimalOrDefault("", expected);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToDecimalOrDefault("abc", expected);
			Assert.AreEqual(expected, actual);

			expected = (Decimal)Math.Round(random.NextDouble() * 1000, 5); // Decimal.TryParse does not always produce the exact number as expected so round to 5 points precision points
			actual = StringExtensions.ToDecimalOrDefault(expected.ToString(), -500);
			Assert.AreEqual(expected, actual);

			expected = default(Decimal);
			actual = StringExtensions.ToDecimalOrDefault(null);
			Assert.AreEqual(expected, actual);

			expected = -600;
			actual = StringExtensions.ToDecimalOrDefault(null, expected);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToUInt16Test()
		{
			UInt16? expected = 6;
			UInt16? actual = StringExtensions.ToUInt16(null);
			Assert.IsNull(actual);

			actual = StringExtensions.ToUInt16("");
			Assert.IsNull(actual);

			actual = StringExtensions.ToUInt16("abc");
			Assert.IsNull(actual);

			actual = StringExtensions.ToUInt16(expected.ToString());
			Assert.AreEqual(expected, actual);

			expected = (UInt16)random.Next(0, UInt16.MaxValue);
			actual = StringExtensions.ToUInt16(expected.ToString());
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToUInt16OrDefaultTest()
		{
			UInt16 expected = 8;
			UInt16 actual = StringExtensions.ToUInt16OrDefault(null, expected);
			Assert.AreEqual(expected, actual);

			expected = 9;
			actual = StringExtensions.ToUInt16OrDefault("", expected);
			Assert.AreEqual(expected, actual);

			expected = 10;
			actual = StringExtensions.ToUInt16OrDefault("abc", expected);
			Assert.AreEqual(expected, actual);

			expected = 60;
			actual = StringExtensions.ToUInt16OrDefault(expected.ToString(), 100);
			Assert.AreEqual(expected, actual);

			expected = default(UInt16);
			actual = StringExtensions.ToUInt16OrDefault(null);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToUInt16OrDefault("");
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToUInt16OrDefault("abc");
			Assert.AreEqual(expected, actual);

			expected = 15;
			actual = StringExtensions.ToUInt16OrDefault(expected.ToString());
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToUInt32Test()
		{
			UInt32? expected = 6;
			UInt32? actual = StringExtensions.ToUInt32(null);
			Assert.IsNull(actual);

			actual = StringExtensions.ToUInt32("");
			Assert.IsNull(actual);

			actual = StringExtensions.ToUInt32("abc");
			Assert.IsNull(actual);

			actual = StringExtensions.ToUInt32(expected.ToString());
			Assert.AreEqual(expected, actual);

			expected = (UInt32)random.Next(0, 500);
			actual = StringExtensions.ToUInt32(expected.ToString());
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToUInt32OrDefaultTest()
		{
			UInt32 expected = 8;
			UInt32 actual = StringExtensions.ToUInt32OrDefault(null, expected);
			Assert.AreEqual(expected, actual);

			expected = 9;
			actual = StringExtensions.ToUInt32OrDefault("", expected);
			Assert.AreEqual(expected, actual);

			expected = 10;
			actual = StringExtensions.ToUInt32OrDefault("abc", expected);
			Assert.AreEqual(expected, actual);

			expected = 60;
			actual = StringExtensions.ToUInt32OrDefault(expected.ToString(), 100);
			Assert.AreEqual(expected, actual);

			expected = default(UInt32);
			actual = StringExtensions.ToUInt32OrDefault(null);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToUInt32OrDefault("");
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToUInt32OrDefault("abc");
			Assert.AreEqual(expected, actual);

			expected = 15;
			actual = StringExtensions.ToUInt32OrDefault(expected.ToString());
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToUInt64Test()
		{
			UInt64? expected = 6;
			UInt64? actual = StringExtensions.ToUInt64(null);
			Assert.IsNull(actual);

			actual = StringExtensions.ToUInt64("");
			Assert.IsNull(actual);

			actual = StringExtensions.ToUInt64("abc");
			Assert.IsNull(actual);

			actual = StringExtensions.ToUInt64(expected.ToString());
			Assert.AreEqual(expected, actual);

			expected = (UInt64)random.Next(0, 500);
			actual = StringExtensions.ToUInt64(expected.ToString());
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToUInt64OrDefaultTest()
		{
			UInt64 expected = 8;
			UInt64 actual = StringExtensions.ToUInt64OrDefault(null, expected);
			Assert.AreEqual(expected, actual);

			expected = 9;
			actual = StringExtensions.ToUInt64OrDefault("", expected);
			Assert.AreEqual(expected, actual);

			expected = 10;
			actual = StringExtensions.ToUInt64OrDefault("abc", expected);
			Assert.AreEqual(expected, actual);

			expected = 60;
			actual = StringExtensions.ToUInt64OrDefault(expected.ToString(), 100);
			Assert.AreEqual(expected, actual);

			expected = default(UInt64);
			actual = StringExtensions.ToUInt64OrDefault(null);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToUInt64OrDefault("");
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToUInt64OrDefault("abc");
			Assert.AreEqual(expected, actual);

			expected = 15;
			actual = StringExtensions.ToUInt64OrDefault(expected.ToString());
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToDateTimeTest()
		{
			DateTime? actual = StringExtensions.ToDateTime(null);

			Assert.IsNull(actual);

			actual = StringExtensions.ToDateTime("");

			Assert.IsNull(actual);

			DateTime? expected = new DateTime(2000, 02, 05);

			actual = StringExtensions.ToDateTime(expected.Value.ToString());

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);

			expected = new DateTime(2000, 05, 06, 8, 34, 20);

			actual = StringExtensions.ToDateTime(expected.ToString());

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToDateTimeOrDefaultTest()
		{
			DateTime expected = DateTime.Now;

			var actual = StringExtensions.ToDateTimeOrDefault(null, expected);

			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToDateTimeOrDefault("this is not a datetime", expected);

			Assert.AreEqual(expected, actual);

			expected = new DateTime(expected.Year, expected.Month, expected.Day, expected.Hour, expected.Minute, expected.Second);

			actual = StringExtensions.ToDateTimeOrDefault(expected.ToString(), DateTime.MinValue);

			Assert.AreEqual(expected, actual);

			actual = StringExtensions.ToDateTimeOrDefault(expected.ToString());

			Assert.AreEqual(expected, actual);

			expected = default(DateTime);

			actual = StringExtensions.ToDateTimeOrDefault(null);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void CreateAlphanumericStringTest()
		{
			String actual = StringExtensions.CreateAlphanumericString(null, false);

			Assert.IsNull(actual);

			actual = StringExtensions.CreateAlphanumericString(null);

			Assert.IsNull(actual);

			var expected = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			var beforeConversion = "A-B+C_D)E(F*G&H^I%J$K#L@M!N`O~P|Q]R}S[T{U'V\"W;X:Y,Z<a>b/c?d\\e=f-ghijklmnopqrstuvwxyz0123456789";
			actual = StringExtensions.CreateAlphanumericString(beforeConversion, false);

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.CreateAlphanumericString(beforeConversion);

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);

			expected = "A-BC_DEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz 0___1---2===3456789";
			beforeConversion = "A-B+C_D)E(F*G&H^I%J$K#L@M!N`O~P|Q]R}S[T{U'V\"W;X:Y,Z<a>b/c?d\\efghijklmnopqrstuvwxyz 0___1---2===3456789";

			actual = StringExtensions.CreateAlphanumericString(beforeConversion, false, '_', '-', '=');

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.CreateAlphanumericString(beforeConversion, '_', '-', '=');

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);

			expected = "Hello Brown Fox0x33";
			beforeConversion = "Hello Brown Fox!";

			actual = StringExtensions.CreateAlphanumericString(beforeConversion, true);

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);

			actual = StringExtensions.CreateAlphanumericString(beforeConversion, true, null);

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);

			expected = "Hello Brown Fox";

			actual = StringExtensions.CreateAlphanumericString(beforeConversion, null);

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);
		}
	}
}
