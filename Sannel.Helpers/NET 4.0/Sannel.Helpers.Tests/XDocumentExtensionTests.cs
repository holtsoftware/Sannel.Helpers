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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
#if NETFX_CORE || WP8
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Windows.Storage;
using System.Xml.Linq;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

#if NETFX_CORE
namespace Sannel.Helpers.WinRT.Tests
#else
namespace Sannel.Helpers.Tests
#endif
{
	/// <summary>
	/// Summary description for XDocumentExtensionTests
	/// </summary>
	[TestClass]
	public class XDocumentExtensionTests
	{
#if NETFX_CORE || WP8
		[TestMethod]
		public async Task SaveAsyncTest()
		{
			var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("SaveAsyncTest.xml", CreationCollisionOption.ReplaceExisting);
			bool exceptionThrown = false;

			try
			{
				await XDocumentExtensions.SaveAsync(null, file);
			}
			catch (Exception e)
			{
				Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
				exceptionThrown = true;
			}

			Assert.IsTrue(exceptionThrown, "The exception was not thrown");

			XElement root = new XElement("RootXml",
				new XAttribute("version", "8"),
				new XElement("Test2", "Test2Value"),
				new XElement("Test3", "Test3 Value"));
			XDocument document = new XDocument(root);

			exceptionThrown = false;

			try
			{
				await XDocumentExtensions.SaveAsync(document, null);
			}
			catch(Exception e)
			{
				Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
				exceptionThrown = true;
			}

			Assert.IsTrue(exceptionThrown, "The exception was not thrown");

			await XDocumentExtensions.SaveAsync(document, file);

			using (var irStream = await file.OpenReadAsync())
			{
				using (var stream = irStream.AsStreamForRead())
				{
					document = XDocument.Load(stream);
				}
			}

			Assert.IsNotNull(document, "document is null");
			Assert.IsNotNull(document.Root, "root is null");

			root = document.Root;

			Assert.AreEqual("RootXml", root.Name);
			var attribute = root.Attribute("version");
			Assert.IsNotNull(attribute);
			Assert.AreEqual("8", attribute.Value);

			var element = root.Element("Test2");
			Assert.IsNotNull(element);
			Assert.AreEqual("Test2Value", element.Value);

			element = root.Element("Test3");
			Assert.IsNotNull(element);
			Assert.AreEqual("Test3 Value", element.Value);

			await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
			file = await ApplicationData.Current.LocalFolder.CreateFileAsync("SaveAsyncTest.xml", CreationCollisionOption.ReplaceExisting);

			await XDocumentExtensions.SaveAsync(document, file, SaveOptions.None);

			using (var irStream = await file.OpenReadAsync())
			{
				using (var stream = irStream.AsStreamForRead())
				{
					document = XDocument.Load(stream);
				}
			}

			Assert.IsNotNull(document, "document is null");
			Assert.IsNotNull(document.Root, "root is null");

			root = document.Root;

			Assert.AreEqual("RootXml", root.Name);
			attribute = root.Attribute("version");
			Assert.IsNotNull(attribute);
			Assert.AreEqual("8", attribute.Value);

			element = root.Element("Test2");
			Assert.IsNotNull(element);
			Assert.AreEqual("Test2Value", element.Value);

			element = root.Element("Test3");
			Assert.IsNotNull(element);
			Assert.AreEqual("Test3 Value", element.Value);
		}
#endif
	}
}
