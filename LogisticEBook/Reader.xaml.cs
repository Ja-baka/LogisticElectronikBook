using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using LogisticEBook.Pages;
using System.Runtime.InteropServices;
using static LogisticEBook.Reader;
using System.IO;
using System.Windows.Markup;
using System.Xml;

namespace LogisticEBook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class Reader : Window
	{
		public Reader(Page page)
		{
			InitializeComponent();

			NavigationService navigation = MainFrame.NavigationService;
			navigation.Navigate(page);

			if (page is not IContent contentPage)
			{
				ButtonDeselect.IsEnabled = false;
				ButtonSelect.IsEnabled = false;
				return;
			}

			LoadPage(contentPage);
		}

		private void ButtonExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void ButtonSelect_Click(object sender, RoutedEventArgs e)
		{
			ChangeBackground(Brushes.Yellow);
		}

		private void ButtonDeselect_Click(object sender, RoutedEventArgs e)
		{
			ChangeBackground(Brushes.Transparent);
		}

		private void ChangeBackground(SolidColorBrush brush)
		{
			try
			{
				TextRange range = GetSelectedText();

				range.ApplyPropertyValue(TextElement.BackgroundProperty, brush);

				SavePage();
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private TextRange GetSelectedText()
		{
			IContent page = MainFrameToContentPage();

			TextPointer textSelectionStart = page.DocumentViewer.Selection.Start;
			TextPointer textSelectionEnd = page.DocumentViewer.Selection.End;
			TextRange range = new(textSelectionStart, textSelectionEnd);
			return range;
		}

		private IContent MainFrameToContentPage()
		{
			return MainFrame.Content is IContent page
				? page
				: throw new Exception("Страница не реализует интерфейс IFlowDocument");
		}


		private void SavePage()
		{
			IContent page = MainFrameToContentPage();
			string path = $"Pages/{page.GetType().Name}.xaml";

			using FileStream fileStream = File.Open(path, FileMode.Create);
			if (page.DocumentViewer.Document is FlowDocument document)
			{
				XamlWriter.Save(document, fileStream);
			}
		}

		private static void LoadPage(IContent page)
		{
			try
			{
				string path = $"Pages/{page.GetType().Name}.xaml";

				using FileStream fileStream = File.Open(path, FileMode.OpenOrCreate);
				if (XamlReader.Load(fileStream) is FlowDocument document)
				{
					page.DocumentViewer.Document = document;
				}
			}
			catch (XamlParseException)
			{
				// Это исключение вызывается если в файле вся страница,
				// а не только FlowDocument. Фиксится при сохранении,
				// поэтому это исключение я игнорирую
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private static void HandleException(Exception ex)
		{
			MessageBox.Show
			(
				$"Message - {ex.Message}\n"
				+ $"Inner Exception - {ex.InnerException}"
				+ $"Stack Trace - {ex.StackTrace}\n"
			);
		}
	}
}
