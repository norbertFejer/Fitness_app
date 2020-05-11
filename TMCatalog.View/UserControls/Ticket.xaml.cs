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
    /// Interaction logic for Ticket.xaml
    /// </summary>
    public partial class Ticket : UserControl
    {
        TicketVM ticketVM;

        public Ticket()
        {
            InitializeComponent();
            ticketVM = MainWindowViewModel.Instance.TicketVM;
        }

        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            if (ticketVM.SearchText.Equals(ticketVM.PlaceholderText))
            {
                ticketVM.SearchText = "";
                ticketVM.SearchTicket();
            }
        }

        private void SetPlaceholderText(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(ticketVM.SearchText.Trim()))
            {
                ticketVM.SearchText = ticketVM.PlaceholderText;
                ticketVM.SearchTicket();
            }
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            ticketVM.SearchText = ((TextBox)sender).Text;
            ticketVM.SearchTicket();
        }

        private void OpenAddNewTicketWindowExecute(object obj, RoutedEventArgs e)
        {
            AddNewTicketWindow addNewTicketWindow = new AddNewTicketWindow();
            AddNewTicketWindowViewModel addnewTicketWindowViewModel = new AddNewTicketWindowViewModel();

            ViewService.RegisterView(addnewTicketWindowViewModel.GetType(), addNewTicketWindow.GetType());
            ViewService.AddMainWindowToOpened(addnewTicketWindowViewModel, addNewTicketWindow);
            ViewService.ShowDialog(addnewTicketWindowViewModel);
        }

        private void OpenAddDiscountWindowExecute(object obj, RoutedEventArgs e)
        {
            AddDiscount addDiscountWindow = new AddDiscount();
            AddDiscountWindowViewModel addDiscountWindowViewModel = new AddDiscountWindowViewModel(this.ticketVM.SelectedTicket);

            ViewService.RegisterView(addDiscountWindowViewModel.GetType(), addDiscountWindow.GetType());
            ViewService.AddMainWindowToOpened(addDiscountWindowViewModel, addDiscountWindow);
            ViewService.ShowDialog(addDiscountWindowViewModel);
        }
    }
}
