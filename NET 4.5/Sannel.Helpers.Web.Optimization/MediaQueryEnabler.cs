/*
Copyright 2013 Sannel Software, L.L.C.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/
using System;
using System.Collections.Generic;
using System.IO;
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
				var filePath = context.HttpContext.Server.MapPath(file.IncludedVirtualPath);
				if (!File.Exists(filePath))
				{
					using (var stream = new StreamReader(file.VirtualFile.Open()))
					{
						builder.Append(stream.ReadToEnd());
					}
				}
				else
				{
					using (var stream = new StreamReader(filePath))
					{
						builder.Append(stream.ReadToEnd());
					}
				}
			}

			builder.Replace(Config.ReplaceText, "");
			response.Content = builder.ToString();
		}
	}
}
