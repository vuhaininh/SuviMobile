using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using XLabs.Forms;
using XLabs.Ioc;
using XLabs.Serialization;
using XLabs.Serialization.JsonNET;
using System.IO;
using SQLite;

namespace Suvi.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : XFormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			this.SetIoc();
			SetupDbConnection ();
			SetupDbConnection ();
			global::Xamarin.Forms.Forms.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			LoadApplication (new App ());
			UIApplication.SharedApplication.SetStatusBarHidden (true, true);
			return base.FinishedLaunching (app, options);
		}

		private void SetIoc()
		{			
			
			var resolverContainer = new SimpleContainer();

			resolverContainer.Register<IJsonSerializer, JsonSerializer>();
			resolverContainer.Register<ISurveyDownloader, IOSSurveyDownloader> ();
			resolverContainer.Register<IThemeManager, IOSThemeManager> ();
			resolverContainer.Register<INetworkManager, IOSNetworkManager> ();

			Resolver.SetResolver(resolverContainer.GetResolver());
		}

		private void SetupDbConnection(){
			var sqliteFilename = "Suvi.db3";
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
			var path = Path.Combine(libraryPath, sqliteFilename);

			// This is where we copy in the prepopulated database
			Console.WriteLine (path);
			if (!File.Exists (path)) {
				File.Create (path);
			}

			var conn = new SQLite.SQLiteConnection(path);

			// Set the database connection string
			App.SetDatabaseConnection (conn);
		}
	}
}

