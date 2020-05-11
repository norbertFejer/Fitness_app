using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCatalog.Common.MVVM;
using TMCatalog.Logic;
using TMCatalog.Model;

namespace TMCatalog.ViewModel.UserControls
{
    public class TicketVM : ViewModelBase
    {
        private string placeholderText = "Search by ticket type";
        private string searchText;
        private List<Ticket> ticketList;
        private Ticket selectedTicket;
        public RelayCommand DeleteTicketCommand { get; private set; }
        private bool hasSelectedTicket;

        public TicketVM()
        {
            this.SearchText = this.PlaceholderText;
            this.DeleteTicketCommand = new RelayCommand(this.DeleteTicketCommandExecute, this.DeleteTicketCommandCanExecute);
        }

        public string PlaceholderText
        {
            get
            {
                return this.placeholderText;
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

        public List<Ticket> TicketList
        {
            get
            {
                return this.ticketList;
            }

            set
            {
                this.ticketList = value;
                this.RaisePropertyChanged();
            }
        }

        public Ticket SelectedTicket
        {
            get
            {
                return this.selectedTicket;
            }

            set
            {
                this.selectedTicket = value;
                this.RaisePropertyChanged();
            }
        }

        public bool HasSelectedTicket
        {
            get
            {
                return this.hasSelectedTicket;
            }

            set
            {
                this.hasSelectedTicket = value;
                this.RaisePropertyChanged();
            }
        }

        public void SearchTicket()
        {
            if (String.IsNullOrEmpty(SearchText.Trim()) || SearchText.Equals(PlaceholderText))
            {
                this.TicketList = Data.Catalog.GetTickets();
            }
            else
            {
                this.TicketList = Data.Catalog.SearchTicketByType(SearchText.Trim());
            }
        }

        private void DeleteTicketCommandExecute()
        {
            if (this.SelectedTicket.Active == false)
            {
                MessageBox.Show("Ticket datasheet is closed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure to delete?", "Comfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Data.Catalog.RemoveTicket(this.SelectedTicket.Id) == 1)
                    {
                        MessageBox.Show("Changes saved successfully", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error while applying changes", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            SearchTicket();
        }

        private bool DeleteTicketCommandCanExecute()
        {
            if (this.SelectedTicket != null)
            {
                this.HasSelectedTicket = this.SelectedTicket.Active;
            }
            else
            {
                this.HasSelectedTicket = false;
            }
            return this.SelectedTicket != null;
        }
    }
}
