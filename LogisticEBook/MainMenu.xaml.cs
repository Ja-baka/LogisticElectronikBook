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

namespace LogisticEBook
{
	/// <summary>
	/// Логика взаимодействия для MainMenu.xaml
	/// </summary>
	public partial class MainMenu : Window
	{
		private Dictionary<Hyperlink, string> _topics;

		public MainMenu()
		{
			InitializeComponent();
			_topics = new Dictionary<Hyperlink, string>
			{
				{ Hyperlink0, "0" },
				{ Hyperlink1_1, "1.1" },
				{ Hyperlink1_2, "1.2" },
				{ Hyperlink1_3, "1.3" },
			};
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			System.Diagnostics.Process.GetCurrentProcess().Kill();
		}

		private void Hyperlink_Click(object sender, RoutedEventArgs e)
		{
			if (sender is Hyperlink hyperlink)
			{ 
				string number = _topics[hyperlink];
				OpenTopicByIndex(number);
			}
			else
			{
				MessageBox.Show("Неверный элемент");
			}
		}

		private void OpenTopicByIndex(string topicIndex)
		{
			Hide();

			Reader reader = new(topicIndex);
			reader.ShowDialog();
			
			Show();
		}

		private void OpenPresentation(object sender, RoutedEventArgs e)
		{
			if (sender is FrameworkContentElement element)
			{
				string path = System.IO.Directory.GetCurrentDirectory()
					+ @"/Presentations/" + element.Name + ".pptx";
				dynamic app = new PowerPoint.Application();
				app.Presentations.Open2007(path);
			}
			else
			{
				MessageBox.Show("Неверный элемент");
			}
		}
	}
}
