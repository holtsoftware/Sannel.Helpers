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
