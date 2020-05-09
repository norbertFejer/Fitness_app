using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCatalog.Common.MVVM;
using TMCatalog.Model;

namespace TMCatalog.ViewModel.UserControls
{
    public class ClientVM : ViewModelBase
    {
        private List<Client> clientList;
        private Client selectedClient;

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
    }
}
