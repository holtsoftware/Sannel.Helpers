using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sannel.Web.Optimization
{
	public class MediaQueryEnablerModule : IHttpModule
	{
		public void Dispose()
		{
			
		}

		public void Init(HttpApplication context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}

			context.PostResolveRequestCache += OnPostResolveRequestCache;
		}

		void OnPostResolveRequestCache(object sender, EventArgs e)
		{
			HttpApplication application = (HttpApplication)sender;
			var url = application.Request.Url;
			var absolutePath = url.AbsolutePath;
			if (absolutePath.EndsWith(Config.CssMqFileExt, true, CultureInfo.CurrentCulture))
			{
				application.Context.RemapHandler(new MediaQueryEnablerHandler());
			}
		}
	}
}
