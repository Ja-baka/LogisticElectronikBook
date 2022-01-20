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
		private readonly List<Type> _windows;

		public PopUp()
		{
			_windows = new List<Type>
			{
				typeof(StorageDefinition),
				typeof(CargoDefinition),
			};
		}

		public void Show(object sender)
		{
			if (sender is not FrameworkContentElement element)
			{
				MessageBox.Show("Объект не имеет поля Name");
				return;
			}

			var subset = from w in _windows 
						 where w.Name == element.Name
						 select w;

			if (subset.Any() == false)
			{
				MessageBox.Show("Не найдено приложение для этого элемента");
				return;
			}
			else if (subset.Count() > 1)
			{
				MessageBox.Show("Было надено больше одного приложения");
			}

			Type type = subset.ToArray()[0];
	
			object? instance = Activator.CreateInstance(type);
			if (instance is Window window)
			{
				window.ShowDialog();
			}
			else
			{
				MessageBox.Show($"{type} не является окном!");
			}
		}
	}
}
