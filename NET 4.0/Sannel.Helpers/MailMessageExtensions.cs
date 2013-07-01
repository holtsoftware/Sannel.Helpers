using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Xml.Linq;
#if NET_4_5
using System.Threading.Tasks;
#endif

namespace Sannel.Helpers
{
	public static class MailMessageExtensions
	{
		public static void LoadXmlTemplate(this MailMessage message, Stream source)
		{
			throw new NotImplementedException("LoadXmlTemplate is going to be added in a future release of Sannel.Helpers but as of yet is not implemented");
		}

		public static void LoadXmlTemplate(this MailMessage message, String filename)
		{
			throw new NotImplementedException("LoadXmlTemplate is going to be added in a future release of Sannel.Helpers but as of yet is not implemented");
		}

		public static void LoadXmlTemplate(this MailMessage message, XElement root)
		{
			throw new NotImplementedException("LoadXmlTemplate is going to be added in a future release of Sannel.Helpers but as of yet is not implemented");
		}

		public static void ReplaceKeys(this MailMessage message, IDictionary<String, String> replacements)
		{
			throw new NotImplementedException("ReplaceKeys is going to be added in a future release of Sannel.Helpers but as of yet is not implemented");
		}

		public static void ReplaceKeys(this MailMessage message, Func<String, String> replacementCallback)
		{
			throw new NotImplementedException("ReplaceKeys is going to be added in a future release of Sannel.Helpers but as of yet is not implemented");
		}

#if NET_4_5
		public static Task LoadXmlTemplateAsync(this MailMessage message, Stream source)
		{
			throw new NotImplementedException("LoadXmlTemplateAsync is going to be added in a future release of Sannel.Helpers but as of yet is not implemented");
		}

		public static Task LoadXmlTemplateAsync(this MailMessage message, String filename)
		{
			throw new NotImplementedException("LoadXmlTemplateAsync is going to be added in a future release of Sannel.Helpers but as of yet is not implemented");
		}

		public static Task LoadXmlTemplateAsync(this MailMessage message, XElement root)
		{
			throw new NotImplementedException("LoadXmlTemplateAsync is going to be added in a future release of Sannel.Helpers but as of yet is not implemented");
		}

		public static Task ReplaceKeysAsync(this MailMessage message, IDictionary<String, String> replacements)
		{
			throw new NotImplementedException("ReplaceKeysAsync is going to be added in a future release of Sannel.Helpers but as of yet is not implemented");
		}

		public static Task ReplaceKeysAsync(this MailMessage message, Func<String, String> replacementCallback)
		{
			throw new NotImplementedException("ReplaceKeysAsync is going to be added in a future release of Sannel.Helpers but as of yet is not implemented");
		}
#endif
	}
}
