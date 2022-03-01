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
	public static class PopUp
	{
		private static readonly Type[] _windows;

		static PopUp()
		{
			_windows = new Type[]
			{
				typeof(Topic0Photo_1),
				typeof(Topic1_1Photo_1),
				typeof(Topic1_1Photo_2),
				typeof(Topic1_1Photo_3),
				typeof(Topic1_1Photo_4),
				typeof(Topic1_1Photo_5),
				typeof(Topic1_1Photo_6),
				typeof(Topic1_1Photo_7),
				typeof(Topic1_1Photo_8),
				typeof(Topic1_1Photo_9),
				typeof(Topic1_1Photo_10),
				typeof(Topic1_1Photo_11),
				typeof(Topic1_1Photo_12),
				typeof(Topic1_1Photo_13),
				typeof(Topic1_1Photo_14),
				typeof(Topic1_1Photo_15),
				typeof(Topic1_1Photo_16),
				typeof(Topic1_2Photo_1),
				typeof(Topic1_2Photo_2),
				typeof(Topic1_2Photo_3),
				typeof(Topic1_2Photo_4),
				typeof(Topic1_2Photo_5),
				typeof(Topic1_2Photo_6),
				typeof(Topic1_2Video_7),
				typeof(Topic1_2Video_8),
				typeof(Topic1_4Photo_1),
				typeof(Topic1_4Photo_2),
				typeof(Topic1_4Photo_3),
				typeof(Topic1_4Photo_4),
				typeof(Topic1_4Photo_5),
				typeof(Topic1_5Photo_1),
				typeof(Topic1_5Photo_2),
				typeof(Topic1_5Photo_3),
				typeof(Topic1_5Presentation_4),
				typeof(Topic1_5Video_5),
				typeof(Topic1_5Video_6),
				typeof(Topic1_5Video_7),
				typeof(Topic1_5Video_8),
				typeof(Topic1_6Photo1),
				typeof(Topic1_6Photo2),
				typeof(Topic1_6Photo3),
				typeof(Topic1_6Photo4),
				typeof(Topic1_7Photo_1),
				typeof(Topic1_7Photo_2),
				typeof(Topic2_1Photo_1),
				typeof(Topic2_1Photo_2),
				typeof(Topic2_1Photo_3),
				typeof(Topic2_1Photo_4),
				typeof(Topic2_1Photo_5),
				typeof(Topic2_1Photo_6),
				typeof(Topic2_1Photo_7),
				typeof(Topic2_1Photo_8),
				typeof(Topic2_1Photo_9),
				typeof(Topic2_1Photo_10),
				typeof(Topic2_1Photo_11),
				typeof(Topic2_1Photo_12),
				typeof(Topic2_1Photo_13),
				typeof(Topic2_1Photo_14),
				typeof(Topic2_1Photo_15),
				typeof(Topic2_1Photo_16),
				typeof(Topic2_2Photo_1),
				typeof(Topic2_2Photo_2),
				typeof(Topic2_2Photo_3),
				typeof(Topic2_2Photo_4),
				typeof(Topic2_2Photo_5),
				typeof(Topic2_2Photo_6),
				typeof(Topic2_2Photo_7),
				typeof(Topic2_3Photo_1),
				typeof(Topic2_3Photo_1),
				typeof(Topic2_4Photo_1),
				typeof(Topic2_4Photo_2),
				typeof(Topic2_4Photo_3),
				typeof(Topic2_4Photo_4),
				typeof(Topic2_4Photo_5),
				typeof(Topic2_4Photo_6),
				typeof(Topic2_4Photo_7),
				typeof(Topic2_4Photo_8),
				typeof(Topic2_4Photo_9),
				typeof(Topic2_4Photo_10),
				typeof(Topic2_4Photo_11),
				typeof(Topic2_5Photo_1),
				typeof(Topic2_5Photo_2),
				typeof(Topic2_5Photo_3),
				typeof(Topic2_5Photo_4),
				typeof(Topic2_5Photo_5),
				typeof(Topic2_5Photo_6),
				typeof(Topic2_6Photo_37),
				typeof(Topic2_7Photo_38),
			};
		}

		public static void Show(object sender)
		{
			if (sender is not FrameworkContentElement element)
			{
				MessageBox.Show("Объект не имеет поля Name");
				return;
			}

			Type[] types = _windows.Where(x => x.Name == element.Name).ToArray();

			if (types.Any() == false)
			{
				MessageBox.Show($"Не найдено приложение для элемента {element.Name}");
				return;
			}
			else if (types.Length > 1)
			{
				MessageBox.Show("Было надено больше одного приложения");
			}

			Type type = types[0];
			object? instance = Activator.CreateInstance(type);

			if (instance is Window window)
			{
				try
				{
					window.ShowDialog();
				}
				catch (InvalidOperationException)
				{
				}
			}
			else
			{
				MessageBox.Show($"{type} не является окном!");
			}
		}
	}
}