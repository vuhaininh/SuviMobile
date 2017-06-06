using System;

using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Serialization;
using XLabs.Forms.Services;
using XLabs.Platform.Services;
using XLabs.Serialization.JsonNET;
using SQLite;
using System.Threading;
using System.Threading.Tasks;

namespace Suvi
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage(new Home());

			/*var directories = Directory.EnumerateDirectories("./");
			foreach (var directory in directories) {
				System.Diagnostics.Debug.WriteLine(directory);
			}*/
		}

		static SQLite.SQLiteConnection conn;
		static Suvi.Data.SuviDatabase database;
		public static void SetDatabaseConnection (SQLite.SQLiteConnection connection)
		{
			conn = connection;
			database = new Suvi.Data.SuviDatabase (conn);
		}
		public static Suvi.Data.SuviDatabase  Database {
			get { return database; }
		}

		protected override void OnStart ()
		{
			Device.StartTimer (TimeSpan.FromSeconds (Configuration.UploadFeedbackInterval), () => {	
				System.Diagnostics.Debug.WriteLine("uploading feedback");
				UploadFeedback();
				return true;
			});
		}

		private void UploadFeedback(){
			var networkManager = Resolver.Resolve<INetworkManager>();
			if(networkManager.IsConnected())
			{
				var unsavedFeedbacks = database.GetAllUnsavedFeedbacks();
				var feedbackService = Resolver.Resolve<ISurveyDownloader>();
				foreach(var fb in unsavedFeedbacks){
					feedbackService.SaveFeedback(fb);
				}
			}
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}

}

