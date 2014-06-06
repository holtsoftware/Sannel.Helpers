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
