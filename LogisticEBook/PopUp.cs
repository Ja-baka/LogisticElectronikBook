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
				typeof(Topic1_5ShelveStorage),
				typeof(Topic1_5StackedStorage),
				typeof(Topic1_5Shelf),
				typeof(Topic1_5TypeOfShelfs),
				typeof(Topic1_5ConsoleRacks),
				typeof(Topic1_5MezzanineRacks),
				typeof(Topic1_5FrontalRacks),
				typeof(Topic1_5SixTypesOfRacks),
				typeof(Topic1_6Photo10),
				typeof(Topic1_6Photo11),
				typeof(Topic1_6Photo12),
				typeof(Topic1_6Photo13),
				typeof(Topic1_7Photo_14),
				typeof(Topic1_7Photo_15_16),
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
				typeof(Topic2_2Photo_17),
				typeof(Topic2_2Photo_18),
				typeof(Topic2_2Photo_19),
				typeof(Topic2_2Photo_20),
				typeof(Topic2_2Photo_21),
				typeof(Topic2_2Photo_22),
				typeof(Topic2_2Photo_22_23),
				typeof(Topic2_3Photo_24a),
				typeof(Topic2_3Photo_24b),
				typeof(Topic2_4Photo_25),
				typeof(Topic2_4Photo_26),
				typeof(Topic2_4Photo_27a),
				typeof(Topic2_4Photo_27b),
				typeof(Topic2_4Photo_28),
				typeof(Topic2_4Photo_29),
				typeof(Topic2_4Photo_30a),
				typeof(Topic2_4Photo_30b),
				typeof(Topic2_4Photo_31),
				typeof(Topic2_4Photo_32),
				typeof(Topic2_4Photo_33),
				typeof(Topic2_5Photo_34),
				typeof(Topic2_5Photo_35a),
				typeof(Topic2_5Photo_35b),
				typeof(Topic2_5Photo_35v),
				typeof(Topic2_5Photo_35g),
				typeof(Topic2_5Photo_36),
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