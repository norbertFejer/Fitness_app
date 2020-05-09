using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public AdmissionVM()
        {
            this.PlaceholderText = "Search by name, card number or phone number...";
            this.SearchText = this.PlaceholderText;
            this.ClientsTicketsList = Data.Catalog.GetAllClientTicketsList(listInactiveTickets);
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

    }
}
