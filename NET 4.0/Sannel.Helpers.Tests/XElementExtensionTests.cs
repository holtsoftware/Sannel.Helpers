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
#if NETFX_CORE || WP8
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif
using System.Xml.Linq;

#if NETFX_CORE
namespace Sannel.Helpers.WinRT.Tests
#else
namespace Sannel.Helpers.Tests
#endif
{
	[TestClass]
	public class XElementExtensionTests
	{
		private Random random = new Random();

		#region Element Value Tests
		[TestMethod]
		public void GetElementValueTest()
		{
			var actual = XElementExtensions.GetElementValue(null);

			Assert.IsNull(actual);

			var expected = random.NextString();

			XElement testElement = new XElement("Test");

			actual = XElementExtensions.GetElementValue(testElement);

			Assert.IsNotNull(actual);
			Assert.AreEqual(String.Empty, actual);

			testElement.Value = expected;

			actual = XElementExtensions.GetElementValue(testElement);

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetElementValueByNameTest()
		{
			String actual;

			var expected = random.NextString();

			XElement testElement = new XElement("test", new XElement("test2", expected));

			actual = XElementExtensions.GetElementValue(testElement, "test2");

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);
#if NETFX_CORE || WP8
			Assert.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetElementValue(testElement, null); });
#else
			AssertHelpers.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetElementValue(testElement, null); });
