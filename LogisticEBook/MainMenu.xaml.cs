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
using LogisticEBook.Pages;

using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Word = Microsoft.Office.Interop.Word;

namespace LogisticEBook
{
	/// <summary>
	/// Логика взаимодействия для MainMenu.xaml
	/// </summary>
	public partial class MainMenu : Window
	{
		private static readonly Dictionary<string, Page> _topics;

		static MainMenu()
		{
			_topics = new Dictionary<string, Page>
			{
				{ "0",   new Page0() },
				{ "1_1", new Page1_1() },
				{ "1_2", new Page1_2() },
				{ "1_3", new Page1_3() },
				{ "1_4", new Page1_4() },
				{ "1_5", new Page1_5() },
				{ "1_6", new Page1_6() },
			};
		}

		public MainMenu()
		{
			InitializeComponent();
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			System.Diagnostics.Process.GetCurrentProcess().Kill();
		}

		private void Hyperlink_Click(object sender, RoutedEventArgs e)
		{
			if (sender is not FrameworkContentElement element)
			{
				MessageBox.Show("Неверный элемент");
			}

			else if (element.Name.Contains("Topic"))
			{
				OpenTopic(element.Name);
			}

			else if (element.Name.Contains("Presentation"))
			{
				OpenPresentation(element.Name);
			}

			else if (element.Name.Contains("Word"))
			{
				OpenWord(element.Name);
			}

			else if (element.Name == string.Empty)
			{
				MessageBox.Show("Тема находится в разработке");
			}
		}

		private void OpenWord(string wordName)
		{
			string path = System.IO.Directory.GetCurrentDirectory()
				+ @"/Words/" + wordName + ".docx";

			try
			{
				Word.Application app = new();
				app.Documents.Open(path);
			}
			catch
			{
				MessageBox.Show("Ошибка при открытии документа");
			}
		}

		private static void OpenPresentation(string presentaionName)
		{
			string path = System.IO.Directory.GetCurrentDirectory()
				+ @"/Presentations/" + presentaionName + ".pptx";
			try
			{
				dynamic app = new PowerPoint.Application();
				app.Presentations.Open2007(path);
			}
			catch
			{
				MessageBox.Show("Ошибка при открытии презентации");
			}
		}

		private void OpenTopic(string topicName)
		{
			topicName = RemovePrefix(topicName);
			Hide();

			try
			{
				Reader reader = new(_topics[topicName]);
				reader.ShowDialog();
			}
			catch
			{
				MessageBox.Show("Тема не найдена");
			}

			Show();
		}

		private static string RemovePrefix(string originString)
		{
			var array = originString.Where(x => char.IsLetter(x) == false);
			return new string (array.ToArray());
		}
	}
}
