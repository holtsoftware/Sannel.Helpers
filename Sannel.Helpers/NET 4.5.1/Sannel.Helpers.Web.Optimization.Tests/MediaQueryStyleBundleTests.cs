using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sannel.Web.Optimization;
using System.Web.Optimization;

namespace Sannel.Helpers.Web.Optimization.Tests
{
	[TestClass]
	public class MediaQueryStyleBundleTests
	{
		[TestMethod]
		public void ConstructorTest()
		{
			var bundle = new MediaQueryStyleBundle("~/test");
			Assert.AreEqual(2, bundle.Transforms.Count);
			Assert.IsInstanceOfType(bundle.Transforms[0], typeof(MediaQueryEnabler));
			Assert.IsInstanceOfType(bundle.Transforms[1], typeof(CssMinify));
		}
	}
}