#endif

			actual = XElementExtensions.GetElementValue(testElement, "testElement52");

			Assert.IsNull(actual);

		}

		[TestMethod]
		public void GetElementValueAsInt16Test()
		{
			Int16? actial;

			Int16? expected1 = (Int16)random.Next(Int16.MaxValue);
			Int16? expected2 = (Int16)random.Next(Int16.MaxValue);

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actial = XElementExtensions.GetElementValueAsInt16(testElement, "attribute1");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);

			actial = XElementExtensions.GetElementValueAsInt16(testElement, "attribute2");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected2, actial);

			testElement = new XElement("ThisElement", expected1);
			actial = XElementExtensions.GetElementValueAsInt16(testElement);

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);
		}

		[TestMethod]
		public void GetElementValueAsInt32Test()
		{
			Int32? actial;

			Int32? expected1 = random.Next();
			Int32? expected2 = random.Next();

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actial = XElementExtensions.GetElementValueAsInt32(testElement, "attribute1");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);

			actial = XElementExtensions.GetElementValueAsInt32(testElement, "attribute2");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected2, actial);

			testElement = new XElement("ThisElement", expected1);
			actial = XElementExtensions.GetElementValueAsInt32(testElement);

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);
		}

		[TestMethod]
		public void GetElementValueAsInt64Test()
		{
			Int64? actial;

			Int64? expected1 = random.Next();
			Int64? expected2 = random.Next();

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actial = XElementExtensions.GetElementValueAsInt64(testElement, "attribute1");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);

			actial = XElementExtensions.GetElementValueAsInt64(testElement, "attribute2");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected2, actial);

			testElement = new XElement("ThisElement", expected1);
			actial = XElementExtensions.GetElementValueAsInt64(testElement);

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);
		}

		[TestMethod]
		public void GetElementValueAsSingleTest()
		{
			Single? actial;

			Single? expected1 = (Single)0.62348274927;
			Single? expected2 = (Single)23.234232;

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actial = XElementExtensions.GetElementValueAsSingle(testElement, "attribute1");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);

			actial = XElementExtensions.GetElementValueAsSingle(testElement, "attribute2");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected2, actial);

			testElement = new XElement("ThisElement", expected1);
			actial = XElementExtensions.GetElementValueAsSingle(testElement);

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);
		}

		[TestMethod]
		public void GetElementValueAsDoubleTest()
		{
			Double? actial;

			Double? expected1 = 0.204856292443;
			Double? expected2 = 322.2345628;

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actial = XElementExtensions.GetElementValueAsDouble(testElement, "attribute1");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);

			actial = XElementExtensions.GetElementValueAsDouble(testElement, "attribute2");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected2, actial);

			testElement = new XElement("ThisElement", expected1);
			actial = XElementExtensions.GetElementValueAsDouble(testElement);

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);
		}

		[TestMethod]
		public void GetElementValueAsDecimalTest()
		{
			Decimal? actial;

			Decimal? expected1 = 0.123237492m;
			Decimal? expected2 = 12347.212432m;

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actial = XElementExtensions.GetElementValueAsDecimal(testElement, "attribute1");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);

			actial = XElementExtensions.GetElementValueAsDecimal(testElement, "attribute2");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected2, actial);

			testElement = new XElement("ThisElement", expected1);
			actial = XElementExtensions.GetElementValueAsDecimal(testElement);

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);
		}

		[TestMethod]
		public void GetElementValueAsInt16OrDefaultTest()
		{
			Int16 expected1 = 52;
			Int16 expected2 = 22;

			Int16 actual;

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actual = XElementExtensions.GetElementValueAsInt16OrDefault(testElement, "attribute1", -500);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsInt16OrDefault(testElement, "attribute2");

			Assert.AreEqual(expected2, actual);

			testElement = new XElement("test", expected2);
			actual = XElementExtensions.GetElementValueAsInt16OrDefault(testElement);

			Assert.AreEqual(expected2, actual);

			actual = XElementExtensions.GetElementValueAsInt16OrDefault(null, expected1);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsInt16OrDefault(null);

			Assert.AreEqual(default(Int16), actual);
		}

		[TestMethod]
		public void GetElementValueAsInt32OrDefaultTest()
		{
			Int32 expected1 = 83;
			Int32 expected2 = 01;

			Int32 actual;

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actual = XElementExtensions.GetElementValueAsInt32OrDefault(testElement, "attribute1", -500);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsInt32OrDefault(testElement, "attribute2");

			Assert.AreEqual(expected2, actual);

			testElement = new XElement("test", expected2);
			actual = XElementExtensions.GetElementValueAsInt32OrDefault(testElement);

			Assert.AreEqual(expected2, actual);

			actual = XElementExtensions.GetElementValueAsInt32OrDefault(null, expected1);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsInt32OrDefault(null);

			Assert.AreEqual(default(Int32), actual);
		}

		[TestMethod]
		public void GetElementValueAsInt64OrDefaultTest()
		{
			Int64 expected1 = 83;
			Int64 expected2 = 01;

			Int64 actual;

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actual = XElementExtensions.GetElementValueAsInt64OrDefault(testElement, "attribute1", -500);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsInt64OrDefault(testElement, "attribute2");

			Assert.AreEqual(expected2, actual);

			testElement = new XElement("test", expected2);
			actual = XElementExtensions.GetElementValueAsInt64OrDefault(testElement);

			Assert.AreEqual(expected2, actual);

			actual = XElementExtensions.GetElementValueAsInt64OrDefault(null, expected1);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsInt64OrDefault(null);

			Assert.AreEqual(default(Int64), actual);
		}

		[TestMethod]
		public void GetElementValueAsSingleOrDefaultTest()
		{
			Single expected1 = (Single)83.832;
			Single expected2 = (Single)01.23424;

			Single actual;

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actual = XElementExtensions.GetElementValueAsSingleOrDefault(testElement, "attribute1", -500);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsSingleOrDefault(testElement, "attribute2");

			Assert.AreEqual(expected2, actual);

			testElement = new XElement("test", expected2);
			actual = XElementExtensions.GetElementValueAsSingleOrDefault(testElement);

			Assert.AreEqual(expected2, actual);

			actual = XElementExtensions.GetElementValueAsSingleOrDefault(null, expected1);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsSingleOrDefault(null);

			Assert.AreEqual(default(Single), actual);
		}

		[TestMethod]
		public void GetElementValueAsDoubleOrDefaultTest()
		{
			Double expected1 = 32.23434235;
			Double expected2 = 0.24323421;

			Double actual;

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actual = XElementExtensions.GetElementValueAsDoubleOrDefault(testElement, "attribute1", -500);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsDoubleOrDefault(testElement, "attribute2");

			Assert.AreEqual(expected2, actual);

			testElement = new XElement("test", expected2);
			actual = XElementExtensions.GetElementValueAsDoubleOrDefault(testElement);

			Assert.AreEqual(expected2, actual);

			actual = XElementExtensions.GetElementValueAsDoubleOrDefault(null, expected1);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsDoubleOrDefault(null);

			Assert.AreEqual(default(Double), actual);
		}

		[TestMethod]
		public void GetElementValueAsDecimalOrDefaultTest()
		{
			Decimal expected1 = 324342.2342353455m;
			Decimal expected2 = 0.2423425234545m;

			Decimal actual;

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actual = XElementExtensions.GetElementValueAsDecimalOrDefault(testElement, "attribute1", -500);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsDecimalOrDefault(testElement, "attribute2");

			Assert.AreEqual(expected2, actual);

			testElement = new XElement("test", expected2);
			actual = XElementExtensions.GetElementValueAsDecimalOrDefault(testElement);

			Assert.AreEqual(expected2, actual);

			actual = XElementExtensions.GetElementValueAsDecimalOrDefault(null, expected1);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsDecimalOrDefault(null);

			Assert.AreEqual(default(Decimal), actual);
		}

		[TestMethod]
		public void GetElementValueAsDataTimeTest()
		{
			var actual = XElementExtensions.GetElementValueAsDateTime(null);

			Assert.IsNull(actual);

			var expected = new DateTime(1970, 1, 20);

			XElement element = new XElement("testElement", expected.ToString());

			actual = XElementExtensions.GetElementValueAsDateTime(element);

			Assert.AreEqual(expected, actual);

			expected = new DateTime(1964, 11, 22);

			element = new XElement("root", new XElement("node1", expected));

			actual = XElementExtensions.GetElementValueAsDateTime(element, "node1");

			Assert.AreEqual(expected, actual);

			actual = XElementExtensions.GetElementValueAsDateTime(element, "node2");

			Assert.IsNull(actual);
#if NETFX_CORE || WP8
			Assert.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetElementValueAsDateTime(element, null); });
