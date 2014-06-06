using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Sannel.Web.Optimization
{
	public class MediaQueryEnablerHandler : IHttpHandler
	{
		public bool IsReusable
		{
			get { return true; }
		}

		public void ProcessRequest(HttpContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			ProcessRequest(new HttpRequestWrapper(context.Request), new HttpResponseWrapper(context.Response), new HttpServerUtilityWrapper(context.Server));
		}

		protected virtual void ProcessRequest(HttpRequestBase request, HttpResponseBase response, HttpServerUtilityBase server)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}
			if (response == null)
			{
				throw new ArgumentNullException("response");
			}
			if (server == null)
			{
				throw new ArgumentNullException("server");
			}

			var path = request.Url.AbsolutePath.Replace(Config.CssMqFileExt, "");
			var fullPath = server.MapPath(Uri.UnescapeDataString(path));

			if (!File.Exists(fullPath))
			{
				throw new FileNotFoundException(String.Format(CultureInfo.CurrentCulture, "The file {0} was not found on the server.", path));
			}
			else
			{
				response.ContentType = "text/css";
				FixFile(fullPath, response.Output);
			}

			

		}

		protected virtual void FixFile(String fileName, TextWriter writer)
		{
			if (fileName == null)
			{
				throw new ArgumentNullException("fileName");
			}
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (!File.Exists(fileName))
			{
				throw new FileNotFoundException(String.Format(CultureInfo.CurrentCulture, "Unable to find the file {0}.", fileName));
			}

			StringBuilder builder = new StringBuilder(File.ReadAllText(fileName));
			builder.Replace(Config.ReplaceText, "");
			writer.Write(builder.ToString());
		}
	}
}
