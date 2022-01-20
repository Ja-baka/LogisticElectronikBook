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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogisticEBook.Pages;

namespace LogisticEBook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class Reader : Window
	{
		private string _currentTopic;
		private static readonly Dictionary<string, Page> _pages;

		static Reader()
		{
			_pages = new Dictionary<string, Page>
			{
				{ "0",   new Page0()   },
				{ "1.1", new Page1_1() },
				{ "1.2", new Page1_2() }
			};
		}

		public Reader(string topicIndex)
		{
			InitializeComponent();

			_currentTopic = topicIndex;
			OpenCurrentPage();
		}

		private void OpenCurrentPage()
		{
			NavigationService navigation = MainFrame.NavigationService;
			navigation.Navigate(_pages[_currentTopic]);
		}

		private void ButtonExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
