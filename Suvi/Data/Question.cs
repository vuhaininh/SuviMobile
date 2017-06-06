using System;
using SQLite;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Suvi.Data
{
	public class Question
	{
		public Question ()
		{
			Choices = new List<Choice> ();
		}

		[PrimaryKey]
		public int ID { get; set; }
		public string QuestionText {get; set;}
		public QuestionType QuestionType { get; set;}
		public int SurveyId { get; set;}
		public bool AllowMultipleChoice { get; set;}
		public int Index { get; set;}
		[Ignore]
		public List<Suvi.Data.Choice> Choices {get; set;}

		[Ignore]
		public Answer Answer{ get; set;}

		[Ignore]
		[JsonIgnore]
		public Survey Survey{ get; set;}
	}
}

