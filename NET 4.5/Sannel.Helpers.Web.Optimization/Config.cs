using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sannel.Web.Optimization
{
	internal static class Config
	{
		internal static String ReplaceText
		{
			get
			{
				return ConfigurationManager.AppSettings["Optimization.MediaQueryRemoveText"] ?? "/*EnableMediaQueryRemove";
			}
		}

		internal static String CssMqFileExt
		{
			get
			{
				return ConfigurationManager.AppSettings["Optimization.MediaQueryHandlerFileExt"] ?? ".cssmq";
			}
		}
	}
}
