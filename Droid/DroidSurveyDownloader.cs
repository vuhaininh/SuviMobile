using System;
using Suvi;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using XLabs.Ioc;


namespace Suvi.Droid
{
	public class DroidSurveyDownloader : ISurveyDownloader
	{
		public async Task<Suvi.Data.Survey> DownloadSurvey (string surveyCode)
		{

			var request = HttpWebRequest.Create (Configuration.WebsiteUrl + "/s/" + surveyCode + ".json");
			request.ContentType = "application/json";
			request.Method = "GET";

			try {
				// Send the request to the server and wait for the response:
				using (WebResponse response = await request.GetResponseAsync ()) {
					// Get a stream representation of the HTTP web response:
					using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
						var content = reader.ReadToEnd ();

						Console.Out.WriteLine ("Response: {0}", content);

						Suvi.Data.Survey survey = JsonConvert.DeserializeObject<Suvi.Data.Survey> (content);
						if (!string.IsNullOrWhiteSpace (survey.Theme)) {
							await DownloadTheme (survey.Theme);
						}
						return survey;
					}
				}
			} catch (Exception e) {
				Console.Out.WriteLine (Configuration.WebsiteUrl + "/s/" + surveyCode + ".json" + e.Message);
				return null;
			}
		}

		public async Task DownloadTheme (string theme)
		{
			var themeManager = Resolver.Resolve<IThemeManager> ();
			var request = HttpWebRequest.Create (Configuration.WebsiteUrl + "/assets/frontendapp/theme" + theme + "/application.css");
			request.Method = "GET";

			// Send the request to the server and wait for the response:
			using (WebResponse response = await request.GetResponseAsync ()) {
				// Get a stream representation of the HTTP web response:
				using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
					var content = reader.ReadToEnd ();
					themeManager.SaveThemeFile (theme, "application.css", content);
				}
			}

		}


		public bool SaveFeedback (Suvi.Data.Feedback feedback)
		{
			var url = Configuration.WebsiteUrl + "/s/" + feedback.Survey.Code + ".json";
			try {
				var request = HttpWebRequest.Create (url);
				request.ContentType = "application/json";
				request.Method = "POST";

				using (var dataStream = new StreamWriter (request.GetRequestStream ())) {
					dataStream.Write (JsonConvert.SerializeObject (feedback));
				}

				using (WebResponse response = request.GetResponse ()) {
					// Get a stream representation of the HTTP web response:
					using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
						var content = reader.ReadToEnd ();
						var result = Convert.ToBoolean(JsonConvert.DeserializeObject(content));
						if(result){
							App.Database.SetFeedbackAsSaved(feedback);
							return true;
						}
					}
				}
			} catch (Exception e) {
				System.Diagnostics.Debug.WriteLine (e.Message);
			}
			return false;
		}
	}
}

