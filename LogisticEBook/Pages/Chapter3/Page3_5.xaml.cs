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
    /// Логика взаимодействия для Page3_5.xaml
    /// </summary>
    public partial class Page3_5 : Page, IContent
	{
		public Page3_5()
		{
			InitializeComponent();
		}
		public FlowDocumentReader DocumentViewer => Reader;
	}
}
