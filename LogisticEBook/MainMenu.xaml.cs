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
		private string _name = string.Empty;

		static MainMenu()
		{
			_topics = new Dictionary<string, Page>
			{
				{ "0",   new Page0()   },
				{ "1_1", new Page1_1() },
				{ "1_2", new Page1_2() },
				{ "1_3", new Page1_3() },
				{ "1_4", new Page1_4() },
				{ "1_5", new Page1_5() },
				{ "1_6", new Page1_6() },
				{ "1_7", new Page1_7() },
				{ "2_1", new Page2_1() },
				{ "2_2", new Page2_2() },
				{ "2_3", new Page2_3() },
				{ "2_4", new Page2_4() },
				{ "2_5", new Page2_5() },
				{ "2_6", new Page2_6() },
				{ "2_7", new Page2_7() },
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

				Hide();
				window.ShowDialog();
			}
			catch
			{
				MessageBox.Show("Викторина находится в разработке");
			}

			Show();
		}

		private void OpenGlossary()
		{
			Hide();

			PageGlossary page = new();
			Reader reader = new(page);
			reader.ShowDialog();

			Show();
		}

		private void OpenTest()
		{
			_name = RemovePrefix(_name);

			string fileName = _name switch
			{
				"1_1" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=9115",
				"1_2" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=9116",
				"1_3" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=8407",
				"1_4" => @"http://82.209.208.36:8080/moodle/mod/quiz/view.php?id=8411",
				_ => string.Empty,
			};

			if (fileName == string.Empty)
			{
				MessageBox.Show("Тест в разработке");
				return;
			}

			string message = "Тестирование проводится на базе Moodle " +
				"и тест будет доступен во время соответствующего занятия";

			MessageBox.Show(message, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);

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

		private void OpenFile(string path)
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
			Hide();

			try
			{
				Reader reader = new(_topics[_name]);
				reader.ShowDialog();
			}
			catch
			{
				MessageBox.Show("Тема в разработке");
			}

			Show();
		}

		private string RemovePrefix(string originString)
		{
			var rezult = originString.Where(x => char.IsLetter(x) == false);
			return new string (rezult.ToArray());
		}
	}
}
