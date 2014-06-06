using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sannel.Helpers.Web.Optimization.Tests
{
	public class TestHttpContext : HttpContextBase
	{
		public override HttpServerUtilityBase Server
		{
			get
			{
				return new TestHttpServerUtility();
			}
		}
	}
}
