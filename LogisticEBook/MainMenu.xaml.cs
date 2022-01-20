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
		private Dictionary<Hyperlink, string> _topics;

		public MainMenu()
		{
			InitializeComponent();
			_topics = new Dictionary<Hyperlink, string>
			{
				{ Hyperlink0, "0" },
				{ Hyperlink1_1, "1.1" },
				{ Hyperlink1_2, "1.2" }
			};
		}

		private void OpenTopicByIndex(string topicIndex)
		{
			Hide();

			Reader reader = new Reader(topicIndex);
			reader.ShowDialog();
			
			Show();
		}

		private void Window_Closed(object sender, EventArgs e)
		{
			System.Diagnostics.Process.GetCurrentProcess().Kill();
		}

		private void Hyperlink_Click(object sender, RoutedEventArgs e)
		{
			if (sender is Hyperlink)
			{ 
				string number = _topics[sender as Hyperlink];
				OpenTopicByIndex(number);
			}
			else
			{
				MessageBox.Show("Данный метод может вызываться только у гиперссылок");
			}
		}
	}
}
