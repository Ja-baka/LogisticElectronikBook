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
using System.Xml.Linq;


namespace LogisticEBook
{
	public static class PopUp
	{
		public static void ShowInAppsViewer(object sender)
		{
			try
			{
				string elementName = GetSenderName(sender);

				AppType appType = GetAppType(elementName);
				string path = MakePathFromTopicName(elementName, appType);

				OpenAppByType(path, appType);

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
			}		
		}

		private static void OpenAppByType(string path, AppType appType)
		{
			Window window;

			if (appType == AppType.Photo)
			{
				window = new ImageViewer(path);
			}
			else if (appType == AppType.Video)
			{
				window = new VideoViewer(path);
			}
			else if (appType == AppType.Presentation)
			{
				PresentationViewer.OpenPresentation(path);
				return;
			}
			else
			{
				throw new Exception("Неизвестный тип приложения");
			}

			window.ShowDialog();
		}

		private static AppType GetAppType(string elementName)
		{
			if (elementName.Contains("Photo"))
			{
				return AppType.Photo;
			}
			else if (elementName.Contains("Video"))
			{
				return AppType.Video;
			}
			else if (elementName.Contains("Presentation"))
			{
				return AppType.Presentation;
			}
			else
			{
				throw new ArgumentException($"{elementName} " 
					+ $"не относится ни к какому типу");
			}
		}

		private static string GetSenderName(object sender)
		{
			if (sender is not FrameworkContentElement element
				|| element.Name == string.Empty)
			{
				throw new ArgumentException($"{sender} не имеет имени");
			}

			return element.Name;
		}

		private static string MakePathFromTopicName(string name, AppType appType)
		{
			string extetion = string.Empty;
			string location = string.Empty;

			if (appType == AppType.Photo)
			{
				extetion = ".jpg";
				location = "/Resources/";
				name = name.Replace("Photo_", "/");
				name = name.Replace("_", "/");
			}
			else if (appType == AppType.Video)
			{
				extetion = ".mp4";
				location = "/Videos/";
				name = name.Replace("Video_", "/");
			}
			else if (appType == AppType.Presentation)
			{
				extetion = ".pptx";
				location = "/Presentations/";
				name = name.Replace("Presentation_", "/");
			}

			name = name.Replace("Topic", string.Empty);

			return location + name + extetion;
		}
	}
}