#else
			AssertHelpers.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetElementValueAsDateTime(element, null); });
#endif
		}

		[TestMethod]
		public void GetElementValueAsDateTimeOrDefaultTest()
		{
			var expected = new DateTime(1924, 2, 12, 5, 6, 1);

			var actual = XElementExtensions.GetElementValueAsDateTimeOrDefault(null, expected);

			Assert.AreEqual(expected, actual);

			var testElement = new XElement("test2", expected.ToString());

			actual = XElementExtensions.GetElementValueAsDateTimeOrDefault(testElement, DateTime.MinValue);

			Assert.AreEqual(expected, actual);

			actual = XElementExtensions.GetElementValueAsDateTimeOrDefault(testElement);

			Assert.AreEqual(expected, actual);

			expected = default(DateTime);

			actual = XElementExtensions.GetElementValueAsDateTimeOrDefault(null);

			Assert.AreEqual(expected, actual);

			expected = new DateTime(1311, 03, 23);

			testElement = new XElement("root", new XElement("node1", expected));

			actual = XElementExtensions.GetElementValueAsDateTimeOrDefault(testElement, "node1", DateTime.Now);

			Assert.AreEqual(expected, actual);

			actual = XElementExtensions.GetElementValueAsDateTimeOrDefault(testElement, "node1");

			Assert.AreEqual(expected, actual);

			expected = DateTime.Now;

			actual = XElementExtensions.GetElementValueAsDateTimeOrDefault(testElement, "node2", expected);

			Assert.AreEqual(expected, actual);

			expected = default(DateTime);

			actual = XElementExtensions.GetElementValueAsDateTimeOrDefault(testElement, "node2");

			Assert.AreEqual(expected, actual);

#if NETFX_CORE || WP8
			Assert.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetElementValueAsDateTimeOrDefault(null, null as String); });
						 
			Assert.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetElementValueAsDateTimeOrDefault(null, null as String, DateTime.MinValue); });
#else
			AssertHelpers.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetElementValueAsDateTimeOrDefault(null, null as String); });

			AssertHelpers.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetElementValueAsDateTimeOrDefault(null, null as String, DateTime.MinValue); });
#endif
		}

		[TestMethod]
		public void GetElementValueAsGuidTest()
		{
			var expected = Guid.NewGuid();

			var actual = XElementExtensions.GetElementValueAsGuid(null);

			Assert.IsNull(actual);

			var element = new XElement("test", "cheese");

			actual = XElementExtensions.GetElementValueAsGuid(element);

			Assert.IsNull(actual);

			element.Value = expected.ToString();

			actual = XElementExtensions.GetElementValueAsGuid(element);

			Assert.AreEqual(expected, actual);

			expected = Guid.NewGuid();

			actual = XElementExtensions.GetElementValueAsGuid(null, "");

			Assert.IsNull(actual);

			element = new XElement("root", new XElement("node1", expected));

			actual = XElementExtensions.GetElementValueAsGuid(element, "node1");

			Assert.AreEqual(expected, actual);

			actual = XElementExtensions.GetElementValueAsGuid(element, "node2");

			Assert.IsNull(actual);
#if NETFX_CORE || WP8
			Assert.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetElementValueAsGuid(null, null); });
#else
			AssertHelpers.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetElementValueAsGuid(null, null); });
