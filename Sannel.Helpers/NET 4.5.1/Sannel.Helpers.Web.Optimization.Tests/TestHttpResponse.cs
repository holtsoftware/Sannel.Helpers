using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sannel.Helpers.Web.Optimization.Tests
{
	public class TestHttpResponse : HttpResponseBase
	{
		public TestHttpResponse(TextWriter output)
		{
			this.output = output;
		}

		private TextWriter output;

		public override System.IO.TextWriter Output
		{
			get
			{
				return output;
			}
			set
			{
				output = value;
			}
		}

		private String contentType;

		public override string ContentType
		{
			get
			{
				return contentType;
			}
			set
			{
				contentType = value;
			}
		}
	}
}
