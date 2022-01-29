using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для PageGlossary.xaml
    /// </summary>
    public partial class PageGlossary : Page
    {
        private string _name = string.Empty;

        public PageGlossary()
        {
            InitializeComponent();
        }

		private void OpenTopic(object sender, MouseButtonEventArgs e)
		{
			if (sender is not FrameworkContentElement element)
			{
				MessageBox.Show("Это не элемент");
				return;
			}

			_name = element.Name;
			_name = RemovePostfix();
            _name = "LogisticEBook.Pages." + _name;

			Assembly assembly = Assembly.Load("LogisticEBook");
			Type? type = assembly.GetType(_name);
			dynamic? page = Activator.CreateInstance(type);
			NavigationService.Navigate(page);
		}

        private string RemovePostfix()
        {
            string[] array = _name.Split("_");


            return array[0] == "Page0"
                ? array[0]
                : array[0] + "_" + array[1];
        }
    }
}
