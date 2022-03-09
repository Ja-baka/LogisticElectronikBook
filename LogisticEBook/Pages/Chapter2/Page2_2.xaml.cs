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
	/// Логика взаимодействия для Page2_2.xaml
	/// </summary>
	public partial class Page2_2 : Page, IContent
	{
		public Page2_2()
		{
			InitializeComponent();
		}

		public FlowDocumentReader DocumentViewer => Reader;
	}
}
