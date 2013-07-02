using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sannel.Helpers.Web.Optimization.Tests
{
	public class TestHttpRequest : HttpRequestBase
	{
		public TestHttpRequest(Uri url)
		{
			this.url = url;
		}

		private Uri url;

		public override Uri Url
		{
			get
			{
				return url;
			}
		}
	}
}
