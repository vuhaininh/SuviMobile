using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Ioc;
using XLabs.Serialization;
using XLabs.Serialization.JsonNET;

namespace Suvi.Droid
{
	[Activity (Label = "SurveyInPocket", Icon = "@drawable/appicon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		private bool initialized = false;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			if (!initialized) {
				SetIoc ();
				SetupDbConnection ();
				initialized = true;
			}
			global::Xamarin.Forms.Forms.Init (this, bundle);

			LoadApplication (new App ());
		}


		private void SetIoc()
		{			

			var resolverContainer = new SimpleContainer();

			resolverContainer.Register<IJsonSerializer, JsonSerializer>();
			resolverContainer.Register<ISurveyDownloader, DroidSurveyDownloader> ();
			resolverContainer.Register<IThemeManager, DroidThemeManager> ();
			resolverContainer.Register<INetworkManager, DroidNetworkManager> ();
			resolverContainer.Register<IBaseUrl, BaseUrl> ();

			Resolver.SetResolver(resolverContainer.GetResolver());
		}


		private void SetupDbConnection(){
			var sqliteFilename = "Suvi.db3";
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
			string path = Path.Combine (documentsPath, sqliteFilename);

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

