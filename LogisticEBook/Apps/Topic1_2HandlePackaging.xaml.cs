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

namespace LogisticEBook.Apps
{
	/// <summary>
	/// Логика взаимодействия для Topic1_2HandlePackaging.xaml
	/// </summary>
	public partial class Topic1_2HandlePackaging : Window
	{
		public Topic1_2HandlePackaging()
		{
			InitializeComponent();

			Uri path = new(System.IO.Directory.GetCurrentDirectory()
				+ @"/Resources/1_2/HandlePackaging.mp4");

			MediaPlayer.Source = path;
		}

		private void ButtonPlay_Click(object sender, RoutedEventArgs e)
		{
			MediaPlayer.Play();
		}

		private void ButtonPause_Click(object sender, RoutedEventArgs e)
		{
			MediaPlayer.Pause();
		}

		private void ButtonStop_Click(object sender, RoutedEventArgs e)
		{
			MediaPlayer.Stop();
		}
	}
}
