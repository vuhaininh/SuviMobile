using System;
using SystemConfiguration;
using CoreFoundation;


namespace Suvi.iOS
{
	public class IOSNetworkManager : INetworkManager
	{
		public bool IsConnected(){

			NetworkStatus internetStatus = Reachability.InternetConnectionStatus();
			return internetStatus != NetworkStatus.NotReachable;
		}
	}
}

