using System;
#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif
using System.Reflection;
using System.Reflection.Emit;
using Sannel.Helpers;

#if NETFX_CORE
namespace Sannel.Helpers.WinRT.Tests
#else
namespace Sannel.Helpers.Tests
#endif
{
	[TestClass]
	public class AssemblyExtensionTests
	{
		[TestMethod]
		public void GetFirstCustomAttributeTest()
		{
#if NETFX_CORE
			Assembly assembly = GetType().GetTypeInfo().Assembly;
#else
			Assembly assembly = GetType().Assembly;
#endif

			var actual = AssemblyExtensions.GetFirstCustomAttribute<AssemblyTitleAttribute>(null, true);

			Assert.IsNull(actual);

			actual = AssemblyExtensions.GetFirstCustomAttribute<AssemblyTitleAttribute>(null, false);

			Assert.IsNull(actual);
#if NETFX_CORE
			var att = assembly.GetCustomAttribute(typeof(AssemblyTitleAttribute));
			AssemblyTitleAttribute expected = (AssemblyTitleAttribute)att;
#else
			var list = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), true);

			AssemblyTitleAttribute expected = (AssemblyTitleAttribute)list[0];
#endif

			actual = AssemblyExtensions.GetFirstCustomAttribute<AssemblyTitleAttribute>(assembly, true);

			Assert.AreEqual(expected, actual);

			actual = AssemblyExtensions.GetFirstCustomAttribute<AssemblyTitleAttribute>(assembly, false);

			Assert.AreEqual(expected, actual);

			var actual2 = AssemblyExtensions.GetFirstCustomAttribute<AssemblyCleanupAttribute>(assembly, true);

			Assert.IsNull(actual2);

			actual2 = AssemblyExtensions.GetFirstCustomAttribute<AssemblyCleanupAttribute>(assembly, false);

			Assert.IsNull(actual2);

			actual = AssemblyExtensions.GetFirstCustomAttribute<AssemblyTitleAttribute>(null);

			Assert.IsNull(actual);

			actual = AssemblyExtensions.GetFirstCustomAttribute<AssemblyTitleAttribute>(assembly);

			Assert.AreEqual(expected, actual);

			actual2 = AssemblyExtensions.GetFirstCustomAttribute<AssemblyCleanupAttribute>(assembly);

			Assert.IsNull(actual2);
		}

		[TestMethod]
		public void GetTitleTest()
		{
			var actual = AssemblyExtensions.GetTitle(null);

			Assert.AreEqual(String.Empty, actual);

#if NETFX_CORE
			Assembly assembly = GetType().GetTypeInfo().Assembly;
#else
			Assembly assembly = GetType().Assembly;
#endif

#if NETFX_CORE
			var att = assembly.GetCustomAttribute(typeof(AssemblyTitleAttribute));
			AssemblyTitleAttribute expected = (AssemblyTitleAttribute)att;
#else
			var list = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), true);

			AssemblyTitleAttribute expected = (AssemblyTitleAttribute)list[0];
#endif

			actual = AssemblyExtensions.GetTitle(assembly);

			Assert.AreEqual(expected.Title, actual);
		}

		[TestMethod]
		public void GetAssemblyVersionTest()
		{
			var actual = AssemblyExtensions.GetAssemblyVersion(null);

			Assert.IsNull(actual);


#if NETFX_CORE
			Assembly assembly = GetType().GetTypeInfo().Assembly;
#else
			Assembly assembly = GetType().Assembly;
#endif

			var assemblyName = new AssemblyName(assembly.FullName);

			var version = assemblyName.Version;

			actual = AssemblyExtensions.GetAssemblyVersion(assembly);

			Assert.AreEqual(version, actual);
		}
	}
}
