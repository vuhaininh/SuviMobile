using System;

namespace Suvi
{
	public static class Configuration {
		#if DEBUG
		public const string WebsiteUrl = "http://suvi.co";
		#else
		public const string WebsiteUrl = "http://suvi.co";
		#endif

		public const int WaitTimeAfterFinish = 3; //seconds
		public const int UploadFeedbackInterval = 60; //seconds

		public const int AutoSubmitInterval = 60; //seconds

	}
}

