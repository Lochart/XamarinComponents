using System;

using Xamarin.Forms;

namespace XamarinComponents.Droid
{
    public class CustomLogger : FFImageLoading.Helpers.IMiniLogger
	{
		public void Debug(string message)
		{
			Console.WriteLine(message);
		}

		public void Error(string errorMessage)
		{
			Console.WriteLine(errorMessage);
		}

		public void Error(string errorMessage, Exception ex)
		{
			Error(errorMessage + System.Environment.NewLine + ex.ToString());
		}
	}
}

