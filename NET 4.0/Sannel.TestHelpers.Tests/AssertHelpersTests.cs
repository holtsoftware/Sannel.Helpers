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
			AssertHelpers.ThrowsException<FileNotFoundException>(null);
		}
	}
}
