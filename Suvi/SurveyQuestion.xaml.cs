using System;
using System.Collections.Generic;
using XLabs.Ioc;
using Xamarin.Forms;

namespace Suvi
{
	public partial class SurveyQuestion : ContentPage
	{
		public List<string> CustomCss { get; set;}
		public Suvi.Data.Question Question { get; set;}

		public event EventHandler OnGoNextHanlder;
		public event EventHandler OnTextChangingHanlder;

		protected virtual void OnGoNext(string x)
		{
			System.Diagnostics.Debug.WriteLine ("go Next");
			Question.Answer = new Suvi.Data.Answer{ 
				Content = x,
				QuestionId = Question.ID
			};
			var handler = OnGoNextHanlder;
			if (handler != null)
			{
				handler(this, EventArgs.Empty);
			}

		}

		protected virtual void OnTextChanging(string value)
		{
			System.Diagnostics.Debug.WriteLine ("text change " + value);
			Question.Answer = new Suvi.Data.Answer{ 
				QuestionId = Question.ID,
				Content = value
			};
			var handler = OnTextChangingHanlder;
			if (handler != null)
			{
				handler(this, EventArgs.Empty);
			}
		}


		public SurveyQuestion (Suvi.Data.Question question)
		{
			Question = question;
			CustomCss = new List<string> ();
			InitializeComponent ();
		}

		private bool initialized;

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			if (initialized) {
				return;
			}

			initialized = true;

			System.Diagnostics.Debug.WriteLine ("On appearing");
			Title = Question.QuestionText;

			LoadContent ();
			webView.RegisterCallback("goNext", OnGoNext);
			webView.RegisterCallback("TextChanging", OnTextChanging);
		}

		public void LoadContent(){
			var template = new Question ();
			template.Model = Question;
			template.ViewData["CustomCss"] = CustomCss;
			var page = template.GenerateString ();
			webView.LoadContent(page);
		}

		public void Refresh(){
			Question.Answer = null;
			LoadContent ();
		}

	}
}

