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
using TMCatalog.Common.MVVM;
using TMCatalog.ViewModel;
using TMCatalog.ViewModel.UserControls;

namespace TMCatalog.View.UserControls
{
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : UserControl
    {
        ClientVM clientVM;

        public Client()
        {
            InitializeComponent();
            clientVM = MainWindowViewModel.Instance.ClientVM;
        }

        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            if (clientVM.SearchText.Equals(clientVM.PlaceholderText))
            {
                clientVM.SearchText = "";
                clientVM.SearchClient();
            }
        }

        private void SetPlaceholderText(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(clientVM.SearchText.Trim()))
            {
                clientVM.SearchText = clientVM.PlaceholderText;
                clientVM.SearchClient();
            }
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            clientVM.SearchText = ((TextBox)sender).Text;
            clientVM.SearchClient();
        }

        private void OpenAddNewClientWindowExecute(object obj, RoutedEventArgs e)
        {
            AddNewClientWindow addNewClientWindow = new AddNewClientWindow();
            AddNewClientWindowViewModel addNewClientWindowViewModel = new AddNewClientWindowViewModel();

            ViewService.RegisterView(addNewClientWindowViewModel.GetType(), addNewClientWindow.GetType());
            ViewService.AddMainWindowToOpened(addNewClientWindowViewModel, addNewClientWindow);
            ViewService.ShowDialog(addNewClientWindowViewModel);
        }

        private void OpenEditClientDataWindowExecute(object obj, RoutedEventArgs e)
        {
            EditClientDataWindow editClientDataWindow = new EditClientDataWindow();
            EditClientDataWindowViewModel editClientDataWindowViewModel = new EditClientDataWindowViewModel(this.clientVM.SelectedClient);

            ViewService.RegisterView(editClientDataWindowViewModel.GetType(), editClientDataWindow.GetType());
            ViewService.AddMainWindowToOpened(editClientDataWindowViewModel, editClientDataWindow);
            ViewService.ShowDialog(editClientDataWindowViewModel);
        }

        private void OpenSellTicketWindowExecute(object obj, RoutedEventArgs e)
        {
            SellTicketWindow sellTicketWindow = new SellTicketWindow();
            SellTicketWindowViewModel sellTicketWindowViewModel = new SellTicketWindowViewModel(this.clientVM.SelectedClient);

            ViewService.RegisterView(sellTicketWindowViewModel.GetType(), sellTicketWindow.GetType());
            ViewService.AddMainWindowToOpened(sellTicketWindowViewModel, sellTicketWindow);
            ViewService.ShowDialog(sellTicketWindowViewModel);
        }
    }
}
