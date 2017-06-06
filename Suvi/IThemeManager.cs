using System;
using System.Collections.Generic;

namespace Suvi
{
	public interface IThemeManager
	{
		bool SaveThemeFile(string themeId, string fileName, string fileContent);
		string RetreiveThemeCssFromDisk(string themeId);
	}
}

