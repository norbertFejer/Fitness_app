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
    public class AddDiscountWindowViewModel : ViewModelBase
    {
        public static AddDiscountWindowViewModel Instance { get; private set; }
        private Ticket ticket;
        public RelayCommand OkCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        float discount;
        DateTime beginDate;
        DateTime endDate;
        private string errorMessage;

        public AddDiscountWindowViewModel(Ticket selectedTicket)
        {
            Instance = this;
            this.Ticket = selectedTicket;
            //this.Discount = 0F;
            //this.BeginDate = DateTime.Now;
            //this.EndDate = DateTime.Now.AddDays(1D);
            this.CancelCommand = new RelayCommand(this.CancelCommandExecute);
            this.OkCommand = new RelayCommand(this.OkCommandExecute);
        }

        public Ticket Ticket
        {
            get
            {
                return this.ticket;
            }

            set
            {
                this.ticket = value;
                this.RaisePropertyChanged();
            }
        }

        public float Discount
        {
            get
            {
                return this.discount;
            }

            set
            {
                this.discount = value;
                this.RaisePropertyChanged();
            }
        }

        public DateTime BeginDate
        {
            get
            {
                return this.beginDate;
            }

            set
            {
                this.beginDate = value;
                this.RaisePropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }

            set
            {
                this.endDate = value;
                this.RaisePropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }

            set
            {
                this.errorMessage = value;
                this.RaisePropertyChanged();
            }
        }

        private void CancelCommandExecute()
        {
            ViewService.CloseDialog(this);
        }

        private bool OkCommandCanExecute()
        {
            return this.Discount >= 0F && this.BeginDate.Date >= DateTime.Now.Date && this.EndDate.Date >= this.BeginDate.Date;
        }

        private void OkCommandExecute()
        {
            if (OkCommandCanExecute())
            {
                this.ErrorMessage = "";
                if (MessageBox.Show("Are you sure to add this discount?", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Data.Catalog.AddDiscount(this.Ticket.Id, this.Discount, this.BeginDate, this.EndDate) == 1)
                    {
                        MessageBox.Show("Discount added!", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainWindowViewModel.Instance.TicketVM.SearchTicket();
                        ViewService.CloseDialog(this);
                    }
                    else
                    {
                        MessageBox.Show("Error while adding discount!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                this.ErrorMessage = "There are invalid or empty fields!";
            }
        }
    }
}
