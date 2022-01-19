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

namespace LogisticEBook.Pages
{
	/// <summary>
	/// Логика взаимодействия для Page1_1.xaml
	/// </summary>
	public partial class Page1_1 : Page
	{
		private Window _currentWindow;
		private Dictionary<Run, Window> _windows;

		public Page1_1()
		{
			InitializeComponent();

			_windows = new Dictionary<Run, Window>
			{
				{ StorageDefinition, new Apps.App1_1_Storage() }
			};

			_currentWindow = _windows[StorageDefinition];
		}

		private void HyperlinkSTB_Click(object sender, RoutedEventArgs e)
		{
			throw new NotImplementedException();
		}
		
		private void Definition_MouseEnter(object sender, MouseEventArgs e)
		{
			Point pointToWindow = e.GetPosition(this);
			Point pointToScreen = PointToScreen(pointToWindow);

			DefineApp(sender);

			_currentWindow.Left = pointToScreen.X;
			_currentWindow.Top = pointToScreen.Y - _currentWindow.Height * 1.75;

			_currentWindow.Show();
		}

		private void Definition_MouseLeave(object sender, MouseEventArgs e)
		{
			_currentWindow.Hide();
		}

		private void DefineApp(object sender)
		{
			if (sender is Run run)
			{
				_currentWindow = _windows[run];
			}
			else
			{
				throw new ArgumentException
					("Событие должно вызываться только у элементов Run");
			}
		}
	}
}