#endif
		}

		[TestMethod]
		public void GetElementValueAsGuidOrDefaultTest()
		{
			var expected = Guid.NewGuid();

			var actual = XElementExtensions.GetElementValueAsGuidOrDefault(null, expected);

			Assert.AreEqual(expected, actual);

			var element = new XElement("test", "cheese");

			actual = XElementExtensions.GetElementValueAsGuidOrDefault(element, expected);

			Assert.AreEqual(expected, actual);

			element.Value = expected.ToString();

			actual = XElementExtensions.GetElementValueAsGuidOrDefault(element, Guid.Empty);

			Assert.AreEqual(expected, actual);

			actual = XElementExtensions.GetElementValueAsGuidOrDefault(element);

			Assert.AreEqual(expected, actual);

			expected = default(Guid);

			actual = XElementExtensions.GetElementValueAsGuidOrDefault(null);

			Assert.AreEqual(expected, actual);

			expected = Guid.NewGuid();

			actual = XElementExtensions.GetElementValueAsGuidOrDefault(null, "cheese", expected);

			Assert.AreEqual(expected, actual);

			element = new XElement("root", new XElement("node1", expected));

			actual = XElementExtensions.GetElementValueAsGuidOrDefault(element, "node1", Guid.Empty);

			Assert.AreEqual(expected, actual); 

			actual = XElementExtensions.GetElementValueAsGuidOrDefault(element, "node1");

			Assert.AreEqual(expected, actual);

			expected = Guid.NewGuid();

			actual = XElementExtensions.GetElementValueAsGuidOrDefault(element, "node2", expected);

			Assert.AreEqual(expected, actual);

			expected = default(Guid);

			actual = XElementExtensions.GetElementValueAsGuidOrDefault(element, "node2");

			Assert.AreEqual(expected, actual);
#if NETFX_CORE || WP8
			Assert.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetElementValueAsGuidOrDefault(null, null, Guid.Empty); });
			Assert.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetElementValueAsGuidOrDefault(null, null); });
#else
			AssertHelpers.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetElementValueAsGuidOrDefault(null, null, Guid.Empty); });

			AssertHelpers.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetElementValueAsGuidOrDefault(null, null); });
