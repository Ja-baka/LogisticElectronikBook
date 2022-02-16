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
using static System.Net.Mime.MediaTypeNames;

namespace LogisticEBook.Quizes
{
	/// <summary>
	/// Логика взаимодействия для Quiz2_1.xaml
	/// </summary>
	public partial class Quiz2_1 : Window
	{
		public Quiz2_1()
		{
			InitializeComponent();
			StartGame();
			NextQuestion();
		}

		private readonly Question[] _questions =  
		{ 
			new Question() 
			{ 
				QuestionText = "Стеллажи  максимально подходят для ручной обработки грузов, а так же,длямногоярусногохранениянеупакованных товаров (в коробках, штучных товаров россыпью) на паллетах,возможностьразмещениябольшогоколичества номенклатуры; возможность поштучной обработки товаров",
				Answer1 = "Консольные стеллажи",
				Answer2 = "Полочный стеллаж",
				Answer3 = "Паллетные стеллажи",
				Answer4 = "Мезонинный стеллаж",
				ImagePath = "/2_1/Photo_1.jpg",
				NumberOfCorrectAnswer = 2
			},
			new Question() 
			{ 
				QuestionText = "В этих стеллажах грузы подаются со стороны загрузки и медленно передвигаются по роликовым направляющим под действием собственного веса к месту разгрузки.",
				Answer1 = "Гравитационный стеллаж",
				Answer2 = "Консольные стеллажи",
				Answer3 = "Паллетные стеллажи",
				Answer4 = "Полочный стеллаж",
				ImagePath = "/2_1/Photo_2.jpg",
				NumberOfCorrectAnswer = 1
			},
			new Question() 
			{ 
				QuestionText = "Стеллажи состоят из вертикальных стоек и горизонтальных консолей. Предназначены для хранения крупногабаритных, длинномерных грузов и материалов (панелей, плит, листового металла, металлического профиля и прутка, труб, штанг, кабеля на барабанах и катушках, рулонных материалов и т.п.).",
				Answer1 = "Полочный стеллаж",
				Answer2 = "Мезонинный стеллаж",
				Answer3 = "Консольные стеллажи",
				Answer4 = "Паллетные стеллажи",
				ImagePath = "/2_1/Photo_3.jpg",
				NumberOfCorrectAnswer = 3
			},
			new Question() 
			{ 
				QuestionText = "Многоуровневая стеллажная система, сконструированная на базе стандартных полочных, паллетных стеллажей и дополнительных элементов (межуровневых перекрытий, лестниц и ограждений).",
				Answer1 = "Паллетные стеллажи",
				Answer2 = "Гравитационный стеллаж",
				Answer3 = "Консольные стеллажи",
				Answer4 = "Мезонинный стеллаж",
				ImagePath = "/2_1/Photo_4.jpg",
				NumberOfCorrectAnswer = 4
			},
			new Question() 
			{ 
				QuestionText = "Стеллажи предназначены для хранения различных грузов на поддонах. Состоят из рамы (из оцинкованных профилей) и балок – из металлических холоднокатаных профилей.",
				Answer1 = "Паллетные стеллажи",
				Answer2 = "Мезонинный стеллаж",
				Answer3 = "Консольные стеллажи",
				Answer4 = "Гравитационный стеллаж",
				ImagePath = "/2_1/Photo_5.jpg",
				NumberOfCorrectAnswer = 1
			},
		};

		private List<int> _questionNumbers = new() { 0, 1, 2, 3, 4 };
		private int _currentQuestionNumber;
		private int _indexOfCurrentQuestion;
		private int _score;

		private void AnswerChecker(object sender, RoutedEventArgs e)
		{
			if (sender is not Button senderButton)
			{
				return;
			}

			if (senderButton.Tag.ToString() == "Correct Answer")
			{
				_score++;
				TextBlockRight.Text = "Верно";
				TextBlockRight.Foreground = Brushes.Green;
			}
			else
			{
				TextBlockRight.Text = "Неверно";
				TextBlockRight.Foreground = Brushes.Red;
			}

			_indexOfCurrentQuestion = _indexOfCurrentQuestion < 0
				? 0
				: _indexOfCurrentQuestion + 1;

			TextBlockScore.Text = $"Правильных ответов: {_score}";
			if (_indexOfCurrentQuestion < _questions.Length)
			{
				TextBlockQuestionOrder.Text = $"Вопрос: "
					+ $"{_indexOfCurrentQuestion + 1}/{_questions.Length}";
			}

			NextQuestion();
		}

		private void EndGame()
		{
			const int MaxScore = 10;
			string message = $"Оценка: " 
				+ $"{MaxScore / _questions.Length * _score}.\n"
				+ $"Желаете пройти тест ещё раз?";
			string caption = "Тест завершён";
			MessageBoxButton buttonYesNo = MessageBoxButton.YesNo;
			MessageBoxImage image = MessageBoxImage.Information;

			var result = MessageBox.Show(message, caption, buttonYesNo, image);

			if (result == MessageBoxResult.No)
			{
				Close();
			}
			else
			{
				_score = 0;
				_indexOfCurrentQuestion = -1;
				_currentQuestionNumber = 0;
				StartGame();
			}
		}

		private void NextQuestion()
		{
			if (_indexOfCurrentQuestion == _questionNumbers.Count)
			{
				EndGame();
			}
			else
			{
				_currentQuestionNumber = _questionNumbers[_indexOfCurrentQuestion];
			}

			Button[] buttons
				= { ButtonAnswer1, ButtonAnswer2, ButtonAnswer3, ButtonAnswer4 };

			foreach (Button button in buttons)
			{
				button.Tag = "Wrong Answer";
			}

			buttons = buttons
				.OrderBy(a => Guid.NewGuid()).ToArray();

			Question question = _questions[_currentQuestionNumber];

			TextBlockQuestion.Text = question.QuestionText;
			buttons[0].Content = question.Answer1;
			buttons[1].Content = question.Answer2;
			buttons[2].Content = question.Answer3;
			buttons[3].Content = question.Answer4;

			buttons[question.NumberOfCorrectAnswer - 1].Tag = "Correct Answer";

			ImagePhoto.Source = new BitmapImage(new Uri(
				$"pack://application:,,,/Quizes/Images" + question.ImagePath));
		}

		private void StartGame()
		{
			_questionNumbers = _questionNumbers
				.OrderBy(a => Guid.NewGuid()).ToList();

			TextBlockRight.Text = string.Empty;
			TextBlockQuestionOrder.Text = $"Вопрос: 1/5";
		}
	}
}

