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
    /// Логика взаимодействия для VideoViewer.xaml
    /// </summary>
    public partial class VideoViewer : Window
    {
        public VideoViewer(string path)
        {
			InitializeComponent();

			Uri uriPath = new(System.IO.Directory.GetCurrentDirectory()
				+ path);

			MediaPlayer.Source = uriPath;
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