#endif
		}

		[TestMethod]
		public void GetElementValueAsUInt16Test()
		{
			UInt16? actual = XElementExtensions.GetElementValueAsUInt16(null);

			Assert.IsNull(actual);

			actual = XElementExtensions.GetElementValueAsUInt16(new XElement("Test", "abc"));

			Assert.IsNull(actual);

			UInt16? expected1 = (UInt16)random.Next(UInt16.MaxValue);

			actual = XElementExtensions.GetElementValueAsUInt16(new XElement("Test", expected1.ToString()));

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected1, actual);
			
			expected1 = (UInt16)random.Next();
			UInt16? expected2 = (UInt16)random.Next();

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actual = XElementExtensions.GetElementValueAsUInt16(testElement, "attribute1");

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsUInt16(testElement, "attribute2");

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetElementValueAsUInt16OrDefaultTest()
		{
			UInt16 expected1 = 6;
			UInt16 expected2 = 8;
			UInt16 actual = XElementExtensions.GetElementValueAsUInt16OrDefault(null, expected1);

			Assert.AreEqual(expected1, actual);

			expected1 = (UInt16)random.Next(UInt16.MaxValue);
			actual = XElementExtensions.GetElementValueAsUInt16OrDefault(new XElement("Test", ""), expected1);

			Assert.AreEqual(expected1, actual);

			expected1 = (UInt16)random.Next(UInt16.MaxValue);
			actual = XElementExtensions.GetElementValueAsUInt16OrDefault(new XElement("Test", "abc"), expected1);

			Assert.AreEqual(expected1, actual);

			expected1 = (UInt16)random.Next(50);
			expected2 = (UInt16)random.Next(51, 100);
			actual = XElementExtensions.GetElementValueAsUInt16OrDefault(new XElement("Test", expected1), expected2);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsUInt16OrDefault(new XElement("Test", ""));

			Assert.AreEqual(default(UInt16), actual);

			actual = XElementExtensions.GetElementValueAsUInt16OrDefault(new XElement("Test", expected1));

			Assert.AreEqual(expected1, actual);

			var elements = new XElement("Test",
				new XElement("SubElement1", expected1),
				new XElement("SubElement2", expected2));

			actual = XElementExtensions.GetElementValueAsUInt16OrDefault(elements, "SubElement3", 150);

			Assert.AreEqual(150, actual);

			actual = XElementExtensions.GetElementValueAsUInt16OrDefault(elements, "SubElement1", 123);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsUInt16OrDefault(elements, "SubElement2", 123);

			Assert.AreEqual(expected2, actual);

			actual = XElementExtensions.GetElementValueAsUInt16OrDefault(elements, "SubElement3");

			Assert.AreEqual(default(UInt16), actual);

			actual = XElementExtensions.GetElementValueAsUInt16OrDefault(elements, "SubElement1");

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsUInt16OrDefault(elements, "SubElement2");

			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetElementValueAsUInt32Test()
		{
			UInt32? actual = XElementExtensions.GetElementValueAsUInt32(null);

			Assert.IsNull(actual);

			actual = XElementExtensions.GetElementValueAsUInt32(new XElement("Test", "abc"));

			Assert.IsNull(actual);

			UInt32? expected1 = (UInt32)random.Next();

			actual = XElementExtensions.GetElementValueAsUInt32(new XElement("Test", expected1.ToString()));

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected1, actual);

			expected1 = (UInt32)random.Next();
			UInt32? expected2 = (UInt32)random.Next();

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actual = XElementExtensions.GetElementValueAsUInt32(testElement, "attribute1");

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsUInt32(testElement, "attribute2");

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetElementValueAsUInt32OrDefaultTest()
		{
			UInt32 expected1 = 6;
			UInt32 expected2 = 8;
			UInt32 actual = XElementExtensions.GetElementValueAsUInt32OrDefault(null, expected1);

			Assert.AreEqual(expected1, actual);

			expected1 = (UInt32)random.Next();
			actual = XElementExtensions.GetElementValueAsUInt32OrDefault(new XElement("Test", ""), expected1);

			Assert.AreEqual(expected1, actual);

			expected1 = (UInt32)random.Next();
			actual = XElementExtensions.GetElementValueAsUInt32OrDefault(new XElement("Test", "abc"), expected1);

			Assert.AreEqual(expected1, actual);

			expected1 = (UInt32)random.Next(50);
			expected2 = (UInt32)random.Next(51, 100);
			actual = XElementExtensions.GetElementValueAsUInt32OrDefault(new XElement("Test", expected1), expected2);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsUInt32OrDefault(new XElement("Test", ""));

			Assert.AreEqual(default(UInt32), actual);

			actual = XElementExtensions.GetElementValueAsUInt32OrDefault(new XElement("Test", expected1));

			Assert.AreEqual(expected1, actual);

			var elements = new XElement("Test",
				new XElement("SubElement1", expected1),
				new XElement("SubElement2", expected2));

			actual = XElementExtensions.GetElementValueAsUInt32OrDefault(elements, "SubElement3", 150);

			Assert.AreEqual((UInt32)150, actual);

			actual = XElementExtensions.GetElementValueAsUInt32OrDefault(elements, "SubElement1", 123);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsUInt32OrDefault(elements, "SubElement2", 123);

			Assert.AreEqual(expected2, actual);

			actual = XElementExtensions.GetElementValueAsUInt32OrDefault(elements, "SubElement3");

			Assert.AreEqual(default(UInt32), actual);

			actual = XElementExtensions.GetElementValueAsUInt32OrDefault(elements, "SubElement1");

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsUInt32OrDefault(elements, "SubElement2");

			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetElementValueAsUInt64Test()
		{
			UInt64? actual = XElementExtensions.GetElementValueAsUInt64(null);

			Assert.IsNull(actual);

			actual = XElementExtensions.GetElementValueAsUInt64(new XElement("Test", "abc"));

			Assert.IsNull(actual);

			UInt64? expected1 = (UInt64)random.Next();

			actual = XElementExtensions.GetElementValueAsUInt64(new XElement("Test", expected1.ToString()));

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected1, actual);

			expected1 = (UInt64)random.Next();
			UInt64? expected2 = (UInt64)random.Next();

			var testElement = new XElement("test",
				new XElement("attribute1", expected1),
				new XElement("attribute2", expected2));

			actual = XElementExtensions.GetElementValueAsUInt64(testElement, "attribute1");

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsUInt64(testElement, "attribute2");

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetElementValueAsUInt64OrDefaultTest()
		{
			UInt64 expected1 = 6;
			UInt64 expected2 = 8;
			UInt64 actual = XElementExtensions.GetElementValueAsUInt64OrDefault(null, expected1);

			Assert.AreEqual(expected1, actual);

			expected1 = (UInt64)random.Next();
			actual = XElementExtensions.GetElementValueAsUInt64OrDefault(new XElement("Test", ""), expected1);

			Assert.AreEqual(expected1, actual);

			expected1 = (UInt64)random.Next();
			actual = XElementExtensions.GetElementValueAsUInt64OrDefault(new XElement("Test", "abc"), expected1);

			Assert.AreEqual(expected1, actual);

			expected1 = (UInt64)random.Next(50);
			expected2 = (UInt64)random.Next(51, 100);
			actual = XElementExtensions.GetElementValueAsUInt64OrDefault(new XElement("Test", expected1), expected2);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsUInt64OrDefault(new XElement("Test", ""));

			Assert.AreEqual(default(UInt64), actual);

			actual = XElementExtensions.GetElementValueAsUInt64OrDefault(new XElement("Test", expected1));

			Assert.AreEqual(expected1, actual);

			var elements = new XElement("Test",
				new XElement("SubElement1", expected1),
				new XElement("SubElement2", expected2));

			actual = XElementExtensions.GetElementValueAsUInt64OrDefault(elements, "SubElement3", 150);

			Assert.AreEqual((UInt64)150, actual);

			actual = XElementExtensions.GetElementValueAsUInt64OrDefault(elements, "SubElement1", 123);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsUInt64OrDefault(elements, "SubElement2", 123);

			Assert.AreEqual(expected2, actual);

			actual = XElementExtensions.GetElementValueAsUInt64OrDefault(elements, "SubElement3");

			Assert.AreEqual(default(UInt64), actual);

			actual = XElementExtensions.GetElementValueAsUInt64OrDefault(elements, "SubElement1");

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetElementValueAsUInt64OrDefault(elements, "SubElement2");

			Assert.AreEqual(expected2, actual);
		}

		#endregion
		#region Attribute Value Tests
		[TestMethod]
		public void GetAttributeValueTest()
		{
			String actual;

			var expected = random.NextString();

			var testElement = new XElement("test", new XAttribute("testAttribute", expected));

			actual = XElementExtensions.GetAttributeValue(testElement, "testAttribute");

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected, actual);
#if NETFX_CORE || WP8
			Assert.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetAttributeValue(testElement, null); });
