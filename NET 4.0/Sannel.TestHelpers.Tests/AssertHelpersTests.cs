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
#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sannel.Helpers;
using System.IO;
#if NET_4_5 || NET_4_5_1
using System.Threading.Tasks;
#endif

namespace Sannel.TestHelpers.Tests
{
	[TestClass]
	public class AssertHelpersTests
	{
		[TestMethod]
		public void AssertIsMessageTest()
		{
			var except = new Exception("Test String");
			except.AssertIsMessage("Test String");
		}

		[TestMethod]
		public void ThrowsTest()
		{
			AssertHelpers.ThrowsException<FileNotFoundException>(() => { throw new FileNotFoundException("test"); }).AssertIsMessage("test");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void ThrowsWithNullTest()
		{
			AssertHelpers.ThrowsException<FileNotFoundException>((Action)null);
		}
	}
}
