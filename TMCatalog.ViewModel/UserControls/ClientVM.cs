using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCatalog.Common.MVVM;
using TMCatalog.Logic;
using TMCatalog.Model;

namespace TMCatalog.ViewModel.UserControls
{
    public class ClientVM : ViewModelBase
    {
        private const string placeholderText = "Search by name, card number or phone number...";
        private List<Client> clientList;
        private Client selectedClient;
        private string searchText;

        public ClientVM()
        {
            //TODO
        }

        public List<Client> ClientList
        {
            get
            {
                return this.clientList;
            }

            set
            {
                this.clientList = value;
                this.RaisePropertyChanged();
            }
        }

        public Client SelectedClient
        {
            get
            {
                return this.selectedClient;
            }

            set
            {
                this.selectedClient = value;
                this.RaisePropertyChanged();
            }
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

        public void SearchClient()
        {
            if (!String.IsNullOrEmpty(searchText) && !searchText.Equals(placeholderText))
            {
                if (searchText.ElementAt(0).Equals("0"))
                {
                    this.ClientList = Data.Catalog.SearchClientByPhoneNumber(searchText);
                }

                if (int.TryParse(searchText, out int cardNumber))
                {
                    Data.Catalog.SearchClientByCardNumber(cardNumber);
                }
                else
                {
                    Data.Catalog.SearchClientByName(searchText.Trim());
                }
            }
        }
    }
}
