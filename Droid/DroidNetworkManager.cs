using System;
using Suvi;
using Xamarin.Forms.Platform.Android;
using Android.Net;
using Android.OS;
using Android.App;
using Android.Content;

namespace Suvi.Droid
{
	public class DroidNetworkManager : INetworkManager
	{
		public bool IsConnected(){
			var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);

			var activeConnection = connectivityManager.ActiveNetworkInfo;
			if ((activeConnection != null)  && activeConnection.IsConnected)
			{
				return true;
			}
			return false;
		}
	}
}

