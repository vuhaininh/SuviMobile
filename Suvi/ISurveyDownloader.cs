using System;
using System.Threading.Tasks;

namespace Suvi
{
	public interface ISurveyDownloader
	{
		Task<Suvi.Data.Survey> DownloadSurvey(string surveyCode);

		bool SaveFeedback(Suvi.Data.Feedback feedback);
	}
}

