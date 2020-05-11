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
        private string placeholderText = "Search by name, card number or phone number...";
        private List<Client> clientList;
        private Client selectedClient;
        private string searchText;
        public RelayCommand OpenClientMembershipTabCommand { get; private set; }
        private bool hasSelectedClient;

        public ClientVM()
        {
            this.SearchText = this.PlaceholderText;
            this.OpenClientMembershipTabCommand = new RelayCommand(this.OpenClientMembershipTabExecute, this.OpenClientMembershipTabCanExecute);
        }

        public string PlaceholderText
        {
            get
            {
                return this.placeholderText;
            }
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

        public bool HasSelectedClient
        {
            get
            {
                return this.hasSelectedClient;
            }

            set
            {
                this.hasSelectedClient = value;
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
            if (String.IsNullOrEmpty(SearchText.Trim()) || SearchText.Equals(PlaceholderText))
            {
                this.ClientList = Data.Catalog.GetAllClients();
            }
            else
            {
                if (SearchText.StartsWith("0"))
                {
                    this.ClientList = Data.Catalog.SearchClientByPhoneNumber(SearchText);
                }
                else
                {
                    if (int.TryParse(SearchText, out int cardNumber))
                    {
                        this.ClientList = Data.Catalog.SearchClientByCardNumber(cardNumber);
                    }
                    else
                    {
                        this.ClientList = Data.Catalog.SearchClientByName(SearchText.Trim());
                    }
                }
            }
        }

        private void OpenClientMembershipTabExecute()
        {
            MainWindowViewModel.Instance.
                SetAndOpenMembership(String.Concat(this.SelectedClient.FirstName, " ", this.SelectedClient.LastName));
        }

        private bool OpenClientMembershipTabCanExecute()
        {
            if (this.SelectedClient != null)
            {
                this.HasSelectedClient = this.SelectedClient.Active;
            }
            else
            {
                this.HasSelectedClient = false;
            }
            return this.SelectedClient != null;
        }
    }
}
