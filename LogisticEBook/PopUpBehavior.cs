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


namespace LogisticEBook
{
	public static class PopUpBehavior
	{
		private static Window _currentWindow;
		private static object _callingWindow;
		private static readonly Dictionary<string, Window> _windows;

		static PopUpBehavior()
		{
			_windows = new Dictionary<string, Window>
			{
				{ "StorageDefinition", new Apps.App1_1_Storage() }
			};
		}

		public static void Show(object sender, MouseEventArgs e, object callingWindow)
		{
			_callingWindow = callingWindow;

			Point pointToWindow = e.GetPosition((IInputElement) _callingWindow);
			Point pointToScreen = ((Visual)_callingWindow).PointToScreen(pointToWindow);

			DefineApp(sender);

			_currentWindow.Left = pointToScreen.X;
			_currentWindow.Top = pointToScreen.Y - _currentWindow.Height * 1.75;

			_currentWindow.Show();
		}

		public static void Hide(object sender, MouseEventArgs e)
		{
			_currentWindow.Hide();
		}

		private static void DefineApp(object sender)
		{
			if (sender is Run run)
			{
				_currentWindow = _windows[run.Name];
			}
			else
			{
				throw new ArgumentException
					("Событие должно вызываться только у элементов Run");
			}
		}
	}
}
