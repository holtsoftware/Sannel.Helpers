using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace Sannel.Helpers.Web.Optimization.Tests
{
	public class TestVirtualFile : VirtualFile
	{
		public TestVirtualFile(String virtualPath) : base(virtualPath)
		{
		}
		public override System.IO.Stream Open()
		{
			return null;
		}
	}
}
