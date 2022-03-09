using System.Windows.Controls;

namespace LogisticEBook.Pages
{
	/// <summary>
	/// Логика взаимодействия для Page1_1.xaml
	/// </summary>
	public partial class Page1_1 : Page, IContent
	{
		public Page1_1()
		{
			InitializeComponent();
		}

		public FlowDocumentReader DocumentViewer => Reader;
	}
}
