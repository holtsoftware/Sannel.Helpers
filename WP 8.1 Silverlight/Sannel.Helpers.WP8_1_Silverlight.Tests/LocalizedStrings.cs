using Sannel.Helpers.WP8_1_Silverlight.Tests.Resources;

namespace Sannel.Helpers.WP8_1_Silverlight.Tests
{
	/// <summary>
	/// Provides access to string resources.
	/// </summary>
	public class LocalizedStrings
	{
		private static AppResources _localizedResources = new AppResources();

		public AppResources LocalizedResources { get { return _localizedResources; } }
	}
}