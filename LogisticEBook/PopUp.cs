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
				typeof(Topic1_2AutoPackaging),
				typeof(Topic1_2HandlePackaging),
				typeof(Topic1_4TypesOfWarehouses),
				typeof(Topic1_4ClosedWarehouse),
				typeof(Topic1_4OpenWarehouse),
				typeof(Topic1_4SemiClosedWareHouse),
				typeof(Topic1_4WarehouseElements),
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