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
using System.Reflection;
using System.Text;

namespace Sannel.Helpers
{
	/// <summary>
	/// Contains Extensions for the Assembly class
	/// </summary>
	public static class AssemblyExtensions
	{
		
#if NETFX_CORE
		/// <summary>
		/// Gets the first instance of Attribute who's type is <typeparamref name="T"/> and returns it.
		/// if assembly == null returns null
		/// if it cannot find an Attribute with type of <typeparamref name="T"/> return null;
		/// </summary>
		/// <typeparam name="T">A type that inherits from Attribute</typeparam>
		/// <param name="assembly">The assembly to search</param>
		/// <returns></returns>
		public static T GetFirstCustomAttribute<T>(this Assembly assembly)
			where T : Attribute
		{
			if (assembly == null)
			{
				return null;
			}

			T att = assembly.GetCustomAttribute(typeof(T)) as T;
			return att;
		}

		/// <summary>
		/// Gets the first instance of Attribute who's type is <typeparamref name="T"/> and returns it.
		/// if assembly == null returns null
		/// if it cannot find an Attribute with type of <typeparamref name="T"/> return null;
		/// </summary>
		/// <typeparam name="T">A type that inherits from Attribute</typeparam>
		/// <param name="assembly">The assembly to search</param>
		/// <param name="inherit">Not used. This is for backwards compatibility</param>
		/// <returns></returns>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "inherit")]
		public static T GetFirstCustomAttribute<T>(this Assembly assembly, bool inherit)
			where T : Attribute
		{
			return GetFirstCustomAttribute<T>(assembly);
		}
#else
		/// <summary>
		/// Gets the first instance of Attribute who's type is <typeparamref name="T"/> and returns it.
		/// if assembly == null returns null
		/// if it cannot find an Attribute with type of <typeparamref name="T"/> return null;
		/// </summary>
		/// <typeparam name="T">A type that inherits from Attribute</typeparam>
		/// <param name="assembly">The assembly to search</param>
		/// <param name="inherit">This argument is ignored for objects of type System.Reflection.Assembly.</param>
		/// <returns></returns>
		public static T GetFirstCustomAttribute<T>(this Assembly assembly, bool inherit)
			where T : Attribute
		{
			if (assembly == null)
			{
				return null;
			}

			Object[] objs = assembly.GetCustomAttributes(typeof(T), inherit);
			if (objs.Length > 0 && objs[0] is T)
			{
				return objs[0] as T;
			}

			return null;
		}
#endif

#if !NETFX_CORE
		/// <summary>
		/// Gets the first instance of Attribute who's type is <typeparamref name="T"/> and returns it.
		/// if assembly == null returns null
		/// if it cannot find an Attribute with type of <typeparamref name="T"/> return null;
		/// </summary>
		/// <typeparam name="T">A type that inherits from Attribute</typeparam>
		/// <param name="assembly">The assembly to search</param>
		/// <returns></returns>
		public static T GetFirstCustomAttribute<T>(this Assembly assembly)
			where T : Attribute
		{
			return GetFirstCustomAttribute<T>(assembly, true);
		}
#endif

		/// <summary>
		/// Returns the value stored in the AssemblyTitleAttribute or returns String.Empty if it cannot find the AssemblyTitleAttribute
		/// </summary>
		/// <param name="assembly">The assembly to get the title from</param>
		/// <returns></returns>
		public static String GetTitle(this Assembly assembly)
		{
			if (assembly == null)
			{
				return String.Empty;
			}

			var title = assembly.GetFirstCustomAttribute<AssemblyTitleAttribute>();
			if (title != null)
			{
				return title.Title;
			}

			return String.Empty;
		}

		/// <summary>
		/// Gets the assembly version.
		/// </summary>
		/// <param name="assembly">The assembly.</param>
		/// <returns></returns>
		public static Version GetAssemblyVersion(this Assembly assembly)
		{
			if (assembly == null)
			{
				return null;
			}

			var nameHelper = new AssemblyName(assembly.FullName);
			return nameHelper.Version;
		}
	}
}
