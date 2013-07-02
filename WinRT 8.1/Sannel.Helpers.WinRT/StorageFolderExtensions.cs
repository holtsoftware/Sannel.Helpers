using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Sannel.Helpers
{
	/// <summary>
	/// Extensions for the StorageFolder class
	/// </summary>
	public static class StorageFolderExtensions
	{
		
		///// <summary>
		///// This method is not needed and has been commented out us this api call instead folder.CreateFolderAsync("", CreationCollisionOption.OpenIfExists)
		///// Creates the folder <paramref name="folderName"/> under <paramref name="folder"/> or gets it if it already exists
		///// </summary>
		///// <param name="folder">The folder to create this folder under</param>
		///// <param name="folderName">The name of the folder to get or create</param>
		///// <returns> the folder that exists or was created</returns>
		//public async static Task<StorageFolder> GetFolderOrCreateAsync(this StorageFolder folder, String folderName)
		//{
		//	if (folder == null)
		//	{
		//		throw new ArgumentNullException("folder", "folder cannot be null");
		//	}

		//	if(folderName == null)
		//	{
		//		throw new ArgumentNullException("folderName", "folderName cannot be null");
		//	}

		//	if (String.IsNullOrWhiteSpace(folderName))
		//	{
		//		throw new ArgumentException("folderName", "folderName cannot be an emptry string or all whitespace");
		//	}

			

		//	StorageFolder rfolder = null;
		//	try
		//	{
		//		rfolder = await folder.GetFolderAsync(folderName);
		//	}
		//	catch (FileNotFoundException) { } // The folder does not exists. Wish there was a folder.FolderExists

		//	if (rfolder == null)
		//	{
		//		rfolder = await folder.CreateFolderAsync(folderName);
		//	}

		//	return rfolder;
		//}
	}
}
