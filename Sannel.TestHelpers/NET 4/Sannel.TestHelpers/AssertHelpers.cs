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
#if NETFX_CORE || WINDOWS_PHONE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#elif Android
using NUnit.Framework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sannel.Helpers
{

	/// <summary>
	/// 
	/// </summary>
	public static class AssertHelpers
	{
		/// <summary>
		/// Tests to see if the exception is not null and the message matches <paramref name="message" />
		/// </summary>
		/// <param name="exception">The exception to test</param>
		/// <param name="message">The message that's expected</param>
		/// <returns></returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
		public static Exception AssertIsMessage(this Exception exception, String message)
		{
			Assert.IsNotNull(exception, "Null Exception passed to AssertHasMessage");
			Assert.AreEqual(message, exception.Message);
			return exception;
		}

		/// <summary>
		/// Executes <paramref name="code"/> and capotes any exceptions it throws and makes sure that its type matches <typeparamref name="T"/>
		/// </summary>
		/// <typeparam name="T">The type of the Exception that's expected</typeparam>
		/// <param name="code">The code to run</param>
		/// <param name="message">The message to show if the tests fail</param>
		/// <returns>The Exception thrown</returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
		public static T ThrowsException<T>(Action code, String message)
			where T : Exception
		{
#if WP8 || WP_8_1
			return Assert.ThrowsException<T>(code, message);
#elif Android
			TestDelegate d = (TestDelegate)code;
			return Assert.Throws<T>(d).AssertIsMessage(message);
#else
			if (code == null)
			{
				throw new ArgumentNullException("code");
			}

			Exception thrownException = null;
			try
			{
				code();
			}
			catch (Exception exception)
			{
				thrownException = exception;
			}
			Assert.IsNotNull(thrownException, message ?? "An exception of type {0} was not thrown.", typeof(T));
			Assert.IsInstanceOfType(thrownException, typeof(T), message ?? "The exception was not of the correct type got {0} expected {1}", thrownException.GetType(), typeof(T));

			return (T)thrownException;
#endif
		}

		/// <summary>
		/// Executes <paramref name="code"/> and capotes any exceptions it throws and makes sure that its type matches <typeparamref name="T"/>
		/// </summary>
		/// <typeparam name="T">The type of the Exception that's expected</typeparam>
		/// <param name="code">The code to run</param>
		/// <returns>The Exception thrown</returns>
		public static T ThrowsException<T>(Action code)
			where T : Exception
		{
#if WP8 || WP_8_1
			return Assert.ThrowsException<T>(code);
#elif Android
			TestDelegate d = (TestDelegate)code;
			return Assert.Throws<T>(d);
#else
			return ThrowsException<T>(code, null);
#endif
		}
	}
}
