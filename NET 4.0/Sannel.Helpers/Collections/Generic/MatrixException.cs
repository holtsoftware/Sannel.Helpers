using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Sannel.Collections.Generic
{
	/// <summary>
	/// 
	/// </summary>
#if !NETFX_CORE && !WINDOWS_PHONE && !PORTABLE
	[Serializable]
#endif
	public class MatrixException : Exception
	{
		/// <summary>
		/// 
		/// </summary>
		public MatrixException() : base()
		{}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		public MatrixException(String message) : base(message)
		{}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="innerException"></param>
		public MatrixException(String message, Exception innerException) : base(message, innerException)
		{}

#if !NETFX_CORE && !WINDOWS_PHONE && !PORTABLE
		/// <summary>
		/// 
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected MatrixException(SerializationInfo info, StreamingContext context) : base(info, context)
		{}
#endif
	}
}
