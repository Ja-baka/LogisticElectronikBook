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
using System.Windows.Shapes;

namespace LogisticEBook
{
	/// <summary>
	/// Логика взаимодействия для AppsViewer.xaml
	/// </summary>
	public partial class ImageViewer : Window
	{
		public ImageViewer()
		{
			InitializeComponent();
		}

		public ImageViewer(string path)
			:this()
		{
			FillImageContainer(path);
		}

		private void FillImageContainer(string path)
		{
			try
			{
				BitmapImage image = new();
				image.BeginInit();
				image.UriSource = new Uri(path, UriKind.Relative);
				image.EndInit();

				ImageContainer.Source = image;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
