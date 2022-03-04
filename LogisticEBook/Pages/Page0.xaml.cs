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
	public partial class Page0 : Page, IFlowDocument
	{
		public Page0()
		{
			InitializeComponent();
		}

		public FlowDocumentReader FlowDocumentReader => Reader;

		private void OpenPopUp(object sender, MouseEventArgs e)
		{
			PopUp.ShowInAppsViewer(sender);
		}
	}
}
