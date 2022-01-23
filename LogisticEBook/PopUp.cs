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
		private static readonly List<Type> _windows;

		static PopUp()
		{
			_windows = new List<Type>
			{
				typeof(StorageDefinition),
				typeof(CargoDefinition),
				typeof(SolidCargo),
				typeof(BulkCargo),
				typeof(LiquidCargo),
				typeof(GaseousCargo),
				typeof(FiveGroups),
				typeof(SDTarnPiece),
				typeof(SDBulk),
				typeof(SDLiquid),
				typeof(SDStationary),
				typeof(SDCombinedMaterial),
				typeof(SDWithSpecialEquipment),
				typeof(SDWithoutSpecialEquipment),
				typeof(SDHigh),
				typeof(SDContainerTypes),
				typeof(SDStructuresTypes),
				typeof(Topic1_2PrimaryCargoUnit),
				typeof(Topic1_2EnlargedCargoUnit),
				typeof(Topic1_2Pallets),
				typeof(Topic1_2PalletsSize),
				typeof(Topic1_2RackPallets),
				typeof(Topic1_2BoxPallets),
				typeof(Topic1_2Packaging),
				typeof(Topic1_4TypesOfWarehouses),
				typeof(Topic1_4ClosedWarehouse),
				typeof(Topic1_4OpenWarehouse),
				typeof(Topic1_4SemiClosedWareHouse),
				typeof(Topic1_4WarehouseElements),
				typeof(Topic1_5ShelveStorage),
				typeof(Topic1_5StackedStorage),
				typeof(Topic1_5Shelf),
				typeof(Topic1_5TypeOfShelfs),
			};
		}

		public static void Show(object sender)
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