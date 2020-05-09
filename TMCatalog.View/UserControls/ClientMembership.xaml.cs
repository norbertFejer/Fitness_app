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
using TMCatalog.ViewModel;
using TMCatalog.ViewModel.UserControls;

namespace TMCatalog.View.UserControls
{
    /// <summary>
    /// Interaction logic for ClientMembership.xaml
    /// </summary>
    public partial class ClientMembership : UserControl
    {
        ClientMembershipVM clientMembershipVM;

        public ClientMembership()
        {
            InitializeComponent();
            clientMembershipVM = MainWindowViewModel.Instance.ClientMembershipVM;
        }

        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            if (clientMembershipVM.SearchText.Equals(clientMembershipVM.PlaceholderText))
            {
                clientMembershipVM.SearchText = "";
                clientMembershipVM.SearchClientMembership();
            }
        }

        private void SetPlaceholderText(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(clientMembershipVM.SearchText.Trim()))
            {
                clientMembershipVM.SearchText = clientMembershipVM.PlaceholderText;
                clientMembershipVM.SearchClientMembership();
            }
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            clientMembershipVM.SearchText = ((TextBox)sender).Text;
            clientMembershipVM.SearchClientMembership();
        }
    }
}
