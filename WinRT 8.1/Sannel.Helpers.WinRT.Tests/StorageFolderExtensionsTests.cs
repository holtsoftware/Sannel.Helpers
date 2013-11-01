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
using Windows.Storage;

namespace Sannel.Helpers.Tests
{
	[TestClass]
	public class StorageFolderExtensionsTests
	{
		//private String folderName = "TestFolder";

		//[TestMethod]
		//// This method was not need as its built in to winrt folder.CreateFolderAsync("", CreationCollisionOption.OpenIfExists)
		//public async Task GetFolderOrCreateAsyncTest()
		//{
		//	StorageFolder folder = null;
		//	try
		//	{
				
		//		folder = await ApplicationData.Current.LocalFolder.GetFolderAsync(folderName);
		//	}
		//	catch { } // if folderName does not exist GetFolderAsync throws an exception

		//	if (folder != null)
		//	{
		//		await folder.DeleteAsync();
		//	}

		//	folder = null;

		//	folder = await ApplicationData.Current.LocalFolder.GetFolderOrCreateAsync(folderName);

		//	Assert.IsNotNull(folder);

		//	var dateCreated = folder.DateCreated;

		//	folder = await ApplicationData.Current.LocalFolder.GetFolderOrCreateAsync(folderName);

		//	Assert.IsNotNull(folder);

		//	Assert.AreEqual(dateCreated, folder.DateCreated);

		//	Assert.ThrowsException<ArgumentNullException>(() => { StorageFolderExtensions.GetFolderOrCreateAsync(null, "Test").GetAwaiter().GetResult(); });
		//	Assert.ThrowsException<ArgumentNullException>(() => { ApplicationData.Current.LocalFolder.GetFolderOrCreateAsync(null).GetAwaiter().GetResult(); });
		//	Assert.ThrowsException<ArgumentException>(() => { ApplicationData.Current.LocalFolder.GetFolderOrCreateAsync("  ").GetAwaiter().GetResult(); });
		//}
	}
}
