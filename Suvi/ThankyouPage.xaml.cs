using System;
using System.Collections.Generic;
using XLabs.Ioc;
using Xamarin.Forms;
using Suvi.Data;

namespace Suvi
{
	public partial class ThankyouPage : ContentPage
	{
		public List<string> CustomCss { get; set;}
		public Suvi.Data.Survey SurveyData { get; set;}
		private bool initialized;

		public ThankyouPage ()
		{
			CustomCss = new List<string> ();
			InitializeComponent ();

		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			if (initialized) {
				return;
			}

			initialized = true;

			var template = new Complete ();
			template.Model = SurveyData;
			template.ViewData["CustomCss"] = CustomCss;
			var page = template.GenerateString ();
			webView.LoadContent(page);
		}
	}
}

