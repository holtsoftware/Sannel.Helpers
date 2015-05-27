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
#if NET_4_5 || NET_4_5_1 || PORTABLE
using System.Threading.Tasks;
#endif
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Sannel
{
	/// <summary>
	/// This class parses command line arguments into Arguments, Values and NonArgumentValues. It expects arguments to be in the format --[name]=[value] or /[name]=[value]. Name can be a-z,A-Z,0-9,-,_. 
	/// </summary>
	public class Arguments
	{
		private Dictionary<String, String> argNames = new Dictionary<string, string>();
		private List<String> nonArgValues = new List<string>();
		/// <summary>
		/// Creates a new Arguments class but does not parse anything until the parse method is called
		/// </summary>
		public Arguments()
		{
		}

		/// <summary>
		/// Creates a new Arguments class and parses the provided array
		/// </summary>
		/// <param name="args">The array to parse</param>
		public Arguments(String[] args)
		{
			Parse(args);
		}

		/// <summary>
		/// Returns true if the specified name was passed as an argument false otherwise
		/// </summary>
		/// <param name="name">The name of the argument to look for</param>
		/// <returns>True if the argument was found false if not</returns>
		public bool HasArgument(String name)
		{
			return argNames.ContainsKey(name);
		}

		/// <summary>
		/// Returns a String representing the value passed to the argument name or null if none was passed or name does not exist
		/// </summary>
		/// <param name="name">The name of the argument to get the value for</param>
		/// <returns>The value passed to the argument or null</returns>
		public String ArgumentValue(String name)
		{
			if (argNames.ContainsKey(name))
			{
				return argNames[name];
			}

			return null;
		}

		/// <summary>
		/// Returns a dictionary containing the arguments parsed out by Parse.
		/// </summary>
		/// <returns></returns>
#if NET_4_5 || NET_4_5_1
		public IReadOnlyDictionary<String, String> ArgumentValues
#else
		public Dictionary<String, String> ArgumentValues
#endif
		{
			get
			{
				return argNames;
			}
		}

		/// <summary>
		/// Returns an array of strings representing arguments that were not in the form --[name]=[value] or /[name]=[value]
		/// </summary>
#if NET_4_5 || NET_4_5_1
		public IReadOnlyList<String> NonArgumentValues
		{
			get
			{
				return nonArgValues;
			}
		}
#else
		public ReadOnlyCollection<String> NonArgumentValues
		{
			get
			{
				return new ReadOnlyCollection<String>(nonArgValues);
			}
		}
#endif

		/// <summary>
		/// Parses the provided <paramref name="args"/> array into Arguments, Values and NonArgumentValues
		/// </summary>
		/// <param name="args">The arguments to parse</param>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
		public void Parse(String[] args)
		{
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}

			foreach (var a in args)
			{
				if(!String.IsNullOrEmpty(a))
				{
					var match = ArgumentNameRegex.Match(a);
					if (match.Success)
					{
						var name = match.Groups["name"].Value.ToLowerInvariant();
						if (a.Length > match.Length)
						{
							var value = a.Substring(match.Length);

							if (value.Length > 1 && value[0] == '"')
							{
								if (value[value.Length - 1] == '"')
								{
									value = value.Substring(1, value.Length - 2);
								}
							}
							
							argNames[name] = value;
						}
						else
						{
							argNames[name] = null;
						}
					}
					else
					{
						nonArgValues.Add(a);
					}
				}
			}
		}

#if NET_4_5 || NET_4_5_1 || PORTABLE
		/// <summary>
		/// Parses the provided <paramref name="args"/> array into Arguments, Values and NonArgumentValues
		/// </summary>
		/// <param name="args">The arguments to parse</param>
		public Task ParseAsync(String[] args)
		{
			return Task.Run(() =>
				{
					Parse(args);
				});
		}
#endif

		public readonly static Regex ArgumentNameRegex = new Regex("^\\s*(?<full>(--|-|/)(?<name>[a-zA-Z0-9-_?]+)[=]?)", 
			RegexOptions.IgnoreCase
			| RegexOptions.CultureInvariant
			| RegexOptions.IgnorePatternWhitespace
#if !PORTABLE
			| RegexOptions.Compiled
#endif
			);

	}
}
