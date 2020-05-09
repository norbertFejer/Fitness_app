using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TMCatalog.Common.MVVM;
using TMCatalog.Logic;

namespace TMCatalog.ViewModel.UserControls
{
    public class AdmissionVM : ViewModelBase
    {
        private string placeholderText;
        private string searchText;
        private List<object> clientsTicketsList;
        private bool listInactiveTickets = false;
        private object selectedItem;

        public RelayCommand EnterClientCommand { get; private set; }

        public AdmissionVM()
        {
            this.PlaceholderText = "Search by name, card number or phone number...";
            this.SearchText = this.PlaceholderText;
            //this.ClientsTicketsList = Data.Catalog.GetAllClientTicketsList(listInactiveTickets);

            this.EnterClientCommand = new RelayCommand(this.EnterClientExecute, this.EnterClientCanExecute);
        }

        public string SearchText
        {
            get
            {
                return this.searchText;
            }

            set
            {
                this.searchText = value;
                this.RaisePropertyChanged();
            }
        }

        public string PlaceholderText
        {
            get
            {
                return this.placeholderText;
            }

            set
            {
                this.placeholderText = value;
                this.RaisePropertyChanged();
            }
        }

        public List<object> ClientsTicketsList
        {
            get
            {
                return this.clientsTicketsList;
            }

            set
            {
                this.clientsTicketsList = value;
                this.RaisePropertyChanged();
            }
        }

        public bool ListInactiveTickets
        {
            get
            {
                return this.listInactiveTickets;
            }

            set
            {
                this.listInactiveTickets = value;
                SearchClientTickets();
                this.RaisePropertyChanged();
            }
        }

        public void SearchClientTickets()
        {

            if (String.IsNullOrEmpty(SearchText.Trim()) || SearchText.Equals(PlaceholderText))
            {
                this.ClientsTicketsList = Data.Catalog.GetAllClientTicketsList(ListInactiveTickets);
            }
            else
            {
                if (SearchText.StartsWith("0"))
                {
                    this.ClientsTicketsList = Data.Catalog.GetClientTicketsListByPhoneNumber(ListInactiveTickets, SearchText);
                }
                else
                {
                    if (int.TryParse(SearchText, out int cardNumber))
                    {
                        this.ClientsTicketsList = Data.Catalog.GetClientTicketsListByCardNumber(ListInactiveTickets, SearchText);
                    }
                    else
                    {
                        this.ClientsTicketsList = Data.Catalog.GetClientTicketsListByName(ListInactiveTickets, SearchText);
                    }
                }
            }
        }

        public object SelectedItem {
            get
            {
                return this.selectedItem;
            }

            set
            {
                this.selectedItem = value;
                this.RaisePropertyChanged();
            }
        }

        private void EnterClientExecute()
        {
            string firstName = getPropertValueFromSelectedItem("FirstName").ToString();
            string lastName = getPropertValueFromSelectedItem("LastName").ToString();
            string ticketType = getPropertValueFromSelectedItem("TicketType").ToString();
            string msg = "Do you want to enter " + firstName + " " + lastName + " to " + ticketType + "?";
            MessageBoxResult enterClientRes = MessageBox.Show(msg, "Fitness App", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (enterClientRes == MessageBoxResult.No)
            {
                return;
            }

            string strValidUntil = getPropertValueFromSelectedItem("ValidUntil").ToString();
            string validityNum = getPropertValueFromSelectedItem("ValidityNumber").ToString();
            string entranceLeft = getPropertValueFromSelectedItem("EntranceLeft").ToString();
            DateTime validUntil = DateTime.Parse(strValidUntil);


            if ( (int.Parse(validityNum) == -1) || (validUntil >= DateTime.Now && int.Parse(validityNum) != -1)
                && (int.Parse(entranceLeft) > 0 || int.Parse(entranceLeft) == -1))
            {
                string clientMembershipId = getPropertValueFromSelectedItem("ClientMembershipId").ToString();
                int result = Data.Catalog.DecreaseEntranceNumberByMembershipId(int.Parse(clientMembershipId));

                if (result == 1)
                {
                    result = Data.Catalog.AddNewEntrance(int.Parse(clientMembershipId), DateTime.Now);

                    if (result == 1)
                    {
                        var period = validUntil - DateTime.Now;
                        if (period.Days <= 2 || int.Parse(entranceLeft) <= 2)
                        {
                            PrintEnterClientMsg(2);
                        }
                        else
                        {
                            PrintEnterClientMsg(1);
                        }
                    }
                    else
                    {
                        PrintEnterClientMsg(0);
                    }
                }
                else
                {
                    PrintEnterClientMsg(0);
                }
            }
            else
            {
                MessageBox.Show("The selected ticket is inactive!", "Information", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PrintEnterClientMsg(int resCode)
        {
            SearchClientTickets();
            switch (resCode)
            {

                case 0:
                    MessageBox.Show("Something went wrong, please try again later!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case 1:
                    MessageBox.Show("Client entered successfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case 2:
                    MessageBox.Show("Client entered successfully!\nGiven ticket will expire soon!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
            }
        }

        private object getPropertValueFromSelectedItem(string property)
        {
            return this.SelectedItem.GetType().GetProperty(property).GetValue(this.SelectedItem, null);
        }

        private bool EnterClientCanExecute()
        {
            return this.SelectedItem != null;
        }

    }
}
