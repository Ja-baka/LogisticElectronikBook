using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using LogisticEBook.Pages;
using System.Runtime.InteropServices;
using static LogisticEBook.Reader;

namespace LogisticEBook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class Reader : Window
	{
		public Reader(Page page)
		{
			InitializeComponent();

			NavigationService navigation = MainFrame.NavigationService;
			navigation.Navigate(page);
		}

		private void ButtonExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}


		private void ButtonSelect_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (MainFrame.Content is not IFlowDocument page)
				{
					return;
				}

				TextPointer potStart = page.FlowDocumentReader.Selection.Start;
				TextPointer potEnd = page.FlowDocumentReader.Selection.End;
				TextRange range = new(potStart, potEnd);

				MessageBox.Show("Выделенный текст:\n" + range.Text);

			}
			catch (Exception ex)
			{
				MessageBox.Show("bruh:\n" + ex.Message + "\n" + ex.StackTrace);
			}
		}
	}
}