#else
			AssertHelpers.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetAttributeValue(testElement, null); });
#endif

			actual = XElementExtensions.GetAttributeValue(testElement, "attribute1");

			Assert.IsNull(actual);
		}

		[TestMethod]
		public void GetAttributeValueAsInt16Test()
		{
			Int16? actial;

			Int16? expected1 = (Int16)random.Next(Int16.MaxValue);
			Int16? expected2 = (Int16)random.Next(Int16.MaxValue);

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actial = XElementExtensions.GetAttributeValueAsInt16(testElement, "attribute1");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);

			actial = XElementExtensions.GetAttributeValueAsInt16(testElement, "attribute2");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected2, actial);
		}

		[TestMethod]
		public void GetAttributeValueAsInt32Test()
		{
			Int32? actial;

			Int32? expected1 = random.Next();
			Int32? expected2 = random.Next();

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actial = XElementExtensions.GetAttributeValueAsInt32(testElement, "attribute1");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);

			actial = XElementExtensions.GetAttributeValueAsInt32(testElement, "attribute2");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected2, actial);
		}

		[TestMethod]
		public void GetAttributeValueAsInt64Test()
		{
			Int64? actial;

			Int64? expected1 = random.Next();
			Int64? expected2 = random.Next();

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actial = XElementExtensions.GetAttributeValueAsInt64(testElement, "attribute1");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);

			actial = XElementExtensions.GetAttributeValueAsInt64(testElement, "attribute2");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected2, actial);
		}

		[TestMethod]
		public void GetAttributeValueAsSingleTest()
		{
			Single? actial;

			Single? expected1 = (Single)0.62348274927;
			Single? expected2 = (Single)23.234232;

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actial = XElementExtensions.GetAttributeValueAsSingle(testElement, "attribute1");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);

			actial = XElementExtensions.GetAttributeValueAsSingle(testElement, "attribute2");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected2, actial);
		}

		[TestMethod]
		public void GetAttributeValueAsDoubleTest()
		{
			Double? actial;

			Double? expected1 = 0.204856292443;
			Double? expected2 = 322.2345628;

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actial = XElementExtensions.GetAttributeValueAsDouble(testElement, "attribute1");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);

			actial = XElementExtensions.GetAttributeValueAsDouble(testElement, "attribute2");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected2, actial);
		}

		[TestMethod]
		public void GetAttributeValueAsDecimalTest()
		{
			Decimal? actial;

			Decimal? expected1 = 0.123237492m;
			Decimal? expected2 = 12347.212432m;

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actial = XElementExtensions.GetAttributeValueAsDecimal(testElement, "attribute1");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected1, actial);

			actial = XElementExtensions.GetAttributeValueAsDecimal(testElement, "attribute2");

			Assert.IsNotNull(actial);
			Assert.AreEqual(expected2, actial);
		}

		[TestMethod]
		public void GetAttributeValueAsInt16OrDefaultTest()
		{
			Int16 expected1 = 52;
			Int16 expected2 = 22;

			Int16 actual;

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actual = XElementExtensions.GetAttributeValueAsInt16OrDefault(testElement, "attribute1", -500);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsInt16OrDefault(testElement, "attribute2");

			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetAttributeValueAsInt32OrDefaultTest()
		{
			Int32 expected1 = 83;
			Int32 expected2 = 01;

			Int32 actual;

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actual = XElementExtensions.GetAttributeValueAsInt32OrDefault(testElement, "attribute1", -500);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsInt32OrDefault(testElement, "attribute2");

			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetAttributeValueAsInt64OrDefaultTest()
		{
			Int64 expected1 = 83;
			Int64 expected2 = 01;

			Int64 actual;

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actual = XElementExtensions.GetAttributeValueAsInt64OrDefault(testElement, "attribute1", -500);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsInt64OrDefault(testElement, "attribute2");

			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetAttributeValueAsSingleOrDefaultTest()
		{
			Single expected1 = (Single)83.832;
			Single expected2 = (Single)01.23424;

			Single actual;

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actual = XElementExtensions.GetAttributeValueAsSingleOrDefault(testElement, "attribute1", -500);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsSingleOrDefault(testElement, "attribute2");

			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetAttributeValueAsDoubleOrDefaultTest()
		{
			Double expected1 = 32.23434235;
			Double expected2 = 0.24323421;

			Double actual;

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actual = XElementExtensions.GetAttributeValueAsDoubleOrDefault(testElement, "attribute1", -500);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsDoubleOrDefault(testElement, "attribute2");

			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetAttributeValueAsDecimalOrDefaultTest()
		{
			Decimal expected1 = 324342.2342353455m;
			Decimal expected2 = 0.2423425234545m;

			Decimal actual = 0;

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actual = XElementExtensions.GetAttributeValueAsDecimalOrDefault(testElement, "attribute1", -500);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsDecimalOrDefault(testElement, "attribute2");

			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetAttributeValueAsDateTimeTest()
		{
			var expected = new DateTime(2032, 5, 25);

			DateTime? actual;

			var element = new XElement("node", new XAttribute("attribute1", expected));

			actual = XElementExtensions.GetAttributeValueAsDateTime(element, "attribute1");

			Assert.AreEqual(expected, actual);

			actual = XElementExtensions.GetAttributeValueAsDateTime(element, "attribute2");

			Assert.IsNull(actual);
#if NETFX_CORE || WP8
			Assert.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetAttributeValueAsDateTime(element, null); });
#else
			AssertHelpers.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetAttributeValueAsDateTime(element, null); });
#endif
		}

		[TestMethod]
		public void GetAttributeValueAsDateTimeOrDefaultTest()
		{
			var expected = new DateTime(1234, 6, 25);

			DateTime? actual;

			var element = new XElement("node", new XAttribute("attribute1", expected));

			actual = XElementExtensions.GetAttributeValueAsDateTimeOrDefault(element, "attribute1", DateTime.MinValue);

			Assert.AreEqual(expected, actual);

			actual = XElementExtensions.GetAttributeValueAsDateTimeOrDefault(element, "attribute1");

			Assert.AreEqual(expected, actual);

			actual = XElementExtensions.GetAttributeValueAsDateTimeOrDefault(element, "attribute2", DateTime.MaxValue);

			Assert.AreEqual(DateTime.MaxValue, actual);

			actual = XElementExtensions.GetAttributeValueAsDateTimeOrDefault(element, "attribute2");

			Assert.AreEqual(default(DateTime), actual);

#if NETFX_CORE || WP8
			Assert.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetAttributeValueAsDateTimeOrDefault(element, null, DateTime.MinValue); });
			Assert.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetAttributeValueAsDateTimeOrDefault(element, null); });
