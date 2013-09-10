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
using System.Text;
using System.Xml.Linq;
#if NETFX_CORE || WP8 
using System.Threading.Tasks;
using Windows.Storage;
#endif

namespace Sannel.Helpers
{
	/// <summary>
	/// Static class that contains Extension methods for XElement
	/// </summary>
	public static class XElementExtensions
	{
		#region Element Value
		/// <summary>
		/// Returns the String value of this element or null if <paramref name="element"/> is null. If this element has no value returns null.
		/// </summary>
		/// <param name="element">The element to get the value from</param>
		/// <returns>The String value of this element</returns>
		public static String GetElementValue(this XElement element)
		{
			if (element == null)
			{
				return null;
			}

			return element.Value;
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Int16 or null.
		/// </summary>
		/// <param name="element"></param>
		/// <returns>The Int16 value or null if it cannot be converted.</returns>
		public static Int16? GetElementValueAsInt16(this XElement element)
		{
			return GetElementValue(element).ToInt16();
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Int32 or null.
		/// </summary>
		/// <param name="element"></param>
		/// <returns>The Int32 value or null if it cannot be converted.</returns>
		public static Int32? GetElementValueAsInt32(this XElement element)
		{
			return GetElementValue(element).ToInt32();
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Int64 or null.
		/// </summary>
		/// <param name="element"></param>
		/// <returns>The Int64 value or null if it cannot be converted.</returns>
		public static Int64? GetElementValueAsInt64(this XElement element)
		{
			return GetElementValue(element).ToInt64();
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Single or null.
		/// </summary>
		/// <param name="element"></param>
		/// <returns>The Single value or null if it cannot be converted.</returns>
		public static Single? GetElementValueAsSingle(this XElement element)
		{
			return GetElementValue(element).ToSingle();
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Double or null.
		/// </summary>
		/// <param name="element"></param>
		/// <returns>The Double value or null if it cannot be converted.</returns>
		public static Double? GetElementValueAsDouble(this XElement element)
		{
			return GetElementValue(element).ToDouble();
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Decimal or null.
		/// </summary>
		/// <param name="element"></param>
		/// <returns>The Decimal value or null if it cannot be converted.</returns>
		public static Decimal? GetElementValueAsDecimal(this XElement element)
		{
			return GetElementValue(element).ToDecimal();
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Int16 or <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="element">The XElement to get the value from</param>
		/// <param name="defaultValue">The value to return when the value of <paramref name="element"/> cannot be converted.</param>
		/// <returns>The Int16 value of <paramref name="element" /> or <paramref name="defaultValue"/> if it cannot be converted.</returns>
		public static Int16 GetElementValueAsInt16OrDefault(this XElement element, Int16 defaultValue)
		{
			return GetElementValue(element).ToInt16OrDefault(defaultValue);
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Int16 or default(Int16)
		/// </summary>
		/// <param name="element">The XElement to get the value from</param>
		/// <returns>The Int16 value of <paramref name="element" /> or default(Int16) if it cannot be converted.</returns>
		public static Int16 GetElementValueAsInt16OrDefault(this XElement element)
		{
			return GetElementValueAsInt16OrDefault(element, default(Int16));
		}


		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Int32 or <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="element">The XElement to get the value from</param>
		/// <param name="defaultValue">The value to return when the value of <paramref name="element"/> cannot be converted.</param>
		/// <returns>The Int32 value of <paramref name="element" /> or <paramref name="defaultValue"/> if it cannot be converted.</returns>
		public static Int32 GetElementValueAsInt32OrDefault(this XElement element, Int32 defaultValue)
		{
			return GetElementValue(element).ToInt32OrDefault(defaultValue);
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Int32 or default(Int32)
		/// </summary>
		/// <param name="element">The XElement to get the value from</param>
		/// <returns>The Int32 value of <paramref name="element" /> or default(Int32) if it cannot be converted.</returns>
		public static Int32 GetElementValueAsInt32OrDefault(this XElement element)
		{
			return GetElementValueAsInt32OrDefault(element, default(Int32));
		}
		
		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Int64 or <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="element">The XElement to get the value from</param>
		/// <param name="defaultValue">The value to return when the value of <paramref name="element"/> cannot be converted.</param>
		/// <returns>The Int64 value of <paramref name="element" /> or <paramref name="defaultValue"/> if it cannot be converted.</returns>
		public static Int64 GetElementValueAsInt64OrDefault(this XElement element, Int64 defaultValue)
		{
			return GetElementValue(element).ToInt64OrDefault(defaultValue);
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Int64 or default(Int64)
		/// </summary>
		/// <param name="element">The XElement to get the value from</param>
		/// <returns>The Int64 value of <paramref name="element" /> or default(Int64) if it cannot be converted.</returns>
		public static Int64 GetElementValueAsInt64OrDefault(this XElement element)
		{
			return GetElementValueAsInt64OrDefault(element, default(Int64));
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Single or <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="element">The XElement to get the value from</param>
		/// <param name="defaultValue">The value to return when the value of <paramref name="element"/> cannot be converted.</param>
		/// <returns>The Single value of <paramref name="element" /> or <paramref name="defaultValue"/> if it cannot be converted.</returns>
		public static Single GetElementValueAsSingleOrDefault(this XElement element, Single defaultValue)
		{
			return GetElementValue(element).ToSingleOrDefault(defaultValue);
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Single or default(Single)
		/// </summary>
		/// <param name="element">The XElement to get the value from</param>
		/// <returns>The Single value of <paramref name="element" /> or default(Single) if it cannot be converted.</returns>
		public static Single GetElementValueAsSingleOrDefault(this XElement element)
		{
			return GetElementValueAsSingleOrDefault(element, default(Single));
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Double or <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="element">The XElement to get the value from</param>
		/// <param name="defaultValue">The value to return when the value of <paramref name="element"/> cannot be converted.</param>
		/// <returns>The Double value of <paramref name="element" /> or <paramref name="defaultValue"/> if it cannot be converted.</returns>
		public static Double GetElementValueAsDoubleOrDefault(this XElement element, Double defaultValue)
		{
			return GetElementValue(element).ToDoubleOrDefault(defaultValue);
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Double or default(Double)
		/// </summary>
		/// <param name="element">The XElement to get the value from</param>
		/// <returns>The Double value of <paramref name="element" /> or default(Double) if it cannot be converted.</returns>
		public static Double GetElementValueAsDoubleOrDefault(this XElement element)
		{
			return GetElementValueAsDoubleOrDefault(element, default(Double));
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Decimal or <paramref name="defaultValue"/>
		/// </summary>
		/// <param name="element">The XElement to get the value from</param>
		/// <param name="defaultValue">The value to return when the value of <paramref name="element"/> cannot be converted.</param>
		/// <returns>The Decimal value of <paramref name="element" /> or <paramref name="defaultValue"/> if it cannot be converted.</returns>
		public static Decimal GetElementValueAsDecimalOrDefault(this XElement element, Decimal defaultValue)
		{
			return GetElementValue(element).ToDecimalOrDefault(defaultValue);
		}

		/// <summary>
		/// Returns the value of the <paramref name="element"/> as an Decimal or default(Decimal)
		/// </summary>
		/// <param name="element">The XElement to get the value from</param>
		/// <returns>The Decimal value of <paramref name="element" /> or default(Decimal) if it cannot be converted.</returns>
		public static Decimal GetElementValueAsDecimalOrDefault(this XElement element)
		{
			return GetElementValueAsDecimalOrDefault(element, default(Decimal));
		}

		/// <summary>
		/// Returns the value of <paramref name="element"/> as a DateTime or null if it cannot be converted
		/// </summary>
		/// <param name="element">The XElement to get the value from</param>
		/// <returns></returns>
		public static DateTime? GetElementValueAsDateTime(this XElement element)
		{
			return GetElementValue(element).ToDateTime();
		}

		/// <summary>
		/// Returns the element value as a DateTime or <paramref name="defaultValue"/> if it cannot
		/// </summary>
		/// <param name="element">the XElement to get the value from</param>
		/// <param name="defaultValue">The default value to return if there's an error converting.</param>
		/// <returns></returns>
		public static DateTime GetElementValueAsDateTimeOrDefault(this XElement element, DateTime defaultValue)
		{
			if (element == null)
			{
				return defaultValue;
			}

			return GetElementValue(element).ToDateTimeOrDefault(defaultValue);
		}

		/// <summary>
		/// Returns the element value as a DateTime or default(DateTime) if it cannot
		/// </summary>
		/// <param name="element">the XElement to get the value from</param>
		/// <returns></returns>
		public static DateTime GetElementValueAsDateTimeOrDefault(this XElement element)
		{
			return GetElementValueAsDateTimeOrDefault(element, default(DateTime));
		}

		/// <summary>
		/// Returns the element value as a Guid or returns null if it cannot be converted
		/// </summary>
		/// <param name="element">The element to get the value from</param>
		/// <returns></returns>
		public static Guid? GetElementValueAsGuid(this XElement element)
		{
			if(element == null)
			{
				return null;
			}

			return GetElementValue(element).ToGuid();
		}

		/// <summary>
		/// Returns the element value as a Guid or the <paramref name="defaultValue"/> if it cannot
		/// </summary>
		/// <param name="element">The element to get the value from</param>
		/// <param name="defaultValue">The default value to return if the value cannot be converted</param>
		/// <returns></returns>
		public static Guid GetElementValueAsGuidOrDefault(this XElement element, Guid defaultValue)
		{
			if (element == null)
			{
				return defaultValue;
			}

			return GetElementValue(element).ToGuidOrDefault(defaultValue);
		}

		/// <summary>
		/// Returns the element value as a Guid or default(Guid) if it cannot
		/// </summary>
		/// <param name="element">The element to get the value from</param>
		/// <returns></returns>
		public static Guid GetElementValueAsGuidOrDefault(this XElement element)
		{
			return GetElementValueAsGuidOrDefault(element, default(Guid));
		}

		/// <summary>
		/// Returns the string value of the sub element with name <paramref name="subElementName"/> or null if element is null or sub element is not found
		/// </summary>
		/// <param name="element">The parent element</param>
		/// <param name="subElementName">The name of the sub element</param>
		/// <returns>The value or null</returns>
		public static String GetElementValue(this XContainer element, XName subElementName)
		{
			if (subElementName == null)
			{
				throw new ArgumentNullException("subElementName");
			}

			if (element == null)
			{
				return null;
			}

			var subElement = element.Element(subElementName);
			if (subElement == null)
			{
				return null;
			}

			return subElement.Value;
		}

		/// <summary>
		/// Try's to get the attribute value as an Int16.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">the name of the attribute</param>
		/// <returns>the value of the attribute as Int16 or null if its missing or cannot be converted</returns>
		public static Int16? GetElementValueAsInt16(this XContainer element, String elementName)
		{
			return GetElementValue(element, elementName).ToInt16();
		}

		/// <summary>
		/// Try's to get the attribute value as an Int32.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">the name of the attribute</param>
		/// <returns>the value of the attribute as Int32 or null if its missing or cannot be converted</returns>
		public static Int32? GetElementValueAsInt32(this XContainer element, String elementName)
		{
			return GetElementValue(element, elementName).ToInt32();
		}

		/// <summary>
		/// Try's to get the attribute value as an Int64.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">the name of the attribute</param>
		/// <returns>the value of the attribute as Int64 or null if its missing or cannot be converted</returns>
		public static Int64? GetElementValueAsInt64(this XContainer element, String elementName)
		{
			return GetElementValue(element, elementName).ToInt64();
		}

		/// <summary>
		/// Try's to get the attribute value as an Single.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">the name of the attribute</param>
		/// <returns>the value of the attribute as Single or null if its missing or cannot be converted</returns>
		public static Single? GetElementValueAsSingle(this XContainer element, String elementName)
		{
			return GetElementValue(element, elementName).ToSingle();
		}

		/// <summary>
		/// Try's to get the attribute value as an Double.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">the name of the attribute</param>
		/// <returns>the value of the attribute as Double or null if its missing or cannot be converted</returns>
		public static Double? GetElementValueAsDouble(this XContainer element, String elementName)
		{
			return GetElementValue(element, elementName).ToDouble();
		}

		/// <summary>
		/// Try's to get the attribute value as an Decimal.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">the name of the attribute</param>
		/// <returns>the value of the attribute as Decimal or null if its missing or cannot be converted</returns>
		public static Decimal? GetElementValueAsDecimal(this XContainer element, String elementName)
		{
			return GetElementValue(element, elementName).ToDecimal();
		}

		/// <summary>
		/// Try's to get the attribute value as an Int16 or returns defaultValue if it cannot.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">The name of the attribute</param>
		/// <param name="defaultValue">The value to return if there an error converting</param>
		/// <returns>The value of the attribute as Int16 or defaultValue if its missing or cannot be converted returns <paramref name="defaultValue"/></returns>
		public static Int16 GetElementValueAsInt16OrDefault(this XContainer element, String elementName, Int16 defaultValue)
		{

			return GetElementValue(element, elementName).ToInt16OrDefault(defaultValue);
		}

		/// <summary>
		/// Try's to get the attribute value as an Int16 or returns default(Int16) if it cannot
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">The name of the attribute</param>
		/// <returns>The value of the attribute as Int16 or default(Int16) if it cannot convert it</returns>
		public static Int16 GetElementValueAsInt16OrDefault(this XContainer element, String elementName)
		{
			return GetElementValueAsInt16OrDefault(element, elementName, default(Int16));
		}

		/// <summary>
		/// Try's to get the attribute value as an Int32 or returns defaultValue if it cannot.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">The name of the attribute</param>
		/// <param name="defaultValue">The value to return if there an error converting</param>
		/// <returns>The value of the attribute as Int32 or defaultValue if its missing or cannot be converted returns <paramref name="defaultValue"/></returns>
		public static Int32 GetElementValueAsInt32OrDefault(this XContainer element, String elementName, Int32 defaultValue)
		{

			return GetElementValue(element, elementName).ToInt32OrDefault(defaultValue);
		}

		/// <summary>
		/// Try's to get the attribute value as an Int32 or returns default(Int32) if it cannot
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">The name of the attribute</param>
		/// <returns>The value of the attribute as Int32 or default(Int32) if it cannot convert it</returns>
		public static Int32 GetElementValueAsInt32OrDefault(this XContainer element, String elementName)
		{
			return GetElementValueAsInt32OrDefault(element, elementName, default(Int32));
		}

		/// <summary>
		/// Try's to get the attribute value as an Int64 or returns defaultValue if it cannot.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">The name of the attribute</param>
		/// <param name="defaultValue">The value to return if there an error converting</param>
		/// <returns>The value of the attribute as Int64 or defaultValue if its missing or cannot be converted returns <paramref name="defaultValue"/></returns>
		public static Int64 GetElementValueAsInt64OrDefault(this XContainer element, String elementName, Int64 defaultValue)
		{

			return GetElementValue(element, elementName).ToInt64OrDefault(defaultValue);
		}

		/// <summary>
		/// Try's to get the attribute value as an Int64 or returns default(Int64) if it cannot
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">The name of the attribute</param>
		/// <returns>The value of the attribute as Int64 or default(Int64) if it cannot convert it</returns>
		public static Int64 GetElementValueAsInt64OrDefault(this XContainer element, String elementName)
		{
			return GetElementValueAsInt64OrDefault(element, elementName, default(Int64));
		}

		/// <summary>
		/// Try's to get the attribute value as an Single or returns defaultValue if it cannot.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">The name of the attribute</param>
		/// <param name="defaultValue">The value to return if there an error converting</param>
		/// <returns>The value of the attribute as Single or defaultValue if its missing or cannot be converted returns <paramref name="defaultValue"/></returns>
		public static Single GetElementValueAsSingleOrDefault(this XContainer element, String elementName, Single defaultValue)
		{

			return GetElementValue(element, elementName).ToSingleOrDefault(defaultValue);
		}

		/// <summary>
		/// Try's to get the attribute value as an Single or returns default(Single) if it cannot
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">The name of the attribute</param>
		/// <returns>The value of the attribute as Single or default(Single) if it cannot convert it</returns>
		public static Single GetElementValueAsSingleOrDefault(this XContainer element, String elementName)
		{
			return GetElementValueAsSingleOrDefault(element, elementName, default(Single));
		}

		/// <summary>
		/// Try's to get the attribute value as an Double or returns defaultValue if it cannot.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">The name of the attribute</param>
		/// <param name="defaultValue">The value to return if there an error converting</param>
		/// <returns>The value of the attribute as Double or defaultValue if its missing or cannot be converted returns <paramref name="defaultValue"/></returns>
		public static Double GetElementValueAsDoubleOrDefault(this XContainer element, String elementName, Double defaultValue)
		{

			return GetElementValue(element, elementName).ToDoubleOrDefault(defaultValue);
		}

		/// <summary>
		/// Try's to get the attribute value as an Double or returns default(Double) if it cannot
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">The name of the attribute</param>
		/// <returns>The value of the attribute as Double or default(Double) if it cannot convert it</returns>
		public static Double GetElementValueAsDoubleOrDefault(this XContainer element, String elementName)
		{
			return GetElementValueAsDoubleOrDefault(element, elementName, default(Double));
		}

		/// <summary>
		/// Try's to get the attribute value as an Decimal or returns defaultValue if it cannot.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">The name of the attribute</param>
		/// <param name="defaultValue">The value to return if there an error converting</param>
		/// <returns>The value of the attribute as Decimal or defaultValue if its missing or cannot be converted returns <paramref name="defaultValue"/></returns>
		public static Decimal GetElementValueAsDecimalOrDefault(this XContainer element, String elementName, Decimal defaultValue)
		{

			return GetElementValue(element, elementName).ToDecimalOrDefault(defaultValue);
		}

		/// <summary>
		/// Try's to get the attribute value as an Decimal or returns default(Decimal) if it cannot
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="elementName">The name of the attribute</param>
		/// <returns>The value of the attribute as Decimal or default(Decimal) if it cannot convert it</returns>
		public static Decimal GetElementValueAsDecimalOrDefault(this XContainer element, String elementName)
		{
			return GetElementValueAsDecimalOrDefault(element, elementName, default(Decimal));
		}

		/// <summary>
		/// Returns the value of <paramref name="elementName"/> as a DateTime or null if it cannot be converted.
		/// </summary>
		/// <param name="element">The root element of <paramref name="elementName"/> </param>
		/// <param name="elementName">The name of the XElement to get the value from.</param>
		/// <returns></returns>
		public static DateTime? GetElementValueAsDateTime(this XContainer element, String elementName)
		{
			if (elementName == null)
			{
				throw new ArgumentNullException("elementName");
			}

			if (element == null)
			{
				return null;
			}

			return GetElementValue(element, elementName).ToDateTime();
		}

		/// <summary>
		/// Returns the value of <paramref name="elementName"/> as a DateTime or <paramref name="defaultValue"/> if it cannot be converted.
		/// </summary>
		/// <param name="element">The parent node of <paramref name="elementName"/> </param>
		/// <param name="elementName">The element to get the value from</param>
		/// <param name="defaultValue">The default value to return if the value cannot be converted.</param>
		/// <returns></returns>
		public static DateTime GetElementValueAsDateTimeOrDefault(this XContainer element, String elementName, DateTime defaultValue)
		{
			if (elementName == null)
			{
				throw new ArgumentNullException("elementName");
			}

			if (element == null)
			{
				return defaultValue;
			}

			return GetElementValue(element, elementName).ToDateTimeOrDefault(defaultValue);
		}

		/// <summary>
		/// Returns the value of <paramref name="elementName"/> as a DateTime or default(DateTime) if it cannot be converted.
		/// </summary>
		/// <param name="element">The parent node of <paramref name="elementName"/> </param>
		/// <param name="elementName">The element to get the value from</param>
		/// <returns></returns>
		public static DateTime GetElementValueAsDateTimeOrDefault(this XContainer element, String elementName)
		{
			return GetElementValueAsDateTimeOrDefault(element, elementName, default(DateTime));
		}

		/// <summary>
		/// Returns the value of <paramref name="elementName"/> as a Guid or returns null if it cannot
		/// </summary>
		/// <param name="element">The parent element to find <paramref name="elementName"/> in</param>
		/// <param name="elementName">The name of the element</param>
		/// <returns></returns>
		public static Guid? GetElementValueAsGuid(this XContainer element, String elementName)
		{
			if (elementName == null)
			{
				throw new ArgumentNullException("elementName");
			}

			if (element == null)
			{
				return null;
			}

			return GetElementValue(element, elementName).ToGuid();
		}

		/// <summary>
		/// Returns the value as a Guid or returns <paramref name="defaultValue"/> if it cannot convert the value.
		/// </summary>
		/// <param name="element">The parent container of <paramref name="elementName"/></param>
		/// <param name="elementName">The name of the XElement</param>
		/// <param name="defaultValue">The default value to return if cannot convert the value</param>
		/// <returns></returns>
		public static Guid GetElementValueAsGuidOrDefault(this XContainer element, String elementName, Guid defaultValue)
		{
			if (elementName == null)
			{
				throw new ArgumentNullException("elementName");
			}

			if (element == null)
			{
				return defaultValue;
			}

			return GetElementValue(element, elementName).ToGuidOrDefault(defaultValue);
		}

		/// <summary>
		/// Returns the value as a Guid or returns default(Guid) if it cannot convert the value.
		/// </summary>
		/// <param name="element">The parent container of <paramref name="elementName"/></param>
		/// <param name="elementName">The name of the XElement</param>
		/// <returns></returns>
		public static Guid GetElementValueAsGuidOrDefault(this XContainer element, String elementName)
		{
			if (elementName == null)
			{
				throw new ArgumentNullException("elementName");
			}

			return GetElementValueAsGuidOrDefault(element, elementName, default(Guid));
		}

		/// <summary>
		/// Gets the value of <paramref name="element"/> and Tries to convert it to UInt16. If the <paramref name="element"/> has no value or the value cannot be converted returns null.
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		public static UInt16? GetElementValueAsUInt16(this XElement element)
		{
			return GetElementValue(element).ToUInt16();
		}

		/// <summary>
		/// Finds the child XElement who's name equals <paramref name="name"/> and converts its value to a UInt16. If any of these conditions are true returns null: <paramref name="element"/> equals null, there is no child node with name, the value of the child name cannot be converted to a UInt16.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static UInt16? GetElementValueAsUInt16(this XContainer element, XName name)
		{
			return GetElementValue(element, name).ToUInt16();
		}

		/// <summary>
		/// Gets the value of <paramref name="element"/> and converts it to a UInt16. If <paramref name="element"/> is null or its value cannot be converted <paramref name="defaultValue"/> is returned.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static UInt16 GetElementValueAsUInt16OrDefault(this XElement element, UInt16 defaultValue)
		{
			return GetElementValue(element).ToUInt16OrDefault(defaultValue);
		}

		/// <summary>
		/// Gets the value of <paramref name="element"/> and converts it to a UInt16. If <paramref name="element"/> is null or its value cannot be converted default(UInt16) is returned.
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		public static UInt16 GetElementValueAsUInt16OrDefault(this XElement element)
		{
			return GetElementValue(element).ToUInt16OrDefault();
		}

		/// <summary>
		/// Finds the child of <paramref name="element"/> that has the name equal to <paramref name="name"/> and returns its value as a UInt16. 
		/// If any of the following conditions are true returns defaultValue: <paramref name="element"/> is null, there are no children with name equal to <paramref name="name"/>, the value of the child element cannot be converted to UInt16.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static UInt16 GetElementValueAsUInt16OrDefault(this XContainer element, XName name, UInt16 defaultValue)
		{
			return GetElementValue(element, name).ToUInt16OrDefault(defaultValue);
		}

		/// <summary>
		/// Finds the child of <paramref name="element"/> that has the name equal to <paramref name="name"/> and returns its value as a UInt16. If any of the following conditions are true returns default(UInt16): <paramref name="element"/> is null, there are no children with name equal to <paramref name="name"/>, the value of the child element cannot be converted to UInt16.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static UInt16 GetElementValueAsUInt16OrDefault(this XContainer element, XName name)
		{
			return GetElementValue(element, name).ToUInt16OrDefault();
		}

		/// <summary>
		/// Gets the value of <paramref name="element"/> and Tries to convert it to UInt32. If the <paramref name="element"/> has no value or the value cannot be converted returns null.
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		public static UInt32? GetElementValueAsUInt32(this XElement element)
		{
			return GetElementValue(element).ToUInt32();
		}

		/// <summary>
		/// Finds the child XElement who's name equals <paramref name="name"/> and converts its value to a UInt32. If any of these conditions are true returns null: <paramref name="element"/> equals null, there is no child node with name, the value of the child name cannot be converted to a UInt32.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static UInt32? GetElementValueAsUInt32(this XContainer element, XName name)
		{
			return GetElementValue(element, name).ToUInt32();
		}

		/// <summary>
		/// Gets the value of <paramref name="element"/> and converts it to a UInt32. If <paramref name="element"/> is null or its value cannot be converted <paramref name="defaultValue"/> is returned.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static UInt32 GetElementValueAsUInt32OrDefault(this XElement element, UInt32 defaultValue)
		{
			return GetElementValue(element).ToUInt32OrDefault(defaultValue);
		}

		/// <summary>
		/// Gets the value of <paramref name="element"/> and converts it to a UInt32. If <paramref name="element"/> is null or its value cannot be converted default(UInt32) is returned.
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		public static UInt32 GetElementValueAsUInt32OrDefault(this XElement element)
		{
			return GetElementValue(element).ToUInt32OrDefault();
		}

		/// <summary>
		/// Finds the child of <paramref name="element"/> that has the name equal to <paramref name="name"/> and returns its value as a UInt32. 
		/// If any of the following conditions are true returns defaultValue: <paramref name="element"/> is null, there are no children with name equal to <paramref name="name"/>, the value of the child element cannot be converted to UInt32.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static UInt32 GetElementValueAsUInt32OrDefault(this XContainer element, XName name, UInt32 defaultValue)
		{
			return GetElementValue(element, name).ToUInt32OrDefault(defaultValue);
		}

		/// <summary>
		/// Finds the child of <paramref name="element"/> that has the name equal to <paramref name="name"/> and returns its value as a UInt32. If any of the following conditions are true returns default(UInt32): <paramref name="element"/> is null, there are no children with name equal to <paramref name="name"/>, the value of the child element cannot be converted to UInt32.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static UInt32 GetElementValueAsUInt32OrDefault(this XContainer element, XName name)
		{
			return GetElementValue(element, name).ToUInt32OrDefault();
		}

		/// <summary>
		/// Gets the value of <paramref name="element"/> and Tries to convert it to UInt64. If the <paramref name="element"/> has no value or the value cannot be converted returns null.
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		public static UInt64? GetElementValueAsUInt64(this XElement element)
		{
			return GetElementValue(element).ToUInt64();
		}

		/// <summary>
		/// Finds the child XElement who's name equals <paramref name="name"/> and converts its value to a UInt64. If any of these conditions are true returns null: <paramref name="element"/> equals null, there is no child node with name, the value of the child name cannot be converted to a UInt64.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static UInt64? GetElementValueAsUInt64(this XContainer element, XName name)
		{
			return GetElementValue(element, name).ToUInt64();
		}

		/// <summary>
		/// Gets the value of <paramref name="element"/> and converts it to a UInt64. If <paramref name="element"/> is null or its value cannot be converted <paramref name="defaultValue"/> is returned.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static UInt64 GetElementValueAsUInt64OrDefault(this XElement element, UInt64 defaultValue)
		{
			return GetElementValue(element).ToUInt64OrDefault(defaultValue);
		}

		/// <summary>
		/// Gets the value of <paramref name="element"/> and converts it to a UInt64. If <paramref name="element"/> is null or its value cannot be converted default(UInt64) is returned.
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		public static UInt64 GetElementValueAsUInt64OrDefault(this XElement element)
		{
			return GetElementValue(element).ToUInt64OrDefault();
		}

		/// <summary>
		/// Finds the child of <paramref name="element"/> that has the name equal to <paramref name="name"/> and returns its value as a UInt64. 
		/// If any of the following conditions are true returns defaultValue: <paramref name="element"/> is null, there are no children with name equal to <paramref name="name"/>, the value of the child element cannot be converted to UInt64.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static UInt64 GetElementValueAsUInt64OrDefault(this XContainer element, XName name, UInt64 defaultValue)
		{
			return GetElementValue(element, name).ToUInt64OrDefault(defaultValue);
		}

		/// <summary>
		/// Finds the child of <paramref name="element"/> that has the name equal to <paramref name="name"/> and returns its value as a UInt64. If any of the following conditions are true returns default(UInt64): <paramref name="element"/> is null, there are no children with name equal to <paramref name="name"/>, the value of the child element cannot be converted to UInt64.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static UInt64 GetElementValueAsUInt64OrDefault(this XContainer element, XName name)
		{
			return GetElementValue(element, name).ToUInt64OrDefault();
		}
		#endregion

		#region Attribute Value
		/// <summary>
		/// Returns the value of the attribute
		/// if <paramref name="element"/> is null returns null
		/// if <paramref name="attributeName"/> is not found returns null
		/// </summary>
		/// <param name="element">The node that contains the attribute</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <returns></returns>
		public static String GetAttributeValue(this XElement element, XName attributeName)
		{
			if (attributeName == null)
			{
				throw new ArgumentNullException("attributeName");
			}

			if (element == null)
			{
				return null;
			}
			
			var attribute = element.Attribute(attributeName);
			if (attribute != null)
			{
				return attribute.Value;
			}

			return null;
		}

		/// <summary>
		/// Try's to get the attribute value as an Int16.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">the name of the attribute</param>
		/// <returns>the value of the attribute as Int16 or null if its missing or cannot be converted</returns>
		public static Int16? GetAttributeValueAsInt16(this XElement element, String attributeName)
		{
			return GetAttributeValue(element, attributeName).ToInt16();
		}

		/// <summary>
		/// Try's to get the attribute value as an Int32.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">the name of the attribute</param>
		/// <returns>the value of the attribute as Int32 or null if its missing or cannot be converted</returns>
		public static Int32? GetAttributeValueAsInt32(this XElement element, String attributeName)
		{
			return GetAttributeValue(element, attributeName).ToInt32();
		}

		/// <summary>
		/// Try's to get the attribute value as an Int64.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">the name of the attribute</param>
		/// <returns>the value of the attribute as Int64 or null if its missing or cannot be converted</returns>
		public static Int64? GetAttributeValueAsInt64(this XElement element, String attributeName)
		{
			return GetAttributeValue(element, attributeName).ToInt64();
		}

		/// <summary>
		/// Try's to get the attribute value as an Single.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">the name of the attribute</param>
		/// <returns>the value of the attribute as Single or null if its missing or cannot be converted</returns>
		public static Single? GetAttributeValueAsSingle(this XElement element, String attributeName)
		{
			return GetAttributeValue(element, attributeName).ToSingle();
		}

		/// <summary>
		/// Try's to get the attribute value as an Double.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">the name of the attribute</param>
		/// <returns>the value of the attribute as Double or null if its missing or cannot be converted</returns>
		public static Double? GetAttributeValueAsDouble(this XElement element, String attributeName)
		{
			return GetAttributeValue(element, attributeName).ToDouble();
		}

		/// <summary>
		/// Try's to get the attribute value as an Decimal.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">the name of the attribute</param>
		/// <returns>the value of the attribute as Decimal or null if its missing or cannot be converted</returns>
		public static Decimal? GetAttributeValueAsDecimal(this XElement element, String attributeName)
		{
			return GetAttributeValue(element, attributeName).ToDecimal();
		}

		/// <summary>
		/// Try's to get the attribute value as an Int16 or returns defaultValue if it cannot.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <param name="defaultValue">The value to return if there an error converting</param>
		/// <returns>The value of the attribute as Int16 or defaultValue if its missing or cannot be converted returns <paramref name="defaultValue"/></returns>
		public static Int16 GetAttributeValueAsInt16OrDefault(this XElement element, String attributeName, Int16 defaultValue)
		{

			return GetAttributeValue(element, attributeName).ToInt16OrDefault(defaultValue);
		}

		/// <summary>
		/// Try's to get the attribute value as an Int16 or returns default(Int16) if it cannot
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <returns>The value of the attribute as Int16 or default(Int16) if it cannot convert it</returns>
		public static Int16 GetAttributeValueAsInt16OrDefault(this XElement element, String attributeName)
		{
			return GetAttributeValueAsInt16OrDefault(element, attributeName, default(Int16));
		}

		/// <summary>
		/// Try's to get the attribute value as an Int32 or returns defaultValue if it cannot.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <param name="defaultValue">The value to return if there an error converting</param>
		/// <returns>The value of the attribute as Int32 or defaultValue if its missing or cannot be converted returns <paramref name="defaultValue"/></returns>
		public static Int32 GetAttributeValueAsInt32OrDefault(this XElement element, String attributeName, Int32 defaultValue)
		{

			return GetAttributeValue(element, attributeName).ToInt32OrDefault(defaultValue);
		}

		/// <summary>
		/// Try's to get the attribute value as an Int32 or returns default(Int32) if it cannot
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <returns>The value of the attribute as Int32 or default(Int32) if it cannot convert it</returns>
		public static Int32 GetAttributeValueAsInt32OrDefault(this XElement element, String attributeName)
		{
			return GetAttributeValueAsInt32OrDefault(element, attributeName, default(Int32));
		}

		/// <summary>
		/// Try's to get the attribute value as an Int64 or returns defaultValue if it cannot.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <param name="defaultValue">The value to return if there an error converting</param>
		/// <returns>The value of the attribute as Int64 or defaultValue if its missing or cannot be converted returns <paramref name="defaultValue"/></returns>
		public static Int64 GetAttributeValueAsInt64OrDefault(this XElement element, String attributeName, Int64 defaultValue)
		{

			return GetAttributeValue(element, attributeName).ToInt64OrDefault(defaultValue);
		}

		/// <summary>
		/// Try's to get the attribute value as an Int64 or returns default(Int64) if it cannot
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <returns>The value of the attribute as Int64 or default(Int64) if it cannot convert it</returns>
		public static Int64 GetAttributeValueAsInt64OrDefault(this XElement element, String attributeName)
		{
			return GetAttributeValueAsInt64OrDefault(element, attributeName, default(Int64));
		}

		/// <summary>
		/// Try's to get the attribute value as an Single or returns defaultValue if it cannot.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <param name="defaultValue">The value to return if there an error converting</param>
		/// <returns>The value of the attribute as Single or defaultValue if its missing or cannot be converted returns <paramref name="defaultValue"/></returns>
		public static Single GetAttributeValueAsSingleOrDefault(this XElement element, String attributeName, Single defaultValue)
		{

			return GetAttributeValue(element, attributeName).ToSingleOrDefault(defaultValue);
		}

		/// <summary>
		/// Try's to get the attribute value as an Single or returns default(Single) if it cannot
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <returns>The value of the attribute as Single or default(Single) if it cannot convert it</returns>
		public static Single GetAttributeValueAsSingleOrDefault(this XElement element, String attributeName)
		{
			return GetAttributeValueAsSingleOrDefault(element, attributeName, default(Single));
		}

		/// <summary>
		/// Try's to get the attribute value as an Double or returns defaultValue if it cannot.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <param name="defaultValue">The value to return if there an error converting</param>
		/// <returns>The value of the attribute as Double or defaultValue if its missing or cannot be converted returns <paramref name="defaultValue"/></returns>
		public static Double GetAttributeValueAsDoubleOrDefault(this XElement element, String attributeName, Double defaultValue)
		{

			return GetAttributeValue(element, attributeName).ToDoubleOrDefault(defaultValue);
		}

		/// <summary>
		/// Try's to get the attribute value as an Double or returns default(Double) if it cannot
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <returns>The value of the attribute as Double or default(Double) if it cannot convert it</returns>
		public static Double GetAttributeValueAsDoubleOrDefault(this XElement element, String attributeName)
		{
			return GetAttributeValueAsDoubleOrDefault(element, attributeName, default(Double));
		}

		/// <summary>
		/// Try's to get the attribute value as an Decimal or returns defaultValue if it cannot.
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <param name="defaultValue">The value to return if there an error converting</param>
		/// <returns>The value of the attribute as Decimal or defaultValue if its missing or cannot be converted returns <paramref name="defaultValue"/></returns>
		public static Decimal GetAttributeValueAsDecimalOrDefault(this XElement element, String attributeName, Decimal defaultValue)
		{

			return GetAttributeValue(element, attributeName).ToDecimalOrDefault(defaultValue);
		}

		/// <summary>
		/// Try's to get the attribute value as an Decimal or returns default(Decimal) if it cannot
		/// </summary>
		/// <param name="element">The XElement to get the attribute value from</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <returns>The value of the attribute as Decimal or default(Decimal) if it cannot convert it</returns>
		public static Decimal GetAttributeValueAsDecimalOrDefault(this XElement element, String attributeName)
		{
			return GetAttributeValueAsDecimalOrDefault(element, attributeName, default(Decimal));
		}

		/// <summary>
		/// Returns the value of the attribute as a DateTime or null if it cannot be converted
		/// </summary>
		/// <param name="element">The XElement the attribute is on</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <returns></returns>
		public static DateTime? GetAttributeValueAsDateTime(this XElement element, String attributeName)
		{
			if (attributeName == null)
			{
				throw new ArgumentNullException("attributeName");
			}

			if (element == null)
			{
				return null;
			}

			return GetAttributeValue(element, attributeName).ToDateTime();
		}

		/// <summary>
		/// Returns the value of the attribute as a DateTime or <paramref name="defaultValue"/> if it cannot be converted
		/// </summary>
		/// <param name="element">The element the attribute is on</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <param name="defaultValue">The value to return when the value cannot be converted</param>
		/// <returns></returns>
		public static DateTime GetAttributeValueAsDateTimeOrDefault(this XElement element, String attributeName, DateTime defaultValue)
		{
			if (attributeName == null)
			{
				throw new ArgumentNullException("attributeName");
			}

			if (element == null)
			{
				return defaultValue;
			}

			return GetAttributeValue(element, attributeName).ToDateTimeOrDefault(defaultValue);
		}

		/// <summary>
		/// Returns the value of the attribute as a DateTime or default(DateTime) if it cannot be converted
		/// </summary>
		/// <param name="element">The element the attribute is on</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <returns></returns>
		public static DateTime GetAttributeValueAsDateTimeOrDefault(this XElement element, String attributeName)
		{
			if (attributeName == null)
			{
				throw new ArgumentNullException("attributeName");
			}

			return GetAttributeValueAsDateTimeOrDefault(element, attributeName, default(DateTime));
		}

		/// <summary>
		/// Returns the value of the attribute as a Guid or null if it cannot be converted
		/// </summary>
		/// <param name="element">The element the attribute is on</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <returns></returns>
		public static Guid? GetAttributeValueAsGuid(this XElement element, String attributeName)
		{
			if (attributeName == null)
			{
				throw new ArgumentNullException("attributeName");
			}

			if (element == null)
			{
				return null;
			}

			return GetAttributeValue(element, attributeName).ToGuid();
		}

		/// <summary>
		/// Returns the value of the attribute as a Guid or <paramref name="defaultValue"/> if it cannot be converted
		/// </summary>
		/// <param name="element">The element the attribute is on</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <param name="defaultValue">The value to return when the attribute value cannot be converted</param>
		/// <returns></returns>
		public static Guid GetAttributeValueAsGuidOrDefault(this XElement element, String attributeName, Guid defaultValue)
		{
			if (attributeName == null)
			{
				throw new ArgumentNullException("attributeName");
			}

			if (element == null)
			{
				return defaultValue;
			}

			return GetAttributeValue(element, attributeName).ToGuidOrDefault(defaultValue);
		}

		/// <summary>
		/// Returns the value of the attribute as a Guid or default(Guid) if it cannot be converted
		/// </summary>
		/// <param name="element">The element the attribute is on</param>
		/// <param name="attributeName">The name of the attribute</param>
		/// <returns></returns>
		public static Guid GetAttributeValueAsGuidOrDefault(this XElement element, String attributeName)
		{
			if (attributeName == null)
			{
				throw new ArgumentNullException("attributeName");
			}

			return GetAttributeValueAsGuidOrDefault(element, attributeName, default(Guid));
		}
		
		/// <summary>
		/// Finds the attribute who's name equals <paramref name="name"/> and converts its value to a UInt16. If any of these conditions are true returns null: <paramref name="element"/> equals null, there is no child node with <paramref name="name"/>, the value of the attribute cannot be converted to a UInt16.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static UInt16? GetAttributeValueAsUInt16(this XElement element, XName name)
		{
			return GetAttributeValue(element, name).ToUInt16();
		}

		/// <summary>
		/// Finds the attribute that has the name equal to <paramref name="name"/> and returns its value as a UInt16. If any of the following conditions are true returns <paramref name="defaultValue"/>: <paramref name="element"/> is null, there are no children with name equal to <paramref name="name"/>, the value of the child attribute cannot be converted to UInt16.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static UInt16 GetAttributeValueAsUInt16OrDefault(this XElement element, XName name, UInt16 defaultValue)
		{
			return GetAttributeValue(element, name).ToUInt16OrDefault(defaultValue);
		}

		/// <summary>
		/// Finds the attribute that has the name equal to <paramref name="name"/> and returns its value as a UInt16. If any of the following conditions are true returns default(UInt16): <paramref name="element"/> is null, there are no children with name equal to <paramref name="name"/>, the value of the child attribute cannot be converted to UInt16.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static UInt16 GetAttributeValueAsUInt16OrDefault(this XElement element, XName name)
		{
			return GetAttributeValue(element, name).ToUInt16OrDefault();
		}

		/// <summary>
		/// Finds the attribute who's name equals <paramref name="name"/> and converts its value to a UInt32. If any of these conditions are true returns null: <paramref name="element"/> equals null, there is no child node with <paramref name="name"/>, the value of the attribute cannot be converted to a UInt32.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static UInt32? GetAttributeValueAsUInt32(this XElement element, XName name)
		{
			return GetAttributeValue(element, name).ToUInt32();
		}

		/// <summary>
		/// Finds the attribute that has the name equal to <paramref name="name"/> and returns its value as a UInt32. If any of the following conditions are true returns <paramref name="defaultValue"/>: <paramref name="element"/> is null, there are no children with name equal to <paramref name="name"/>, the value of the child attribute cannot be converted to UInt32.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static UInt32 GetAttributeValueAsUInt32OrDefault(this XElement element, XName name, UInt32 defaultValue)
		{
			return GetAttributeValue(element, name).ToUInt32OrDefault(defaultValue);
		}

		/// <summary>
		/// Finds the attribute that has the name equal to <paramref name="name"/> and returns its value as a UInt32. If any of the following conditions are true returns default(UInt32): <paramref name="element"/> is null, there are no children with name equal to <paramref name="name"/>, the value of the child attribute cannot be converted to UInt32.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static UInt32 GetAttributeValueAsUInt32OrDefault(this XElement element, XName name)
		{
			return GetAttributeValue(element, name).ToUInt32OrDefault();
		}


		/// <summary>
		/// Finds the attribute who's name equals <paramref name="name"/> and converts its value to a UInt64. If any of these conditions are true returns null: <paramref name="element"/> equals null, there is no child node with <paramref name="name"/>, the value of the attribute cannot be converted to a UInt64.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static UInt64? GetAttributeValueAsUInt64(this XElement element, XName name)
		{
			return GetAttributeValue(element, name).ToUInt64();
		}

		/// <summary>
		/// Finds the attribute that has the name equal to <paramref name="name"/> and returns its value as a UInt64. If any of the following conditions are true returns <paramref name="defaultValue"/>: <paramref name="element"/> is null, there are no children with name equal to <paramref name="name"/>, the value of the child attribute cannot be converted to UInt64.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static UInt64 GetAttributeValueAsUInt64OrDefault(this XElement element, XName name, UInt64 defaultValue)
		{
			return GetAttributeValue(element, name).ToUInt64OrDefault(defaultValue);
		}

		/// <summary>
		/// Finds the attribute that has the name equal to <paramref name="name"/> and returns its value as a UInt64. If any of the following conditions are true returns default(UInt64): <paramref name="element"/> is null, there are no children with name equal to <paramref name="name"/>, the value of the child attribute cannot be converted to UInt64.
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static UInt64 GetAttributeValueAsUInt64OrDefault(this XElement element, XName name)
		{
			return GetAttributeValue(element, name).ToUInt64OrDefault();
		}
		#endregion

		#region WinRT Extensions
#if NETFX_CORE || WP8
#endif
		#endregion

	}
}
