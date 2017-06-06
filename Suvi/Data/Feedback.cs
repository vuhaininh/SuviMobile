using System;
using System.Collections.Generic;
using SQLite;
using Newtonsoft.Json;

namespace Suvi.Data
{
	public class Feedback
	{
		public Feedback ()
		{
			Answers = new List<Answer> ();
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public DateTime Created{ get; set;}
		public bool IsSaved { get; set;}
		public int SurveyID { get; set;}
		[Ignore]
		public List<Suvi.Data.Answer> Answers {get; set;}

		[Ignore]
		public Suvi.Data.Survey Survey {
			get;
			set;
		}
	}
}

