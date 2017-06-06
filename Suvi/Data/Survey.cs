using System;
using System.Collections.Generic;
using SQLite;

namespace Suvi.Data
{
	public class Survey
	{
		public Survey()
		{
			Questions = new List<Question> ();
		}
	    [PrimaryKey]
		public int ID { get; set; }
		[Unique]
		public string Code { get; set;}
		public string Theme {get; set;}
		public string Name { get; set;}
		public bool AutoReset { get; set;}
		public int AutoResetInterval {get; set;}
		public string RedirectUrl { get; set;}
		public string CustomUrl { get; set;}
		[Ignore]
		public List<Suvi.Data.Question> Questions {get; set;}

		public DateTime Created{ get; set;}
		public DateTime Modified { get; set;}
	}
}

