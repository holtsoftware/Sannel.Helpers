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
