using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Linq;
using System.Net.Mail;
using Sannel.Helpers;
using System.Text;

namespace Sannel.Helpers.Tests
{
	[TestClass]
	public class MailMessageExtensionsTests
	{
		private Random rand = new Random();

		private XElement generateXml(out MailMessage expected)
		{
			expected = new MailMessage();
			XElement root = new XElement("MailMessage");
			MailAddress from = new MailAddress(String.Format("{0}@{1}.com", rand.NextString(3, 8, "abcdefghijklmn"), rand.NextString(5, 12, "qrstuvwxyzab")));

			expected.From = from;
			root.Add(new XElement("From", from.ToString()));

			int count = rand.Next(2, 5);
			for (int i = 0; i < count; i++)
			{
				MailAddress address = new MailAddress(String.Format("{0}@{1}.com", rand.NextString(3, 8, "abcdefghijklmn"), rand.NextString(5, 12, "qrstuvwxyzab")));
				root.Add(new XElement("To", address.ToString()));
				expected.To.Add(address);
			}

			count = rand.Next(1, 3);
			for (int i = 0; i < count; i++)
			{
				MailAddress address = new MailAddress(String.Format("{0}@{1}.com", rand.NextString(3, 8, "abcdefghijklmn"), rand.NextString(5, 12, "qrstuvwxyzab")));
				root.Add(new XElement("CC", address.ToString()));
				expected.CC.Add(address);
			}

			count = rand.Next(1, 3);
			for (int i = 0; i < count; i++)
			{
				MailAddress address = new MailAddress(String.Format("{0}@{1}.com", rand.NextString(3, 8, "abcdefghijklmn"), rand.NextString(5, 12, "qrstuvwxyzab")));
				root.Add(new XElement("Bcc", address.ToString()));
				expected.Bcc.Add(address);
			}

			expected.IsBodyHtml = true;
			root.Add(new XElement("IsBodyHtml", "true"));

			expected.Priority = (MailPriority)rand.Next(0, 3);
			root.Add(new XElement("Priority", expected.Priority));

			StringBuilder subject = new StringBuilder();
			subject.Append(rand.NextString());
			subject.Append("${FirstName}");
			subject.Append(" ${LastName}");
			subject.Append(rand.NextString(5, 20));

			expected.Subject = subject.ToString();
			root.Add(new XElement("Subject", expected.Subject));

			StringBuilder body = new StringBuilder();
			body.Append(rand.NextString(30, 50));
			body.Append(Environment.NewLine);
			body.Append("${FirstName} ${LastName}");
			body.Append(rand.NextString(10, 20));
			body.Append("${Extra}");

			expected.Body = body.ToString();
			root.Add(new XElement("Body", expected.Body));

			return root;


			/*<MailMessage>
<To>user@test.com</To>
<From>sender@test.com</From>
<Subject>This is my test subject to ${name}</Subject>
<Body><![CDATA[
]]></Body>
<Bcc></Bcc>
<CC></CC>
<IsBodyHtml>false</IsBodyHtml>
<Priority>None</Priority>
</MailMessage>*/
		}
		[TestMethod]
		public void LoadXmlTemplate_Stream_Test()
		{
			MailMessage expected;
			var xml = generateXml(out expected);
		}
	}
}
