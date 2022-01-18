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

namespace LogisticEBook
{
	/// <summary>
	/// Логика взаимодействия для MainMenu.xaml
	/// </summary>
	public partial class MainMenu : Window
	{
		public MainMenu()
		{
			InitializeComponent();
		}

		private void Hyperlink1_1_Click(object sender, RoutedEventArgs e)
		{
			int topicNumber = 0;
			OpenHyperlink(topicNumber);
		}

		private void OpenHyperlink(int topicNumber)
		{
			Hide();
			Reader reader = new Reader();
			reader.OpenLecture(topicNumber);
			Show();
		}
	}
}
