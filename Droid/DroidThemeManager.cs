using System;
using System.IO;


namespace Suvi.Droid
{
	public class DroidThemeManager : IThemeManager
	{
		public bool SaveThemeFile(string themeId, string fileName, string fileContent){
			var documents =
				Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var directoryname = Path.Combine (documents, "themes");
			var themeDir = Path.Combine (directoryname, themeId);
			Directory.CreateDirectory(themeDir);

			var themeFile = Path.Combine (themeDir, fileName);
			File.WriteAllText (themeFile, fileContent);
			return true;
		}

		public string RetreiveThemeCssFromDisk(string themeId){
			var documents =
				Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var directoryname = Path.Combine (documents, "themes");
			var themeDir = Path.Combine (directoryname, themeId);
			var themeFile = Path.Combine (themeDir, "application.css");
			return themeFile;
		}
	}
}

