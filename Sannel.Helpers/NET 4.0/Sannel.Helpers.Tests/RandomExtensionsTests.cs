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

#if NETFX_CORE
namespace Sannel.Helpers.WinRT.Tests
#else
namespace Sannel.Helpers.Tests
#endif
{
	[TestClass]
	public class RandomExtensionsTests
	{
		[TestMethod]
		public void DefaultStringTest()
		{
			Assert.AreEqual("`1234567890-=~!@#$%^&*()_+qwertyuiop[]\\asdfghjkl;'zxcvbnm,./QWETIOP{}|ASDFGHJKL:\"ZXCVBNM<>?", RandomExtensions.DefaultGenerateString);
		}

		[TestMethod]
		public void NextStringInvalidArgsTest()
		{
			var ane = AssertHelpers.ThrowsException<ArgumentNullException>(() => { RandomExtensions.NextString(null, 0, 0, null); });
			Assert.AreEqual("random", ane.ParamName);

			Random rand = new Random();
			AssertHelpers.ThrowsException<ArgumentOutOfRangeException>(() => { RandomExtensions.NextString(rand, -1, 0, null); }).AssertIsMessage("minCharacterCount must be greater then or equal to 0\r\nParameter name: minCharacterCount");

			AssertHelpers.ThrowsException<ArgumentException>(() => { RandomExtensions.NextString(rand, 1, 0, null); }).AssertIsMessage("maxCharacterCount must be greater then or equal to minCharacterCount\r\nParameter name: maxCharacterCount");

			AssertHelpers.ThrowsException<ArgumentOutOfRangeException>(() => { RandomExtensions.NextString(rand, 0, 0, null); }).AssertIsMessage("maxCharacterCount must be greater then 0\r\nParameter name: maxCharacterCount");

			ane = AssertHelpers.ThrowsException<ArgumentNullException>(() => { RandomExtensions.NextString(rand, 0, 1, null); });

			Assert.AreEqual("source", ane.ParamName);

			AssertHelpers.ThrowsException<ArgumentOutOfRangeException>(() => { RandomExtensions.NextString(rand, 0, 1, ""); }).AssertIsMessage("sourceString must have atleast 1 character in it\r\nParameter name: source");
		}

		[TestMethod]
		public void NextStringFullTest()
		{
			Random rand = new Random();
			String actual = RandomExtensions.NextString(rand, 20, 30, "ab");

			Assert.IsNotNull(actual);
			Assert.IsTrue(actual.Length >= 20 && actual.Length < 30, "The length does not fall in the rand 20 through 29");

			for (int i = 0; i < actual.Length; i++)
			{
				Assert.IsTrue(actual[i] == 'a' || actual[i] == 'b', "The character at " + i + " is not a or b");
			}
		}

		[TestMethod]
		public void NextStringNoSourceTest()
		{
			Random rand = new Random();
			String actual = RandomExtensions.NextString(rand, 20, 30);

			Assert.IsNotNull(actual);
			Assert.IsTrue(actual.Length >= 20 && actual.Length < 30, "The length does not fall in the range 20 through 29");

			for (int i = 0; i < actual.Length; i++)
			{
				Assert.IsTrue(RandomExtensions.DefaultGenerateString.Contains(actual[i].ToString()), "The character " + actual[i] + " was not in the default generateString");
			}
		}

		[TestMethod]
		public void NextStringNoArgsTest()
		{
			Random rand = new Random();
			String actual = RandomExtensions.NextString(rand);

			Assert.IsNotNull(actual);
			Assert.IsTrue(actual.Length >= 20 && actual.Length < 255, "The land does not fall in the range 20 through 254");

			for (int i = 0; i < actual.Length; i++)
			{
				Assert.IsTrue(RandomExtensions.DefaultGenerateString.Contains(actual[i].ToString()), "The character " + actual[i] + " was not in the default generateString");
			}
		}
	}
}
