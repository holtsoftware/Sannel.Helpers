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
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using Windows.Storage;
using System.Xml;

namespace Sannel.Helpers.Tests
{
	[TestClass]
	public class StorageFileExtensionsTests
	{
		[TestMethod]
		public async Task LoadXDocumentAsyncTest()
		{
			StorageFile file = null;
			XDocument actual = await file.LoadXDocumentAsync();

			Assert.IsNull(actual);

			XDocument expected = new XDocument(
				new XElement("TestRoot",
					new XAttribute("Attribute1", "Attr."),
					new XElement("Element1", "MyElement"),
					new XElement("Element2", "NotMyElement")
				));

			var saveFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("LoadXDocumentAsyncTest.xml", CreationCollisionOption.ReplaceExisting);

			using (var irstream = await saveFile.OpenAsync(FileAccessMode.ReadWrite))
			{
				using (var stream = irstream.AsStreamForWrite())
				{
					expected.Save(stream);
				}
			}

			file = await ApplicationData.Current.LocalFolder.GetFileAsync("LoadXDocumentAsyncTest.xml");
			actual = await StorageFileExtensions.LoadXDocumentAsync(file);

			Assert.IsNotNull(actual);
			Assert.IsNotNull(expected.Root);
			var root = expected.Root;
			Assert.IsNotNull(root);
			Assert.AreEqual("TestRoot", root.Name);
			var attr = root.Attribute("Attribute1");
			Assert.IsNotNull(attr);
			Assert.AreEqual("Attr.", attr.Value);
			var element = root.Element("Element1");
			Assert.IsNotNull(element);
			Assert.AreEqual("MyElement", element.Value);
			element = root.Element("Element2");
			Assert.IsNotNull(element);
			Assert.AreEqual("NotMyElement", element.Value);

			file = await ApplicationData.Current.LocalFolder.CreateFileAsync("test.xml", CreationCollisionOption.ReplaceExisting);

			bool exceptionThrown = false;
			try
			{
				await file.LoadXDocumentAsync();
			}
			catch (Exception e)
			{
				Assert.IsInstanceOfType(e, typeof(XmlException));
				exceptionThrown = true;
			}

			Assert.IsTrue(exceptionThrown, "The Exception was not thrown");
		}

		[TestMethod]
		public async Task SaveXDocumentAsyncTest()
		{
			bool exceptionThrown = false;
			try
			{
				await StorageFileExtensions.SaveXDocumentAsync(null, new XDocument());
			}
			catch (Exception e)
			{
				Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
				exceptionThrown = true;
			}

			Assert.IsTrue(exceptionThrown, "The Exception was not thrown");

			exceptionThrown = false;
			try
			{
				var tfile = await ApplicationData.Current.LocalFolder.CreateFileAsync("Test.xml", CreationCollisionOption.ReplaceExisting);
				await StorageFileExtensions.SaveXDocumentAsync(tfile, null);
			}
			catch (Exception e)
			{
				Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
				exceptionThrown = true;
			}

			Assert.IsTrue(exceptionThrown, "The Exception was not thrown");

			XElement root = new XElement("XmlRoot",
				new XAttribute("version", "5"),
				new XElement("Cheese", "Lemon"),
				new XElement("Test", "This Test"));

			XDocument document = new XDocument(root);

			var testFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("TestFile.xml", CreationCollisionOption.ReplaceExisting);

			await StorageFileExtensions.SaveXDocumentAsync(testFile, document);

			document = null;

			using (var irStream = await testFile.OpenReadAsync())
			{
				using (var rstream = irStream.AsStreamForRead())
				{
					document = XDocument.Load(rstream);
				}
			}

			Assert.IsNotNull(document, "document is null");
			Assert.IsNotNull(document.Root, "root is null");

			root = document.Root;

			Assert.AreEqual("XmlRoot", root.Name);
			var attribute = root.Attribute("version");
			Assert.IsNotNull(attribute);
			Assert.AreEqual("5", attribute.Value);
			var element = root.Element("Cheese");
			Assert.IsNotNull(element);
			Assert.AreEqual("Lemon", element.Value);

			element = root.Element("Test");
			Assert.IsNotNull(element);
			Assert.AreEqual("This Test", element.Value);
		}
	}
}
