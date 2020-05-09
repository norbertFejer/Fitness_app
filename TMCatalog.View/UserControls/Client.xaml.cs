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

namespace TMCatalog.View.UserControls
{
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : UserControl
    {
        private const string placeholderText = "Search by name, email or phone number...";

        public Client()
        {
            InitializeComponent();
        }

        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            if (((TextBox) sender).Text.Equals(placeholderText))
            {
                ((TextBox) sender).Text = "";
            }
        }

        private void SetPlaceholderText(object sender, RoutedEventArgs e)
        {
            if (((TextBox) sender).Text == null || ((TextBox) sender).Text.Trim().Equals(""))
            {
                ((TextBox) sender).Text = placeholderText;
            }
        }
    }
}
