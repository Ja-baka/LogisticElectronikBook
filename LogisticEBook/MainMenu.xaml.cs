using System;
using System.Collections.Generic;
using System.Diagnostics;
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
				{ "1_7", new Page1_7() },
			};
		}

		public MainMenu()
		{
			InitializeComponent();
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			Process.GetCurrentProcess().Kill();
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

			else if (element.Name.Contains("Test"))
			{
				OpenTest(element.Name);
			}

			else if (element.Name == string.Empty)
			{
				MessageBox.Show("Тема находится в разработке");
			}
		}

		private static void OpenTest(string name)
		{
			name = RemovePrefix(name);

			string fileName = name switch
			{
				"1_1" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=9115",
				"1_2" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=9116",
				"1_3" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=8407",
				"1_4" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=8411",
				_ => string.Empty,
			};

			if (fileName == string.Empty)
			{
				MessageBox.Show("Тест не найден");
				return;
			}

			string message = "Тестирование проводится на базе moodle " +
				"и тест будет доступен во время соответствующего занятия";

			MessageBox.Show(message, "Предупреждение", MessageBoxButton.OK);

			ProcessStartInfo processStartInfo = new(fileName)
			{
				UseShellExecute = true,
			};
			Process.Start(processStartInfo);
		}

		private static void OpenWord(string wordName)
		{
			string path = System.IO.Directory.GetCurrentDirectory()
				+ @"/Words/" + wordName + ".docx";

			try
			{
				OpenFile(path);
			}
			catch
			{
				MessageBox.Show("Ошибка при открытии документа");
			}
		}

		private static void OpenPresentation(string presentaionName)
		{
			string path = System.IO.Directory.GetCurrentDirectory()
				+ @"/Presentations0/" + presentaionName + ".pptx";

			try
			{
				OpenFile(path);
			}
			catch
			{
				MessageBox.Show("Ошибка при открытии презентации");
			}
		}

		private static void OpenFile(string path)
		{
			ProcessStartInfo processStartInfo = new(path)
			{
				UseShellExecute = true,
			};
			Process.Start(processStartInfo);
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
			var rezult = originString.Where(x => char.IsLetter(x) == false);
			return new string (rezult.ToArray());
		}
	}
}
