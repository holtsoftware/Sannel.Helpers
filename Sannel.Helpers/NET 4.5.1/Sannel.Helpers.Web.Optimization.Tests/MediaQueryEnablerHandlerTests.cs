using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sannel.Helpers.Web.Optimization.Tests
{
	[TestClass]
	public class MediaQueryEnablerHandlerTests
	{
		internal const String FILENAME = "TestFile.css";
		internal const String FILECONTENTS = @"/*EnableMediaQueryRemove
@media screen and (min-width: 480px)
{/**/
	h1
	{
		font-weight: bold;
	}
/*EnableMediaQueryRemove
}/**/";
		internal const String CHANGEDFILECONTENTS = @"
@media screen and (min-width: 480px)
{/**/
	h1
	{
		font-weight: bold;
	}

}/**/";
		[TestMethod]
		public void FixFileTest()
		{
			using (var stream = new StreamWriter(File.Open(FILENAME, FileMode.Create)))
			{
				stream.Write(FILECONTENTS);
			}

			MediaQueryEnablerHandlerExploser actual = new MediaQueryEnablerHandlerExploser();
			using(StringWriter writer = new StringWriter())
			{
				actual.FixFileExposed(FILENAME, writer);
				Assert.AreEqual(CHANGEDFILECONTENTS, writer.ToString());
			}
		}

		[TestMethod]
		public void ProcessRequestTest()
		{
			using (var stream = new StreamWriter(File.Open(FILENAME, FileMode.Create)))
			{
				stream.Write(FILECONTENTS);
			}

			TestHttpRequest request = new TestHttpRequest(new Uri("http://localhost/" + FILENAME, UriKind.RelativeOrAbsolute));
			TestHttpServerUtility server = new TestHttpServerUtility();
			
			using (StringWriter writer = new StringWriter())
			{
				TestHttpResponse response = new TestHttpResponse(writer);
				MediaQueryEnablerHandlerExploser actualHandler = new MediaQueryEnablerHandlerExploser();
				actualHandler.ProcessRequestExposed(request, response, server);
				Assert.AreEqual("text/css", response.ContentType);
				Assert.AreEqual(CHANGEDFILECONTENTS, writer.ToString());
			}
		}
	}
}
