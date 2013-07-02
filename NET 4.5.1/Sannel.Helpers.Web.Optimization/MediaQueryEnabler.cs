using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace Sannel.Web.Optimization
{
	public class MediaQueryEnabler : IBundleTransform
	{
		public void Process(BundleContext context, BundleResponse response)
		{
			if (response == null)
			{
				throw new ArgumentNullException("response");
			}

			StringBuilder builder = new StringBuilder();

			// if there is a .min(i.e. your file is min-width-700.css but there's also a min-width-700.min.css file) version of the css file Web Optimization loads content from it 
			// So load all the files from the unminified versions and let the CssMinify do the minification after we have fixed the media query comments

			foreach (var file in response.Files)
			{
				if(file.Exists)
				{
					builder.Append(System.IO.File.ReadAllText(file.FullName));
				}
			}

			builder.Replace(Config.ReplaceText, "");
			response.Content = builder.ToString();
		}
	}
}
