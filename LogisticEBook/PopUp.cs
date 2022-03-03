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
using LogisticEBook.Apps;


namespace LogisticEBook
{
	public static class PopUp
	{
		private static readonly Type[] _windows;

		static PopUp()
		{
			_windows = new Type[]
			{
				typeof(Topic0Photo_1),
				typeof(Topic1_1Photo_1),
				typeof(Topic1_1Photo_2),
				typeof(Topic1_1Photo_3),
				typeof(Topic1_1Photo_4),
				typeof(Topic1_1Photo_5),
				typeof(Topic1_1Photo_6),
				typeof(Topic1_1Photo_7),
				typeof(Topic1_1Photo_8),
				typeof(Topic1_1Photo_9),
				typeof(Topic1_1Photo_10),
				typeof(Topic1_1Photo_11),
				typeof(Topic1_1Photo_12),
				typeof(Topic1_1Photo_13),
				typeof(Topic1_1Photo_14),
				typeof(Topic1_1Photo_15),
				typeof(Topic1_1Photo_16),
				typeof(Topic1_2Photo_1),
				typeof(Topic1_2Photo_2),
				typeof(Topic1_2Photo_3),
				typeof(Topic1_2Photo_4),
				typeof(Topic1_2Photo_5),
				typeof(Topic1_2Photo_6),
				typeof(Topic1_2Video_7),
				typeof(Topic1_2Video_8),
				typeof(Topic1_4Photo_1),
				typeof(Topic1_4Photo_2),
				typeof(Topic1_4Photo_3),
				typeof(Topic1_4Photo_4),
				typeof(Topic1_4Photo_5),
				typeof(Topic1_5Photo_1),
				typeof(Topic1_5Photo_2),
				typeof(Topic1_5Photo_3),
				typeof(Topic1_5Presentation_4),
				typeof(Topic1_5Video_5),
				typeof(Topic1_5Video_6),
				typeof(Topic1_5Video_7),
				typeof(Topic1_5Video_8),
				typeof(Topic1_6Photo1),
				typeof(Topic1_6Photo2),
				typeof(Topic1_6Photo3),
				typeof(Topic1_6Photo4),
				typeof(Topic1_7Photo_1),
				typeof(Topic1_7Photo_2),
				typeof(Topic2_1Photo_1),
				typeof(Topic2_1Photo_2),
				typeof(Topic2_1Photo_3),
				typeof(Topic2_1Photo_4),
				typeof(Topic2_1Photo_5),
				typeof(Topic2_1Photo_6),
				typeof(Topic2_1Photo_7),
				typeof(Topic2_1Photo_8),
				typeof(Topic2_1Photo_9),
				typeof(Topic2_1Photo_10),
				typeof(Topic2_1Photo_11),
				typeof(Topic2_1Photo_12),
				typeof(Topic2_1Photo_13),
				typeof(Topic2_1Photo_14),
				typeof(Topic2_1Photo_15),
				typeof(Topic2_1Photo_16),
				typeof(Topic2_2Photo_1),
				typeof(Topic2_2Photo_2),
				typeof(Topic2_2Photo_3),
				typeof(Topic2_2Photo_4),
				typeof(Topic2_2Photo_5),
				typeof(Topic2_2Photo_6),
				typeof(Topic2_2Photo_7),
				typeof(Topic2_3Photo_1),
				typeof(Topic2_3Photo_1),
				typeof(Topic2_4Photo_1),
				typeof(Topic2_4Photo_2),
				typeof(Topic2_4Photo_3),
				typeof(Topic2_4Photo_4),
				typeof(Topic2_4Photo_5),
				typeof(Topic2_4Photo_6),
				typeof(Topic2_4Photo_7),
				typeof(Topic2_4Photo_8),
				typeof(Topic2_4Photo_9),
				typeof(Topic2_4Photo_10),
				typeof(Topic2_4Photo_11),
				typeof(Topic2_5Photo_1),
				typeof(Topic2_5Photo_2),
				typeof(Topic2_5Photo_3),
				typeof(Topic2_5Photo_4),
				typeof(Topic2_5Photo_5),
				typeof(Topic2_5Photo_6),
				typeof(Topic2_6Photo_1),
				typeof(Topic2_7Photo_1),
			};
		}

		[Obsolete($"Используйте ShowInAppsViewer")]
		public static void Show(object sender)
		{
			string elementName = GetSenderName(sender);
			Type type = GetTypeByElementName(elementName);
			Window window = GetWindowFromType(type);
			TryOpenWindow(window);
		}

		public static void ShowInAppsViewer(object sender)
		{
			string elementName = GetSenderName(sender);

			AppType appType = GetAppType(elementName);
			string path = MakePathFromTopicName(elementName);

			OpenAppByType(path, appType);
		}

		private static void OpenAppByType(string path, AppType appType)
		{
			if (appType == AppType.Photo) // TODO: заменить бы Photo на Image
			{
				ImageViewer viewer = new(path);
				viewer.ShowDialog();
			}
			else if (appType == AppType.Video)
			{
				// VideoViewer
			}
			else if (appType == AppType.Presentation)
			{
				// PresentationViewer
			}
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

		private static void TryOpenWindow(Window window)
		{
			try
			{
				window.ShowDialog();
			}
			catch (InvalidOperationException)
			{
			}
		}

		private static Window GetWindowFromType(Type type)
		{
			object? instance = Activator.CreateInstance(type);

			if (instance is not Window window)
			{
				throw new Exception($"{type} не является окном!");
			}

			return window;
		}

		private static Type GetTypeByElementName(string elementName)
		{
			IEnumerable<Type> enumerable = _windows.Where
				(x => x.Name == elementName);
			Type[] types = enumerable.ToArray();

			if (types.Any() == false)
			{
				throw new Exception($"Не найдено приложение " +
					$"для элемента {elementName}");
			}
			else if (types.Length > 1)
			{
				throw new Exception("Было надено больше одного приложения" +
					$"для элемента {elementName}");
			}
			Type type = types[0];
			return type;
		}

		private static string GetSenderName(object sender)
		{
			if (sender is not FrameworkContentElement element)
			{
				throw new ArgumentException($"{sender} не имеет поля Name");
			}

			return element.Name;
		}

		private static string MakePathFromTopicName(string name)
		{
			name = ReplacePart(name, "Topic", string.Empty);
			name = ReplacePart(name, "Photo_", "/");

			string path = "/Resources/" + name + ".jpg";
			return path;
		}

		private static string ReplacePart(string source, string oldPart, string newPart)
		{
			if (source.Contains(oldPart) == false)
			{
				throw new ArgumentException($"{source} должен содержать {oldPart}");
			}
			return source.Replace(oldPart, newPart);
		}
	}
}