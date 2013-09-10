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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace Sannel.Helpers
{
	/// <summary>
	/// Extension methods for Strings
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Try's to convert the given string to a Guid. If it cannot returns null.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static Guid? ToGuid(this String source)
		{
			if (source == null)
			{
				return null;
			}
			
			Guid g;

			if (Guid.TryParse(source, out g))
			{
				return g;
			}

			
			return null;

		}

		/// <summary>
		/// Try's to convert the given string to a Guid. If it cannot returns <paramref name="defaultValue"/>.
		/// </summary>
		/// <param name="source">The source string to use</param>
		/// <param name="defaultValue">The default value if the string cannot be converted</param>
		/// <returns></returns>
		public static Guid ToGuidOrDefault(this String source, Guid defaultValue)
		{
			if (source == null)
			{
				return defaultValue;
			}
			Guid g;

			if (Guid.TryParse(source, out g))
			{
				return g;
			}

			
			return defaultValue;
		}

		/// <summary>
		/// Try's to convert the given string to a Guid. If it cannot returns default(Guid).
		/// </summary>
		/// <param name="source">The source string to use</param>
		/// <returns></returns>
		public static Guid ToGuidOrDefault(this String source)
		{
			return ToGuidOrDefault(source, default(Guid));
		}

		/// <summary>
		/// Try's to convert the string int an int16 or returns null if it cannot
		/// </summary>
		/// <param name="source">The value.</param>
		/// <returns></returns>
		public static Int16? ToInt16(this String source)
		{
			if (source == null)
			{
				return null;
			}

			Int16 i;
			if (Int16.TryParse(source, out i))
			{
				return i;
			}

			return null;
		}

		/// <summary>
		/// Try's to convert the string int an int32 or returns null if it cannot
		/// </summary>
		/// <param name="source">The value.</param>
		/// <returns></returns>
		public static Int32? ToInt32(this String source)
		{
			if (source == null)
			{
				return null;
			}

			Int32 i;
			if (Int32.TryParse(source, out i))
			{
				return i;
			}

			return null;
		}

		/// <summary>
		/// Try's to convert the string int64 an int64 or returns null if it cannot
		/// </summary>
		/// <param name="source">The value.</param>
		/// <returns></returns>
		public static Int64? ToInt64(this String source)
		{
			if (source == null)
			{
				return null;
			}

			Int64 i;
			if (Int64.TryParse(source, out i))
			{
				return i;
			}

			return null;
		}

		/// <summary>
		/// Try's to convert the string single as Single or returns null if it cannot
		/// </summary>
		/// <param name="source">The value.</param>
		/// <returns></returns>
		public static Single? ToSingle(this String source)
		{
			if (source == null)
			{
				return null;
			}

			Single i;
			if (Single.TryParse(source, out i))
			{
				return i;
			}

			return null;
		}

		/// <summary>
		/// Try's to convert the string double as Double or returns null if it cannot
		/// </summary>
		/// <param name="source">The value.</param>
		/// <returns></returns>
		public static Double? ToDouble(this String source)
		{
			if (source == null)
			{
				return null;
			}

			Double i;
			if (Double.TryParse(source, out i))
			{
				return i;
			}

			return null;
		}

		/// <summary>
		/// Try's to convert the string decimal as Decimal or returns null if it cannot
		/// </summary>
		/// <param name="source">The value.</param>
		/// <returns></returns>
		public static Decimal? ToDecimal(this String source)
		{
			if (source == null)
			{
				return null;
			}

			Decimal i;
			if (Decimal.TryParse(source, out i))
			{
				return i;
			}

			return null;
		}

		/// <summary>
		/// Try's to parse the source string and convert it to an int 16. If it cannot returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="source">The string to parse</param>
		/// <param name="defaultValue">The default value</param>
		/// <returns>The number parsed from the string or <paramref name="defaultValue" /> if it cannot be parsed.</returns>
		public static Int16 ToInt16OrDefault(this String source, Int16 defaultValue)
		{
			if (source == null)
			{
				return defaultValue;
			}

			Int16 i;
			if (Int16.TryParse(source, out i))
			{
				return i;
			}

			return defaultValue;
		}

		/// <summary>
		/// Try's to parse the source string and convert it to an int 16. If it cannot returns default(Int16)
		/// </summary>
		/// <param name="source">The string to parse</param>
		/// <returns>The number parsed from the string or default(Int16) if it cannot be parsed.</returns>
		public static Int16 ToInt16OrDefault(this String source)
		{
			return ToInt16OrDefault(source, default(Int16));
		}

		/// <summary>
		/// Try's to parse the source string and convert it to an Int32. If it cannot returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="source">The string to parse</param>
		/// <param name="defaultValue">The default value</param>
		/// <returns>The number parsed from the string or <paramref name="defaultValue" /> if it cannot be parsed.</returns>
		public static Int32 ToInt32OrDefault(this String source, Int32 defaultValue)
		{
			if (source == null)
			{
				return defaultValue;
			}

			Int32 i;
			if (Int32.TryParse(source, out i))
			{
				return i;
			}

			return defaultValue;
		}

		/// <summary>
		/// Try's to parse the source string and convert it to an Int32. If it cannot returns default(Int32)
		/// </summary>
		/// <param name="source">The string to parse</param>
		/// <returns>The number parsed from the string or default(Int32) if it cannot be parsed.</returns>
		public static Int32 ToInt32OrDefault(this String source)
		{
			return ToInt32OrDefault(source, default(Int32));
		}

		/// <summary>
		/// Try's to parse the source string and convert it to an Int64. If it cannot returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="source">The string to parse</param>
		/// <param name="defaultValue">The default value</param>
		/// <returns>The number parsed from the string or <paramref name="defaultValue" /> if it cannot be parsed.</returns>
		public static Int64 ToInt64OrDefault(this String source, Int64 defaultValue)
		{
			if (source == null)
			{
				return defaultValue;
			}

			Int64 i;
			if (Int64.TryParse(source, out i))
			{
				return i;
			}

			return defaultValue;
		}

		/// <summary>
		/// Try's to parse the source string and convert it to an Int64. If it cannot returns default(Int64)
		/// </summary>
		/// <param name="source">The string to parse</param>
		/// <returns>The number parsed from the string or default(Int64) if it cannot be parsed.</returns>
		public static Int64 ToInt64OrDefault(this String source)
		{
			return ToInt64OrDefault(source, default(Int64));
		}

		/// <summary>
		/// Try's to parse the source string and convert it to an Single. If it cannot returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="source">The string to parse</param>
		/// <param name="defaultValue">The default value</param>
		/// <returns>The number parsed from the string or <paramref name="defaultValue" /> if it cannot be parsed.</returns>
		public static Single ToSingleOrDefault(this String source, Single defaultValue)
		{
			if (source == null)
			{
				return defaultValue;
			}

			Single i;
			if (Single.TryParse(source, out i))
			{
				return i;
			}

			return defaultValue;
		}

		/// <summary>
		/// Try's to parse the source string and convert it to an Single. If it cannot returns default(Single)
		/// </summary>
		/// <param name="source">The string to parse</param>
		/// <returns>The number parsed from the string or default(Single) if it cannot be parsed.</returns>
		public static Single ToSingleOrDefault(this String source)
		{
			return ToSingleOrDefault(source, default(Single));
		}

		/// <summary>
		/// Try's to parse the source string and convert it to an Double. If it cannot returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="source">The string to parse</param>
		/// <param name="defaultValue">The default value</param>
		/// <returns>The number parsed from the string or <paramref name="defaultValue" /> if it cannot be parsed.</returns>
		public static Double ToDoubleOrDefault(this String source, Double defaultValue)
		{
			if (source == null)
			{
				return defaultValue;
			}

			Double i;
			if (Double.TryParse(source, out i))
			{
				return i;
			}

			return defaultValue;
		}

		/// <summary>
		/// Try's to parse the source string and convert it to an Double. If it cannot returns default(Double)
		/// </summary>
		/// <param name="source">The string to parse</param>
		/// <returns>The number parsed from the string or default(Double) if it cannot be parsed.</returns>
		public static Double ToDoubleOrDefault(this String source)
		{
			return ToDoubleOrDefault(source, default(Double));
		}

		/// <summary>
		/// Try's to parse the source string and convert it to an Decimal. If it cannot returns <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="source">The string to parse</param>
		/// <param name="defaultValue">The default value</param>
		/// <returns>The number parsed from the string or <paramref name="defaultValue" /> if it cannot be parsed.</returns>
		public static Decimal ToDecimalOrDefault(this String source, Decimal defaultValue)
		{
			if (source == null)
			{
				return defaultValue;
			}

			Decimal i;
			if (Decimal.TryParse(source, out i))
			{
				return i;
			}

			return defaultValue;
		}

		/// <summary>
		/// Try's to parse the source string and convert it to an Decimal. If it cannot returns default(Decimal)
		/// </summary>
		/// <param name="source">The string to parse</param>
		/// <returns>The number parsed from the string or default(Decimal) if it cannot be parsed.</returns>
		public static Decimal ToDecimalOrDefault(this String source)
		{
			return ToDecimalOrDefault(source, default(Decimal));
		}

		/// <summary>
		/// Tries to convert the source to a UInt16. If it cannot null is returned.
		/// </summary>
		/// <param name="source">The string to convert</param>
		/// <returns></returns>
		public static UInt16? ToUInt16(this String source)
		{
			if (source == null)
			{
				return null;
			}

			UInt16 i;
			if (UInt16.TryParse(source, out i))
			{
				return i;
			}

			return null;
		}

		/// <summary>
		/// Tries to convert the source string to a UInt16. If it cannot <paramref name="defaultValue"/> is returned.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static UInt16 ToUInt16OrDefault(this String source, UInt16 defaultValue)
		{
			if (source == null)
			{
				return defaultValue;
			}

			UInt16 i;
			if (UInt16.TryParse(source, out i))
			{
				return i;
			}
			return defaultValue;
		}

		/// <summary>
		/// Tries to convert the source string to a UInt16. If it cannot default(UInt16) is returned.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static UInt16 ToUInt16OrDefault(this String source)
		{
			return ToUInt16OrDefault(source, default(UInt16));
		}

		/// <summary>
		/// Tries to convert the source to a UInt32. If it cannot null is returned.
		/// </summary>
		/// <param name="source">The string to convert</param>
		/// <returns></returns>
		public static UInt32? ToUInt32(this String source)
		{
			if (source == null)
			{
				return null;
			}

			UInt32 i;
			if (UInt32.TryParse(source, out i))
			{
				return i;
			}

			return null;
		}

		/// <summary>
		/// Tries to convert the source string to a UInt32. If it cannot <paramref name="defaultValue"/> is returned.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static UInt32 ToUInt32OrDefault(this String source, UInt32 defaultValue)
		{
			if (source == null)
			{
				return defaultValue;
			}

			UInt32 i;
			if (UInt32.TryParse(source, out i))
			{
				return i;
			}
			return defaultValue;
		}

		/// <summary>
		/// Tries to convert the source string to a UInt32. If it cannot default(UInt32) is returned.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static UInt32 ToUInt32OrDefault(this String source)
		{
			return ToUInt32OrDefault(source, default(UInt32));
		}

		/// <summary>
		/// Tries to convert the source to a UInt64. If it cannot null is returned.
		/// </summary>
		/// <param name="source">The string to convert</param>
		/// <returns></returns>
		public static UInt64? ToUInt64(this String source)
		{
			if (source == null)
			{
				return null;
			}

			UInt64 i;
			if (UInt64.TryParse(source, out i))
			{
				return i;
			}

			return null;
		}

		/// <summary>
		/// Tries to convert the source string to a UInt64. If it cannot <paramref name="defaultValue"/> is returned.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static UInt64 ToUInt64OrDefault(this String source, UInt64 defaultValue)
		{
			if (source == null)
			{
				return defaultValue;
			}

			UInt64 i;
			if (UInt64.TryParse(source, out i))
			{
				return i;
			}
			return defaultValue;
		}

		/// <summary>
		/// Tries to convert the source string to a UInt64. If it cannot default(UInt64) is returned.
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static UInt64 ToUInt64OrDefault(this String source)
		{
			return ToUInt64OrDefault(source, default(UInt64));
		}

		/// <summary>
		/// try's to convert the string to DateTime
		/// returns null if source is null or cannot convert to DateTime
		/// </summary>
		/// <param name="source">The value.</param>
		/// <returns></returns>
		public static DateTime? ToDateTime(this String source)
		{
			if (source == null)
			{
				return null;
			}

			DateTime dt;
			if (DateTime.TryParse(source, out dt))
			{
				return dt;
			}

			return null;
		}

		/// <summary>
		/// try's to convert the string to DateTime or returns <paramref name="defaultValue"/> if it cannot
		/// </summary>
		/// <param name="source">The source String</param>
		/// <param name="defaultValue">The default DateTime to use if the string cannot be converted</param>
		/// <returns></returns>
		public static DateTime ToDateTimeOrDefault(this String source, DateTime defaultValue)
		{
			if (source == null)
			{
				return defaultValue;
			}

			DateTime date;
			if (DateTime.TryParse(source, out date))
			{
				return date;
			}

			return defaultValue;
		}

		/// <summary>
		/// try's to convert the string to DateTime or returns default(DateTime) if it cannot
		/// </summary>
		/// <param name="source">The source String</param>
		/// <returns></returns>
		
		public static DateTime ToDateTimeOrDefault(this String source)
		{
			return ToDateTimeOrDefault(source, default(DateTime));
		}

		/// <summary>
		/// Creates the alpha numeric string by striping out anything that is not a-z, A-Z or 0-9
		/// if you set escapeOthers to true the values that would be striped out are changed to 0x(int value of character)
		/// 
		/// any character passed to keepCharacters will be be striped or escaped but kept in the string
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="escapeOthers">if set to <c>true</c> [escape others].</param>
		/// <param name="keepCharacters">The keep characters.</param>
		/// <returns></returns>
		public static String CreateAlphanumericString(this String source, bool escapeOthers, params char[] keepCharacters)
		{
			if (source == null)
			{
				return null;
			}

			StringBuilder builder = new StringBuilder();
			foreach (char c in source)
			{
				if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9') || c == ' ')
				{
					builder.Append(c);
				}
				else if (keepCharacters != null && keepCharacters.Contains(c))
				{
					builder.Append(c);
				}
				else if (escapeOthers)
				{

					builder.AppendFormat(CultureInfo.CurrentCulture.NumberFormat, "0x{0:00}", (int)c);
				}
			}

			return builder.ToString();
		}

		/// <summary>
		/// Creates the alpha numeric string.
		/// </summary>
		/// <param name="source">The source.</param>
		/// <param name="keepCharacters">The keep characters.</param>
		/// <returns></returns>
		public static String CreateAlphanumericString(this String source, params char[] keepCharacters)
		{
			return CreateAlphanumericString(source, false, keepCharacters);
		}
	}
}
