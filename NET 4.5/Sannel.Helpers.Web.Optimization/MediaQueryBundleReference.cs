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
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;

namespace Sannel.Web.Optimization
{
	public class MediaQueryBundleReference : Control
	{
		private bool useResolveClientUrl = false;
		/// <summary>
		/// If set to true the link urls will be passed to ResolveClientUrl to determine there urls
		/// If set to false the link urls will be passed to ResolveUrl to determine there urls
		/// Defaults to false
		/// </summary>
		[Description("If set to we will use ResolveClientUrl for urls if set to false will use ResolveUrl for urls")]
		public bool UseResolveClientUrl
		{ 
			get
			{
				return useResolveClientUrl;
			}
			set
			{
				useResolveClientUrl = value;
			}
		}

		[Bindable(true),
		Description("The Web Optimization path to use for generating the link styles")]
		public String Path
		{
			get;
			set;
		}

		public override void RenderControl(HtmlTextWriter writer)
		{
			var current = BundleResolver.Current;
			if (BundleTable.EnableOptimizations)
			{
				RenderLinkTag(writer, current.GetBundleUrl(Path));
			}
			else
			{
				if (current.IsBundleVirtualPath(Path))
				{
					foreach (var file in current.GetBundleContents(Path))
					{
						RenderLinkTag(writer, file + Config.CssMqFileExt);
					}
				}
				else
				{
					throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, "The Path {0} has not been registered.", Path));
				}
			}
		}

		protected void RenderLinkTag(TextWriter writer, String link)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (link == null)
			{
				throw new ArgumentNullException("link");
			}

			var fixedUrl = (UseResolveClientUrl)?ResolveClientUrl(link):ResolveUrl(link);
			writer.Write("<link href=\"{0}\" type=\"text/css\" rel=\"stylesheet\" />", HttpUtility.UrlPathEncode(fixedUrl));
		}
	}
}
