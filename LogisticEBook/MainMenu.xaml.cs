using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
		private const int ChaptersCount = 3;
		private string _name = string.Empty;

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
			if (sender is FrameworkContentElement element)
			{
				_name = element.Name;
			}
			else
			{
				MessageBox.Show("Неверный элемент");
				return;
			}

			if (_name.Contains("Topic"))
			{
				OpenTopic();
			}
			else if (_name.Contains("Presentation"))
			{
				OpenPresentation();
			}
			else if (_name.Contains("Word"))
			{
				OpenWord();
			}
			else if (_name.Contains("Test"))
			{
				OpenTest();
			}
			else if (_name == "Glossary")
			{
				OpenGlossary();
			}
			else if (_name.Contains("Quiz"))
			{
				OpenQuiz();
			}
			else if (_name == string.Empty)
			{
				MessageBox.Show("Тема находится в разработке");
			}
			else
			{
				MessageBox.Show("Ошибка в имени темы");
			}
		}

		private void OpenQuiz()
		{
			_name = RemovePrefix(_name);

			try
			{
				Window window = _name switch
				{
					"2_1" => new Quizes.Quiz2_1(),
					_ => throw new Exception(),
				};

				window.ShowDialog();
			}
			catch
			{
				MessageBox.Show("Викторина находится в разработке");
				
			}
		}

		private static void OpenGlossary()
		{
			PageGlossary page = new();
			Reader reader = new(page);
			reader.ShowDialog();
		}

		private void OpenTest()
		{
			MessageBoxResult result = MessageBox.Show
			(
				"Тестирование проводится на базе Moodle "
				+ "и тест будет доступен во время соответствующего занятия",
				"Информация",
				MessageBoxButton.OKCancel,
				MessageBoxImage.Information
			);
			if (result == MessageBoxResult.Cancel)
			{
				return;
			}

			_name = RemovePrefix(_name);

			string fileName = _name switch
			{
				"1_1" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=9115",
				"1_2" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=9116",
				"1_3" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=8407",
				"1_4" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=8411",
				"1_5" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=9117",
				"1_6" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=9401",
				"1_7" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=9402",
				_ => string.Empty,
			};

			if (fileName == string.Empty)
			{
				MessageBox.Show("Тест в разработке");
				return;
			}

			ProcessStartInfo processStartInfo = new(fileName)
			{
				UseShellExecute = true,
			};
			Process.Start(processStartInfo);
		}

		private void OpenWord()
		{
			string path = System.IO.Directory.GetCurrentDirectory()
				+ @"/Words/" + _name + ".docx";

			try
			{
				OpenFile(path);
			}
			catch
			{
				MessageBox.Show("Документ в разработке");
			}
		}

		private void OpenPresentation()
		{
			string path = System.IO.Directory.GetCurrentDirectory()
				+ @"/Presentations/" + _name + ".pptx";

			try
			{
				OpenFile(path);
			}
			catch
			{
				MessageBox.Show("Презентация в разработке");
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

		private void OpenTopic()
		{
			_name = RemovePrefix(_name);
			try
			{
				Type pageType = GetPageType();

				dynamic page = Activator.CreateInstance(pageType);

				Reader reader = new(page);
				reader.ShowDialog();
			}
			catch
			{
				MessageBox.Show($"Тема в разработке");
			}
		}

		private Type GetPageType()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			Type pageType = assembly.GetType("LogisticEBook.Pages.Page" + _name);
			if (pageType != null)
			{
				return pageType;
			}

			// Проверка на дурака (меня).
			// чтобы всё корректно работало - страницу нужно сначала создавать в папке Pages
			// и только потом перемещать в соответствующий Chapter, ну либо менять namespace
			for (int i = 0; i < ChaptersCount; i++)
			{
				pageType ??= assembly.GetType($"LogisticEBook.Pages.Chapter{i + 1}.Page{_name}");
			}

			return pageType;
		}

		private static string RemovePrefix(string originString)
		{
			var rezult = originString.Where(x => char.IsLetter(x) == false);
			return new string (rezult.ToArray());
		}
	}
}
