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
