using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sannel.Web.Optimization;
using System.Web.Optimization;
using System.IO;
using Sannel.Helpers;
using System.Collections.Generic;

namespace Sannel.Helpers.Web.Optimization.Tests
{
	[TestClass]
	public class MediaQueryEnablerTests
	{
		[TestMethod]
		public void ProcessTest()
		{
			var expected = MediaQueryEnablerHandlerTests.CHANGEDFILECONTENTS;
			MediaQueryEnabler actualObject = new MediaQueryEnabler();

			var exception = AssertHelpers.ThrowsException<ArgumentNullException>(() => { actualObject.Process(null, null); });
			Assert.AreEqual("response", exception.ParamName);

			List<FileInfo> files = new List<FileInfo>();
			FileInfo testFile = new FileInfo("Test.css");
			using (var stream = new StreamWriter(testFile.OpenWrite()))
			{
				stream.Write(MediaQueryEnablerHandlerTests.FILECONTENTS);
				stream.Flush();
			}

			files.Add(testFile);

			BundleResponse resp = new BundleResponse("", files);
			actualObject.Process(null, resp);

			Assert.AreEqual(expected, resp.Content);
		}
	}
}
