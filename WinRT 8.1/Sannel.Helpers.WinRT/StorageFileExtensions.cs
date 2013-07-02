﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Storage;
using System.IO;

namespace Sannel.Helpers
{
	public static class StorageFileExtensions
	{
		/// <summary>
		/// Load an XDocument from the supplied StorageFile
		/// </summary>
		/// <param name="file"></param>
		/// <returns></returns>
		public static async Task<XDocument> LoadXDocumentAsync(this StorageFile file)
		{
			if (file == null)
			{
				return null;
			}

			XDocument document = null;

			using (var irstream = await file.OpenReadAsync())
			{
				using (var rstream = irstream.AsStreamForRead())
				{
					document = XDocument.Load(rstream);
				}
			}

			return document;
		}

		/// <summary>
		/// Save an XDocument to the supplied StorageFile
		/// </summary>
		/// <param name="file">The file to save to</param>
		/// <param name="document">The XDocument to save</param>
		public static async Task SaveXDocumentAsync(this StorageFile file, XDocument document)
		{
			if (file == null)
			{
				throw new ArgumentNullException("file", "file cannot be null.");
			}

			if (document == null)
			{
				throw new ArgumentNullException("document", "document cannot be null.");
			}

			using (var irstream = await file.OpenAsync(FileAccessMode.ReadWrite))
			{
				using (var wstream = irstream.AsStreamForWrite())
				{
					document.Save(wstream);
				}
			}
		}
	}
}
