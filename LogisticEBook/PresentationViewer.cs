using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LogisticEBook
{
	static class PresentationViewer
	{
		public static void OpenPresentation(string path)
		{
			path = System.IO.Directory.GetCurrentDirectory()
				+ path;

			try
			{
				ProcessStartInfo processStartInfo = new(path)
				{
					UseShellExecute = true,
				};
				Process.Start(processStartInfo);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