#else
			AssertHelpers.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetAttributeValueAsDateTimeOrDefault(element, null, DateTime.MinValue); });
			AssertHelpers.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetAttributeValueAsDateTimeOrDefault(element, null); });
#endif
		}

		[TestMethod]
		public void GetAttributeValueAsGuidTest()
		{
			var expected = Guid.NewGuid();

			Guid? actual;

			var element = new XElement("node", new XAttribute("attribute1", expected));

			actual = XElementExtensions.GetAttributeValueAsGuid(element, "attribute1");

			Assert.AreEqual(expected, actual);

			actual = XElementExtensions.GetAttributeValueAsGuid(element, "attribute2");

			Assert.IsNull(actual);

#if NETFX_CORE || WP8
			Assert.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetAttributeValueAsGuid(element, null); });
#else
			AssertHelpers.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetAttributeValueAsGuid(element, null); });
#endif
		}

		[TestMethod]
		public void GetAttributeValueAsGuidOrDefaultTest()
		{
			var expected = Guid.NewGuid();

			Guid actual;

			var element = new XElement("node", new XAttribute("attribute1", expected));

			actual = XElementExtensions.GetAttributeValueAsGuidOrDefault(element, "attribute1", Guid.Empty);

			Assert.AreEqual(expected, actual);

			actual = XElementExtensions.GetAttributeValueAsGuidOrDefault(element, "attribute1");

			Assert.AreEqual(expected, actual);

			expected = Guid.NewGuid();

			actual = XElementExtensions.GetAttributeValueAsGuidOrDefault(element, "attribute2", expected);

			Assert.AreEqual(expected, actual);

			actual = XElementExtensions.GetAttributeValueAsGuidOrDefault(element, "attribute2");

			Assert.AreEqual(default(Guid), actual);
#if NETFX_CORE || WP8
			Assert.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetAttributeValueAsGuidOrDefault(element, null); });
			Assert.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetAttributeValueAsGuidOrDefault(element, null, Guid.Empty); });
