using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCatalog.Common.MVVM;
using TMCatalog.Logic;
using TMCatalog.Model;

namespace TMCatalog.ViewModel
{
    public class SellTicketWindowViewModel : ViewModelBase
    {
        public static SellTicketWindowViewModel Instance { get; private set; }
        private Client client;
        private List<Ticket> tickets;
        private Ticket selectedTicket;
        private DateTime selectedDate;
        public RelayCommand OkCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public SellTicketWindowViewModel(Client client)
        {
            Instance = this;
            this.Client = client;
            this.Tickets = Data.Catalog.GetTickets();
            //this.SelectedTicketId = this.tickets?.FirstOrDefault().Id ?? -1;
            this.CancelCommand = new RelayCommand(this.CancelCommandExecute);
            this.OkCommand = new RelayCommand(this.OkCommandExecute, this.OkCommandCanExecute);
        }

        public Client Client
        {
            get
            {
                return this.client;
            }

            set
            {
                this.client = value;
                this.RaisePropertyChanged();
            }
        }

        public List<Ticket> Tickets
        {
            get
            {
                return this.tickets;
            }

            set
            {
                this.tickets = value;
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

        public DateTime SelectedDate
        {
            get
            {
                return this.selectedDate;
            }

            set
            {
                this.selectedDate = value;
                this.RaisePropertyChanged();
            }
        }

        private void CancelCommandExecute()
        {
            ViewService.CloseDialog(this);
        }

        private bool OkCommandCanExecute()
        {
            return SelectedTicket != null && this.SelectedDate.Date >= DateTime.Now.Date;
        }

        private void OkCommandExecute()
        {
            float price;
            if (this.SelectedTicket.Discount > 0 
                && DateTime.Now.Date >= this.SelectedTicket.DiscountFrom.Date
                && DateTime.Now.Date <= this.SelectedTicket.DiscountUntil.Date)
            {
                price = this.SelectedTicket.Price - this.SelectedTicket.Price * this.SelectedTicket.Discount / 100;
            }
            else
            {
                price = this.SelectedTicket.Price;
            }

            string interrogation = $"Total price: {price}. Continue?";

            if (MessageBox.Show(interrogation, "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClientMembership clientMembership = new ClientMembership();
                clientMembership.Active = true;
                clientMembership.Client = this.Client;
                clientMembership.ClientId = this.Client.Id;
                clientMembership.Comment = "";
                clientMembership.EntranceLeft = this.SelectedTicket.MaxEntrance;
                clientMembership.Price = price;
                clientMembership.SoldOn = DateTime.Now;
                clientMembership.Ticket = this.SelectedTicket;
                clientMembership.TicketId = this.SelectedTicket.Id;
                clientMembership.User = new User();
                clientMembership.UserId = 1;
                clientMembership.ValidAfter = this.SelectedDate;

                if(Data.Catalog.AddClientMembership(clientMembership) == 1)
                    {
                    MessageBox.Show("Ticket sold!", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ViewService.CloseDialog(this);
                }
                    else
                    {
                    MessageBox.Show("Error while selling ticket!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
