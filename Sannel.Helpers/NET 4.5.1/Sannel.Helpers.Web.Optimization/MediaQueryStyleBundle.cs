using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace Sannel.Web.Optimization
{
	public class MediaQueryStyleBundle : Bundle
	{
		public MediaQueryStyleBundle(String virtualPath)
			: base(virtualPath, new MediaQueryEnabler(), new CssMinify())
		{

		}
	}
}
