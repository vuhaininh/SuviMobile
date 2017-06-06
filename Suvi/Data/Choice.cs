using System;
using SQLite;

namespace Suvi.Data
{
	public class Choice
	{
		public Choice ()
		{
		}
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Label { get; set;}
		public string Image { get; set;}
		public int QuestionId { get; set;}
	}
}

