using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Suvi.iOS
{
	public class SurveyQuestionPageRenderer : PageRenderer
	{
		protected override void OnElementChanged (VisualElementChangedEventArgs e)
		{
			base.OnElementChanged (e);
			//var panGestureRecognizer = new UIPanGestureRecognizer (() => Console.WriteLine ("Pan"));
		}
	}
}