#else
			AssertHelpers.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetAttributeValueAsGuidOrDefault(element, null); });
			AssertHelpers.ThrowsException<ArgumentNullException>(() => { XElementExtensions.GetAttributeValueAsGuidOrDefault(element, null, Guid.Empty); });
#endif
		}

		[TestMethod]
		public void GetAttributeValueAsUInt16Test()
		{
			UInt16? actual = 0;

			UInt16? expected1 = (UInt16)random.Next();
			UInt16? expected2 = (UInt16)random.Next();

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actual = XElementExtensions.GetAttributeValueAsUInt16(testElement, "attribute1");

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt16(testElement, "attribute2");

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetAttributeValueAsUInt16OrDefaultTest()
		{
			UInt16 expected1 = 6;
			UInt16 expected2 = 8;
			UInt16 actual = 0;

			expected1 = (UInt16)random.Next(50);
			expected2 = (UInt16)random.Next(51, 100);

			var elements = new XElement("Test",
				new XAttribute("SubElement1", expected1),
				new XAttribute("SubElement2", expected2));

			actual = XElementExtensions.GetAttributeValueAsUInt16OrDefault(elements, "SubElement3", 150);

			Assert.AreEqual((UInt16)150, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt16OrDefault(elements, "SubElement1", 123);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt16OrDefault(elements, "SubElement2", 123);

			Assert.AreEqual(expected2, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt16OrDefault(elements, "SubElement3");

			Assert.AreEqual(default(UInt16), actual);

			actual = XElementExtensions.GetAttributeValueAsUInt16OrDefault(elements, "SubElement1");

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt16OrDefault(elements, "SubElement2");

			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetAttributeValueAsUInt32Test()
		{
			UInt32? actual = 0;

			UInt32? expected1 = (UInt32)random.Next();
			UInt32? expected2 = (UInt32)random.Next();

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actual = XElementExtensions.GetAttributeValueAsUInt32(testElement, "attribute1");

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt32(testElement, "attribute2");

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetAttributeValueAsUInt32OrDefaultTest()
		{
			UInt32 expected1 = 6;
			UInt32 expected2 = 8;
			UInt32 actual = 0;

			expected1 = (UInt32)random.Next(50);
			expected2 = (UInt32)random.Next(51, 100);

			var elements = new XElement("Test",
				new XAttribute("SubElement1", expected1),
				new XAttribute("SubElement2", expected2));

			actual = XElementExtensions.GetAttributeValueAsUInt32OrDefault(elements, "SubElement3", 150);

			Assert.AreEqual((UInt32)150, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt32OrDefault(elements, "SubElement1", 123);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt32OrDefault(elements, "SubElement2", 123);

			Assert.AreEqual(expected2, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt32OrDefault(elements, "SubElement3");

			Assert.AreEqual(default(UInt32), actual);

			actual = XElementExtensions.GetAttributeValueAsUInt32OrDefault(elements, "SubElement1");

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt32OrDefault(elements, "SubElement2");

			Assert.AreEqual(expected2, actual);
		}


		[TestMethod]
		public void GetAttributeValueAsUInt64Test()
		{
			UInt64? actual = 0;

			UInt64? expected1 = (UInt64)random.Next();
			UInt64? expected2 = (UInt64)random.Next();

			var testElement = new XElement("test",
				new XAttribute("attribute1", expected1),
				new XAttribute("attribute2", expected2));

			actual = XElementExtensions.GetAttributeValueAsUInt64(testElement, "attribute1");

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt64(testElement, "attribute2");

			Assert.IsNotNull(actual);
			Assert.AreEqual(expected2, actual);
		}

		[TestMethod]
		public void GetAttributeValueAsUInt64OrDefaultTest()
		{
			UInt64 expected1 = 6;
			UInt64 expected2 = 8;
			UInt64 actual = 0;

			expected1 = (UInt64)random.Next(50);
			expected2 = (UInt64)random.Next(51, 100);

			var elements = new XElement("Test",
				new XAttribute("SubElement1", expected1),
				new XAttribute("SubElement2", expected2));

			actual = XElementExtensions.GetAttributeValueAsUInt64OrDefault(elements, "SubElement3", 150);

			Assert.AreEqual((UInt64)150, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt64OrDefault(elements, "SubElement1", 123);

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt64OrDefault(elements, "SubElement2", 123);

			Assert.AreEqual(expected2, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt64OrDefault(elements, "SubElement3");

			Assert.AreEqual(default(UInt64), actual);

			actual = XElementExtensions.GetAttributeValueAsUInt64OrDefault(elements, "SubElement1");

			Assert.AreEqual(expected1, actual);

			actual = XElementExtensions.GetAttributeValueAsUInt64OrDefault(elements, "SubElement2");

			Assert.AreEqual(expected2, actual);
		}
		#endregion
	}
}
