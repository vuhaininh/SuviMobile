using System;
using Xamarin.Forms;
using Suvi;

namespace Suvi.Droid
{
	public class BaseUrl : IBaseUrl
	{
		#region IBaseUrl implementation

		public string Get ()
		{
			return "file:///android_asset/";
		}

		#endregion
	}
}

