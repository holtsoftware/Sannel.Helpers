using Sannel.Web.Optimization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sannel.Helpers.Web.Optimization.Tests
{
	public class MediaQueryEnablerHandlerExploser : MediaQueryEnablerHandler
	{
		public void FixFileExposed(String filepath, TextWriter writer)
		{
			base.FixFile(filepath, writer);
		}

		public void ProcessRequestExposed(HttpRequestBase request, HttpResponseBase response, HttpServerUtilityBase server)
		{
			base.ProcessRequest(request, response, server);
		}
	}
}
