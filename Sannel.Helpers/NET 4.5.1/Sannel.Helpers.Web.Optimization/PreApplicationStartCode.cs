using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.Web.Optimization
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class PreApplicationStartCode
	{
		private static bool startWasCalled = false;
		public static void Start()
		{
			if (!PreApplicationStartCode.startWasCalled)
			{
				PreApplicationStartCode.startWasCalled = true;
				DynamicModuleUtility.RegisterModule(typeof(MediaQueryEnablerModule));
			}
		}
	}
}
