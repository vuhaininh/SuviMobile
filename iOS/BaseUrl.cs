using System;
using Suvi;
using Xamarin.Forms;
using Foundation;

namespace Suvi.iOS
{
	public class BaseUrl : IBaseUrl
	{
		#region IBaseUrl implementation

		public string Get ()
		{
			return NSBundle.MainBundle.BundlePath + "/X.png";
		}

		#endregion
	}
}

