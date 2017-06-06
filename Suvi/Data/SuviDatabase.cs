using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace Suvi.Data
{
	public class SuviDatabase
	{
		static object locker = new object ();

		SQLiteConnection database;

		public SuviDatabase (SQLiteConnection conn)
		{
			database = conn;

			//Create table
			database.CreateTable<Choice>();
			database.CreateTable<Question>();
			database.CreateTable<Survey>();

			database.CreateTable<Feedback>();
			database.CreateTable<Answer>();
		}

		public IEnumerable<Survey> GetSavedSurveys ()
		{
			lock (locker) {
				return (from i in database.Table<Survey>() select i).ToList();
			}
		}

		public Survey GetSurvey(string surveyCode){

			lock (locker) {

				var matchSurveys = from s in database.Table<Survey>()
						where s.Code.ToLower().Equals(surveyCode.ToLower())
					select s;
				var suvi = matchSurveys.FirstOrDefault ();
				if (suvi == null) {
					matchSurveys = from s in database.Table<Survey>() 
						where s.CustomUrl.ToLower().Equals(surveyCode.ToLower())
						select s;
					return matchSurveys.FirstOrDefault();
				}

				var tempQuestions = database.Table<Question> ().Where (x => x.SurveyId == suvi.ID).ToList();
				foreach (var q in tempQuestions) {
					//Need to call GetQuestion again to populate choices
					suvi.Questions.Add (GetQuestion(q.ID));
				}
				return suvi;
			}
		}

		public Survey GetSurvey(int surveyId){

			lock (locker) {

				var suvi = database.Get<Survey> (surveyId);
				if (suvi == null) {
					return null;
				}

				var tempQuestions = database.Table<Question> ().Where (x => x.SurveyId == suvi.ID).ToList();
				foreach (var q in tempQuestions) {
					//Need to call GetQuestion again to populate choices
					suvi.Questions.Add (GetQuestion(q.ID));
				}
				return suvi;
			}
		}

		public Question GetQuestion(int questionId){

			lock (locker) {

				var matchQuestions = from s in database.Table<Question>()
						where s.ID == questionId
					select s;
				var question = matchQuestions.FirstOrDefault ();
				if (question == null) {
					return null;
				}
				question.Choices = database.Table<Choice> ().Where (x=>x.QuestionId == questionId).ToList();
				return question;
			}
		}


		public void SaveSurvey (Survey survey) 
		{
			lock (locker) {
				var suvi = GetSurvey (survey.Code);
				if (suvi != null) {
					database.Update (survey);
				} else {
					database.Insert (survey);
				}
				foreach (var q in survey.Questions) {
					q.SurveyId = survey.ID;
					SaveQuestion (q);
				}
			}
		}

		public void SaveQuestion(Question q){
			lock (locker) {
				var question = database.Table<Question> ().Where (x => x.ID == q.ID).FirstOrDefault();
				if (question != null) {
					database.Update (q);
				} else {
					database.Insert (q);
				}
				RemoveAllQuestionChoices (q.ID);
				foreach (var choice in q.Choices) {
					choice.QuestionId = q.ID;
					SaveChoice (choice);
				}

			}
		}

		private void RemoveAllQuestionChoices(int questionId){
			lock (locker) {
				var choices = database.Table<Choice> ().Where (x=>x.QuestionId == questionId).ToList();
				foreach (var choice in choices) {
					database.Delete (choice);
				}
			}
		}

		public void SaveChoice(Choice choice){
			var c = database.Table<Choice> ().Where (x => x.ID == choice.ID).FirstOrDefault();
			if (c != null) {
				database.Update(choice);
			}
			else{
				database.Insert(choice);
			}
		}

		public void SaveFeedback(Feedback feedback){
			lock (locker) {
				feedback.Created = DateTime.Now;
				database.Insert (feedback);
				foreach(var answer in feedback.Answers){
					if (answer != null) {
						answer.FeedbackId = feedback.ID;
						database.Insert (answer);
					}
				}
			}

		}

		public List<Feedback> GetAllUnsavedFeedbacks(){
			lock (locker) {
				var unsavedFeedbacks = database.Table<Feedback> ().Where (x=>x.IsSaved == false).ToList();
				foreach (var fb in unsavedFeedbacks) {
					fb.Survey = GetSurvey (fb.SurveyID);
					fb.Answers = database.Table<Answer> ().Where (x => x.FeedbackId == fb.ID).ToList();
				}
				return unsavedFeedbacks;
			}
		}

		public void SetFeedbackAsSaved(Feedback feedback){
			lock (locker) {
				try{
					feedback.IsSaved = true;
					database.Update (feedback);
				}catch (Exception ex){
					System.Diagnostics.Debug.WriteLine (ex.Message);
				}
			}
		}

		public List<Survey> GetAllSurveys(){
			return database.Table<Survey> ().ToList ();
		}
	}
}

