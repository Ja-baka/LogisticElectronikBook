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
	public partial class MainWindow : Window
	{
		private Page[] _pages;
		private int _currentPage;

		public MainWindow()
		{
			InitializeComponent();
			_pages = new Page[2] 
			{ 
				new Page1_1(), new Page1_2() 
			};
			_currentPage = 0;
			GoToCurrentPage();
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
	}
}
