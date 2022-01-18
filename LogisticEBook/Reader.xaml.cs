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
		private int _currentTopic;
		private int _currentPage;
		private static readonly Page[][] _pages;

		static Reader()
		{
			_pages = new Page[2][];
			_pages[0] = new Page[] { new Page1_1_1(), new Page1_1_2(), new Page1_1_3() };
			_pages[1] = new Page[] { new Page1_2_1() };
		}

		public Reader(int topicIndex)
		{
			InitializeComponent();

			_currentTopic = topicIndex;
			OpenCurrentPage();
		}

		public void OpenLecture(int topicIndex)
		{
			ShowDialog();
		}

		private void ButtonNext_Click(object sender, RoutedEventArgs e)
		{
			_currentPage = 
				_currentPage == _pages[_currentTopic].Length - 1
				? 0 
				: _currentPage + 1;
			OpenCurrentPage();
		}

		private void ButtonPrew_Click(object sender, RoutedEventArgs e)
		{
			_currentPage = 
				_currentPage == 0
				? _pages[_currentTopic].Length - 1
				: _currentPage - 1;
			OpenCurrentPage();
		}

		private void OpenCurrentPage()
		{
			NavigationService navigation = MainFrame.NavigationService;
			navigation.Navigate(_pages[_currentTopic][_currentPage]);
		}

		private void ButtonExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
