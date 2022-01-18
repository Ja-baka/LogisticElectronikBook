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
		private int _currentPage;
		private readonly Page[] _pages;
		private readonly MainPage _mainPage;

		public Reader()
		{
			InitializeComponent();
			_pages = new Page[3] 
			{ 
				new Page1_1_1(), 
				new Page1_1_2(),
				new Page1_1_3()
			};
			_currentPage = 0;
			_mainPage = new MainPage();

			MainFrame.NavigationService.Navigate(_mainPage);
			_mainPage.LectureOpened += (sender, e) => SwitchReadingMode();
		}

		private void SwitchReadingMode()
		{
			ButtonExit.IsEnabled = ButtonExit.IsEnabled == false;
			ButtonNext.IsEnabled = ButtonNext.IsEnabled == false;
			ButtonPrew.IsEnabled = ButtonPrew.IsEnabled == false;
		}

		private void ButtonNext_Click(object sender, RoutedEventArgs e)
		{
			_currentPage = 
				_currentPage == _pages.Length - 1
				? 0 
				: _currentPage + 1;
			GoToCurrentPage();
		}

		private void ButtonPrew_Click(object sender, RoutedEventArgs e)
		{
			_currentPage = 
				_currentPage == 0
				? _pages.Length - 1
				: _currentPage - 1;
			GoToCurrentPage();
		}

		private void GoToCurrentPage()
		{
			MainFrame.NavigationService.Navigate(_pages[_currentPage]);
		}

		private void ButtonExit_Click(object sender, RoutedEventArgs e)
		{
			MainFrame.NavigationService.Navigate(_mainPage);
			SwitchReadingMode();
		}
	}
}
