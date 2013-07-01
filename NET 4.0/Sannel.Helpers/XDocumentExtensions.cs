using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
#if NET_4_5 || NETFX_CORE || WP8
using System.Threading.Tasks;
#endif
#if NETFX_CORE || WP8
using Windows.Storage;
#endif

namespace Sannel.Helpers
{
#if NETFX_CORE || WP8
	public static class XDocumentExtensions
	{
		/// <summary>
		/// Saves the <paramref name="document"/> to the <paramref name="file"/>.
		/// </summary>
		/// <param name="document">The XDocument to save</param>
		/// <param name="file">The file to save to</param>
		/// <param name="options">The options passed to XDocument.Save</param>
		/// <returns></returns>
		public static async Task SaveAsync(this XDocument document, StorageFile file, SaveOptions options)
		{
			if (document == null)
			{
				throw new ArgumentNullException("document", "document cannot be null");
			}

			if (file == null)
			{
				throw new ArgumentNullException("file", "file cannot be null");
			}

			using (var irStream = await file.OpenAsync(FileAccessMode.ReadWrite))
			{
				using (var wstream = irStream.AsStreamForWrite())
				{
					document.Save(wstream, options);
				}
			}
		}

		/// <summary>
		/// Saves the <paramref name="document"/> to the <paramref name="file"/>.
		/// </summary>
		/// <param name="document">The XDocument to save</param>
		/// <param name="file">The file to save to</param>
		/// <param name="options">The options passed to XDocument.Save</param>
		/// <returns></returns>
		public static async Task SaveAsync(this XDocument document, StorageFile file)
		{
			if (document == null)
			{
				throw new ArgumentNullException("document", "document cannot be null");
			}

			if (file == null)
			{
				throw new ArgumentNullException("file", "file cannot be null");
			}

			using (var irStream = await file.OpenAsync(FileAccessMode.ReadWrite))
			{
				using (var wstream = irStream.AsStreamForWrite())
				{
					document.Save(wstream);
				}
			}
		}


	}
#endif
}
