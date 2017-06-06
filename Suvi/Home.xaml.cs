using System;
using System.Collections.Generic;
using XLabs.Ioc;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Suvi
{
	public partial class Home : TabbedPage
	{
		public Home ()
		{
			InitializeComponent();
			listView.ItemSelected +=  OnItemSelected;
		}

		protected override void OnAppearing ()
		{
			listView.ItemsSource = App.Database.GetAllSurveys ();
		}
		public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e){
			if (e.SelectedItem == null) {
				return;
			}
			var suvi = e.SelectedItem as Suvi.Data.Survey;
			await GoToSelectedSurvey (suvi.Code);
		}


		public async void OnGoButtonClicked (object sender, EventArgs e) {
			activityIndicator.IsRunning = true;
			activityIndicator.Color = Color.Blue;
			Go.IsEnabled = false;
			await GoToSelectedSurvey (SurveyCode.Text);
			activityIndicator.IsRunning = false;
			Go.IsEnabled = true;
		}


		public async Task GoToSelectedSurvey(string surveyCode){
			//Check if survey is already downloaded
			var db = App.Database;
			Suvi.Data.Survey survey = null;
			if (!string.IsNullOrWhiteSpace (surveyCode)) {
				survey = db.GetSurvey (surveyCode);
			}
			var networkManager = Resolver.Resolve<INetworkManager> ();

			if (networkManager.IsConnected ()) {
				//Download servey from server
				var surveyDownloader = Resolver.Resolve<ISurveyDownloader> ();
				var downloadedSurvey = await surveyDownloader.DownloadSurvey (surveyCode);
				if (survey == null && downloadedSurvey == null) {
					await DisplayAlert ("Error", "There is no surey with this code!", "OK");
					return;
				}
				if (downloadedSurvey != null) {
					db.SaveSurvey (downloadedSurvey);
					survey = downloadedSurvey;
				}
			} else if(survey == null){
				await DisplayAlert ("Alert", "There is no network connection!", "OK");
				return;
			}

			var rPage = new Survey(survey);
			NavigationPage.SetHasNavigationBar (rPage, false);
			await Navigation.PushAsync(rPage);
		}
	}
}

