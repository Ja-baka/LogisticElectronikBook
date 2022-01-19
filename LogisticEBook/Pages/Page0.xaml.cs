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
	/// Логика взаимодействия для Page0.xaml
	/// </summary>
	public partial class Page0 : Page
	{
		public Page0()
		{
			InitializeComponent();
		}

		private void Definition_MouseEnter(object sender, MouseEventArgs e)
		{
			PopUpBehavior.Show(sender, e, this);
		}

		private void Definition_MouseLeave(object sender, MouseEventArgs e)
		{
			PopUpBehavior.Hide(sender, e);
		}
	}
}
