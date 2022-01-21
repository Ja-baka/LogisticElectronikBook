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
		public static void Show(object sender)
		{
			var _windows = new List<Window>
			{
				new StorageDefinition(),
				new CargoDefinition(),
				new SolidCargo(),
				new BulkCargo(),
				new LiquidCargo(),
				new GaseousCargo(),
				new FiveGroups(),
				new SDTarnPiece(),
				new SDBulk(),
				new SDLiquid(),
				new SDStationary(),
				new SDCombinedMaterial(),
				new SDWithSpecialEquipment(),
				new SDWithoutSpecialEquipment(),
				new SDHigh(),
				new SDContainerTypes(),
				new SDStructuresTypes(),
				new Topic1_2PrimaryCargoUnit(),
				new Topic1_2EnlargedCargoUnit(),
				new Topic1_2Pallets(),
				new Topic1_2PalletsSize(),
				new Topic1_2RackPallets(),
				new Topic1_2BoxPallets(),
				new Topic1_2Packaging(),
			};

			if (sender is not FrameworkContentElement element)
			{
				MessageBox.Show("Объект не имеет поля Name");
				return;
			}

			var subset = from w in _windows 
						 where w.GetType().Name == element.Name
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

			Window window = subset.ToArray()[0];
			window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
			window.ShowDialog();
		}
	}
}
