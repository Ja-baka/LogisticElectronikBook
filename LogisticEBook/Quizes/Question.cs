using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticEBook.Quizes
{
	public struct Question
	{
		public string QuestionText { get; set; }
		public string Answer1 { get; set; }
		public string Answer2 { get; set; }
		public string Answer3 { get; set; }
		public string Answer4 { get; set; }
		public int ImageNumber { get; set; }
		public int NumberOfCorrectAnswer { get; set; }
	}
}
