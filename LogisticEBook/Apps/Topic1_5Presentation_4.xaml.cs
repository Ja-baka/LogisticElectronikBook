using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace LogisticEBook.Apps
{
	/// <summary>
	/// Логика взаимодействия для Topic1_5TypeOfShelfs.xaml
	/// </summary>
	public partial class Topic1_5Presentation_4 : Window
	{
		public Topic1_5Presentation_4()
		{
			InitializeComponent();

			OpenPresentation();
			Close();
		}

		private void OpenPresentation()
		{
			string path = System.IO.Directory.GetCurrentDirectory()
				+ @"/Presentations/4.pptx";

			try
			{
				dynamic app = new PowerPoint.Application();
				app.Presentations.Open2007(path);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Ошибка при открытии презентации\n{ex.Message}");
			}
		}
	}
}
