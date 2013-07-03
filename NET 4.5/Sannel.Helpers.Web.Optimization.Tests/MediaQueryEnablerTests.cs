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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sannel.Web.Optimization;
using System.Web.Optimization;
using System.IO;
using Sannel.Helpers;
using System.Collections.Generic;
using System.Web.Hosting;

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

			List<BundleFile> files = new List<BundleFile>();
			BundleFile testFile = new BundleFile("~/File1.css", new TestVirtualFile("~/File1.css"));
			using (var stream = new StreamWriter(File.OpenWrite("File1.css")))
			{
				stream.Write(MediaQueryEnablerHandlerTests.FILECONTENTS);
				stream.Flush();
			}

			files.Add(testFile);

			BundleResponse resp = new BundleResponse("", files);
			BundleCollection collection = new BundleCollection();
			BundleContext context = new BundleContext(new TestHttpContext(), collection, "~/Cheese");
			actualObject.Process(context, resp);

			Assert.AreEqual(expected, resp.Content);
		}
	}
}
