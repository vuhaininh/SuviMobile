using System;
using SQLite;

namespace Suvi.Data
{
	public class Answer
	{
		public Answer ()
		{
		}
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Content { get; set;}
		public int FeedbackId { get; set;}
		public int QuestionId {get; set;}
	}
}

