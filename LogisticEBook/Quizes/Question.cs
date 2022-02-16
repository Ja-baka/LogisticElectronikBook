using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEBook.Quizes
{
	public class Question
	{
		public string QuestionText { get; set; } = "Вопрос";
		public string[] Answers { get; } = new string[4];
		public string Answer1 { get; set; } = "Вариант 1";
		public string Answer2 { get; set; } = "Вариант 2";
		public string Answer3 { get; set; } = "Вариант 3";
		public string Answer4 { get; set; } = "Вариант 4";
		public string ImagePath { get; set; } = string.Empty;
		public int NumberOfCorrectAnswer { get; set; }
	}
}
