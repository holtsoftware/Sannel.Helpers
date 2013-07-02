using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sannel.Helpers.Web.Optimization.Tests
{
	public class TestHttpServerUtility : HttpServerUtilityBase
	{
		public override string MapPath(string path)
		{
			String fixedPath = "";
			if (path.IndexOf("~/") == 0)
			{
				fixedPath = path.Replace("~/", Environment.CurrentDirectory);
			}
			else if (path.IndexOf('/') == 0)
			{
				fixedPath = Path.Combine(Environment.CurrentDirectory, path.Substring(1));
			}
			fixedPath = fixedPath.Replace("/", "\\");
			return fixedPath;
		}
	}
}
