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
    public class ClientMembershipVM : ViewModelBase
    {
        private string placeholderText = "Search by name or card number...";
        private List<ClientMembership> clientMembershipList;
        private string searchText;
        private bool listInactiveMemberships;

        public ClientMembershipVM()
        {
            this.SearchText = this.PlaceholderText;
            this.ListInactiveMemberships = false;
        }

        public string PlaceholderText
        {
            get
            {
                return this.placeholderText;
            }
        }

        public List<ClientMembership> ClientMembershipList
        {
            get
            {
                return this.clientMembershipList;
            }

            set
            {
                this.clientMembershipList = value;
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

        public bool ListInactiveMemberships
        {
            get
            {
                return this.listInactiveMemberships;
            }

            set
            {
                this.listInactiveMemberships = value;
                this.RaisePropertyChanged();
                this.SearchClientMembership();
            }
        }

        public void SearchClientMembership()
        {
            if (String.IsNullOrEmpty(SearchText.Trim()) || SearchText.Equals(PlaceholderText))
            {
                this.ClientMembershipList = Data.Catalog.GetAllClientMemberships(ListInactiveMemberships);
            }
            else
            {
                if (int.TryParse(SearchText, out int cardNumber))
                {
                    this.ClientMembershipList = Data.Catalog.SearchClientMembershipByCardNumber(cardNumber, ListInactiveMemberships);
                }
                else
                {
                    this.ClientMembershipList = Data.Catalog.SearchClientMembershipByName(SearchText.Trim(), ListInactiveMemberships);
                }
            }
        }
    }
}
