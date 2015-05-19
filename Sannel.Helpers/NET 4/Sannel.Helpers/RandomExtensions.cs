/*
Copyright 2015 Sannel Software, L.L.C.

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

namespace Sannel.Helpers
{
	/// <summary>
	/// Contains Extension methods for the Random class
	/// </summary>
	public static class RandomExtensions
	{
		/// <summary>
		/// The default String used to generate a random string
		/// </summary>
		public const String DefaultGenerateString = "`1234567890-=~!@#$%^&*()_+qwertyuiop[]\\asdfghjkl;'zxcvbnm,./QWETIOP{}|ASDFGHJKL:\"ZXCVBNM<>?";

		/// <summary>
		/// Generates a random string
		/// </summary>
		/// <param name="random">The random.</param>
		/// <param name="minCharacterCount">The min character count.</param>
		/// <param name="maxCharacterCount">The max character count.</param>
		/// <param name="source">The source string.</param>
		/// <returns></returns>
		public static String NextString(this Random random, int minCharacterCount, int maxCharacterCount, String source)
		{
			if (random == null)
			{
				throw new ArgumentNullException("random");
			}

			if (minCharacterCount < 0)
			{
				throw new ArgumentOutOfRangeException("minCharacterCount", "minCharacterCount must be greater then or equal to 0");
			}

			if (minCharacterCount > maxCharacterCount)
			{
				throw new ArgumentException("maxCharacterCount must be greater then or equal to minCharacterCount", "maxCharacterCount");
			}

			if (maxCharacterCount <= 0)
			{
				throw new ArgumentOutOfRangeException("maxCharacterCount", "maxCharacterCount must be greater then 0");
			}

			if (source == null)
			{
				throw new ArgumentNullException("source");
			}

			if (source.Length == 0)
			{
				throw new ArgumentOutOfRangeException("source", "sourceString must have atleast 1 character in it");
			}

			StringBuilder builder = new StringBuilder();
			int length = random.Next(minCharacterCount, maxCharacterCount);
			for (int i = 0; i < length; i++)
			{
				builder.Append(source[random.Next(0, source.Length)]);
			}

			return builder.ToString();
		}

		/// <summary>
		/// Generates a random string
		/// </summary>
		/// <param name="random">The random.</param>
		/// <param name="minCharacterCount">The min character count.</param>
		/// <param name="maxCharacterCount">The max character count.</param>
		/// <returns></returns>
		public static String NextString(this Random random, int minCharacterCount, int maxCharacterCount)
		{
			return NextString(random, minCharacterCount, maxCharacterCount, DefaultGenerateString);
		}

		/// <summary>
		/// Generates a random string between 20 and 255 characters
		/// </summary>
		/// <param name="random">The random.</param>
		/// <returns></returns>
		public static String NextString(this Random random)
		{
			return NextString(random, 20, 255);
		}
	}
}
