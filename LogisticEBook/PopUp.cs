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
using System.Xml.Linq;
using LogisticEBook.Apps;


namespace LogisticEBook
{
	public class PopUp
	{
		private readonly Dictionary<string, Window> _windows;

		public PopUp()
		{
			_windows = new Dictionary<string, Window>
			{
				{ "StorageDefinition", new StorageDefinition() },
				{ "CargoDefinition", new CargoDefinition() },
			};
		}

		public void Show(object sender)
		{
			if (sender is not FrameworkContentElement element)
			{
				MessageBox.Show("Объект не имеет поля Name");
				return;
			}

			string name = element.Name;

			if (_windows.ContainsKey(name) == false)
			{
				MessageBox.Show("Не найдено приложение для этого элемента");
				return;
			}

			Window window = _windows[name];
			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			window.ShowDialog();
		}
	}
}
