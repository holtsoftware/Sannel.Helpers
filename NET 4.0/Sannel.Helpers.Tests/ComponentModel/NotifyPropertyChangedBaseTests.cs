using System;
#if NETFX_CORE
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif
using Sannel.ComponentModel;
using System.ComponentModel;

#if NETFX_CORE
namespace Sannel.Helpers.WinRT.Tests.ComponentModel
#else
namespace Sannel.Helpers.Tests.ComponentModel
#endif
{
	[TestClass]
	public class NotifyPropertyChangedBaseTests
	{
		public class NotifyPropertyChanged : NotifyPropertyChangedBase
		{
			private String property1;

			public String Property1
			{
				get
				{
					return property1;
				}
				set
				{
					SetProperty(ref property1, value, "Property1");
				}
			}

			private String property2;

			public String Property2
			{
				get
				{
					return property2;
				}
				set
				{
					SetProperty(ref property2, value);
				}
			}

			public String Property3
			{
				set
				{
					OnPropertyChanged("Property3");
				}
			}

			public String Property4
			{
				set
				{
					OnPropertyChanged();
				}
			}
		}

		[TestMethod]
		public void NotifyPropertyChangedTest()
		{
			NotifyPropertyChanged changed = new NotifyPropertyChanged();

			changed.PropertyChanged += propertyChangeTest1;

			changed.Property1 = "Test22";

			changed.PropertyChanged -= propertyChangeTest1;

			bool methodCalled = false;

			changed.PropertyChanged += (sender, e) =>
				{
					methodCalled = true;
				};

			changed.Property2 = "prop2";

			Assert.IsTrue(methodCalled);

			changed = new NotifyPropertyChanged();

			methodCalled = false;

			changed.PropertyChanged += (sender, e) =>
				{
					methodCalled = true;
					Assert.AreEqual("Property3", e.PropertyName);
				};

			changed.Property3 = "prop3";

			Assert.IsTrue(methodCalled);

			changed = new NotifyPropertyChanged();

			methodCalled = false;

			changed.PropertyChanged += (sender, e) =>
				{
					methodCalled = true;
				};

			changed.Property4 = "prop4";

			Assert.IsTrue(methodCalled);
		}

		private void propertyChangeTest1(object sender, PropertyChangedEventArgs e)
		{
			Assert.AreEqual("Property1", e.PropertyName);
		}
	}
}
