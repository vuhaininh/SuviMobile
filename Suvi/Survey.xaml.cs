using System;
using System.Collections.Generic;
using XLabs.Ioc;
using Xamarin.Forms;
using System.Linq;

namespace Suvi
{
	public partial class Survey : CarouselPage
	{
		public Suvi.Data.Survey SurveyData { get; set;}
		public ISurveyDownloader surveyService { get; set;}
		public INetworkManager networkManager { get; set;} 


		private object lockObject = new Object();

		private int submitCounter;

		public Survey (Suvi.Data.Survey survey)
		{
			SurveyData = survey;		
			LoadSurvey ();
			surveyService = Resolver.Resolve<ISurveyDownloader> ();
			networkManager = Resolver.Resolve<INetworkManager> ();
			NavigationPage.SetBackButtonTitle (this, "Home");

			InitializeComponent ();
		}

		public void RefreshSurvey(){
			System.Diagnostics.Debug.WriteLine ("refresh survey");
			if (!SurveyData.Questions.All (x => x.Answer == null)) {
				foreach (var childPage in Children) {
					var questionPage = childPage as SurveyQuestion;
					if (questionPage != null) {
						questionPage.Refresh ();
					}
				}
			}
			GoToFirstPage();
		}
		
		public void GoToFirstPage(){
			var currentPageIndex = Children.IndexOf (CurrentPage);
			if (currentPageIndex > 0) {
				Device.BeginInvokeOnMainThread (() => {
					CurrentPage = Children [0];
				});
			}
		}

		public void LoadSurvey(){
			Children.Clear ();
			Title = SurveyData.Name;
			string theme = "";
			if (!string.IsNullOrWhiteSpace (SurveyData.Theme)) {
				var themeManager = Resolver.Resolve<IThemeManager> ();
				theme = themeManager.RetreiveThemeCssFromDisk (SurveyData.Theme);
			}

			foreach (var question in this.SurveyData.Questions.OrderBy(x=>x.Index)) {
				var page = new SurveyQuestion (question);
				//TODO: Set survey somewhere else
				question.Survey = SurveyData;
				page.CustomCss.Add (theme);
				page.OnGoNextHanlder += HandleGoNext;
				page.OnTextChangingHanlder += HandleTextChanging;
				Children.Add (page);
			}
			var thankyouPage = new Suvi.ThankyouPage ();
			thankyouPage.SurveyData = SurveyData;
			thankyouPage.CustomCss.Add (theme);
			Children.Add (thankyouPage);
			SetupAutoSubmit();
		}
		
		public void SetupAutoSubmit(){
			submitCounter = Configuration.AutoSubmitInterval;
			Device.StartTimer (TimeSpan.FromSeconds (1), () => {
				lock(lockObject){
					if(submitCounter <= 0){
						submitCounter = Configuration.AutoSubmitInterval;
						SaveFeedback();
						RefreshSurvey();
					}
					else{
						submitCounter--;
					}
				}
				return true;
			});
		}


		public void HandleTextChanging(object sender, EventArgs e){
			lock (lockObject) {
				submitCounter = Configuration.AutoSubmitInterval;
			}
		}

		public void HandleGoNext (object sender, EventArgs e)
		{
			lock (lockObject) {
				submitCounter = Configuration.AutoSubmitInterval;
			}
			var currentIndex = Children.IndexOf ((SurveyQuestion)sender);
			if (currentIndex < Children.Count - 1) {

				Device.BeginInvokeOnMainThread (() => {
					var nextPage = Children [currentIndex + 1];
					CurrentPage = nextPage;
				});
			}
			//System.Diagnostics.Debug.WriteLine("go to next page");
			if(currentIndex == Children.Count - 2){
				SaveFeedback ();

				if (!string.IsNullOrWhiteSpace (SurveyData.RedirectUrl)) {
					Device.StartTimer (TimeSpan.FromSeconds (Configuration.WaitTimeAfterFinish), () => {
						System.Diagnostics.Debug.WriteLine ("redirect");
						//Device.OpenUri (new Uri(SurveyData.RedirectUrl));
						return false;
					});
				}
				if (SurveyData.AutoReset) {
					Device.StartTimer (TimeSpan.FromSeconds (Configuration.WaitTimeAfterFinish), () => {
						System.Diagnostics.Debug.WriteLine ("reset survey");
						Device.BeginInvokeOnMainThread(() =>
							{
								RefreshSurvey();
							});
						
						return false;
					});
				}

			}
		}


		public void SaveFeedback(){
			if(SurveyData.Questions.All(x=>x.Answer == null)){
				//Do nothing when there is no valid answer in this feedback
				return;
			}

			var feedback = new Suvi.Data.Feedback();
			feedback.SurveyID = SurveyData.ID;
			feedback.Survey = SurveyData;

			foreach (var question in SurveyData.Questions) {
				if (question.Answer != null) {
					feedback.Answers.Add (question.Answer);
				}
			}

			App.Database.SaveFeedback (feedback);

			if (networkManager.IsConnected ()) {
				surveyService.SaveFeedback (feedback);
			}
		}
	}
}

