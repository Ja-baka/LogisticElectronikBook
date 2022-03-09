﻿using System;
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
//using Microsoft.Office.Interop.Word;

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
			}
			catch (Exception ex)
			{
				MessageBox.Show($"{ex.Message} \n {ex.StackTrace}");
			}
		}

		private TextRange GetSelectedText()
		{
			if (MainFrame.Content is not IContent page)
			{
				throw new Exception("Страница не реализует интерфейс IFlowDocument");
			}

			TextPointer textSelectionStart = page.DocumentContent.Selection.Start;
			TextPointer textSelectionEnd = page.DocumentContent.Selection.End;
			TextRange range = new(textSelectionStart, textSelectionEnd);
			return range;
		}
	}
}
