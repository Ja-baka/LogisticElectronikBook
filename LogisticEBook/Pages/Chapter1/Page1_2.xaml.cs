using System.Windows.Controls;
using System.Windows.Input;

namespace LogisticEBook.Pages
{
	/// <summary>
	/// Логика взаимодействия для Page1_2_1.xaml
	/// </summary>
	public partial class Page1_2 : Page, IContent
	{
		public Page1_2()
		{
			InitializeComponent();
		}

		public FlowDocumentReader DocumentViewer => Reader;
	}
}
