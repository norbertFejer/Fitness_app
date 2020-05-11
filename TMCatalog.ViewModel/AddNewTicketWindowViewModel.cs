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
    public class AddNewTicketWindowViewModel : ViewModelBase
    {
        public static AddNewTicketWindowViewModel Instance { get; private set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        private bool hasMaxEntrance;
        private bool hasValidityNumber;
        private short maxEntrance;
        private short validityNumber;
        private string type;
        private string comment;
        private float price;
        private string errorMessage;

        public AddNewTicketWindowViewModel()
        {
            Instance = this;
            this.CancelCommand = new RelayCommand(this.CancelCommandExecute);
            this.OkCommand = new RelayCommand(this.OkCommandExecute);
        }

        public bool HasMaxEntrance
        {
            get
            {
                return this.hasMaxEntrance;
            }

            set
            {
                this.hasMaxEntrance = value;
                this.RaisePropertyChanged();
            }
        }

        public bool HasValidityNumber
        {
            get
            {
                return this.hasValidityNumber;
            }

            set
            {
                this.hasValidityNumber = value;
                this.RaisePropertyChanged();
            }
        }



        public short MaxEntrance
        {
            get
            {
                return this.maxEntrance;
            }

            set
            {
                this.maxEntrance = value;
                this.RaisePropertyChanged();
            }
        }

        public short ValidityNumber
        {
            get
            {
                return this.validityNumber;
            }

            set
            {
                this.validityNumber = value;
                this.RaisePropertyChanged();
            }
        }

        public string Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
                this.RaisePropertyChanged();
            }
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }

            set
            {
                this.comment = value;
                this.RaisePropertyChanged();
            }
        }

        public float Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
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
            if (this.HasMaxEntrance == false && this.HasValidityNumber == false)
            {
                return false;
            }

            if (this.HasMaxEntrance == true && this.MaxEntrance <= 0)
            {
                return false;
            }

            if (this.HasValidityNumber == true && this.ValidityNumber <= 0)
            {
                return false;
            }

            if (this.Type == null || this.Price <= 0F)
            {
                return false;
            }

            return true;
        }

        private void OkCommandExecute()
        {
            if (OkCommandCanExecute())
            {
                this.ErrorMessage = "";
                if (MessageBox.Show("Are you sure to add this ticket?", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Ticket ticket = new Ticket();

                    ticket.Active = true;
                    ticket.Comment = this.Comment;
                    ticket.Discount = 0F;
                    ticket.DiscountFrom = DateTime.Now;
                    ticket.DiscountUntil = DateTime.Now;
                    ticket.MaxEntrance = this.HasMaxEntrance == true ? this.MaxEntrance : (short)-1;
                    ticket.Price = this.Price;
                    ticket.Type = this.Type;
                    ticket.ValidityNumber = this.HasValidityNumber == true ? this.ValidityNumber : (short)-1;

                    if (Data.Catalog.AddTicket(ticket) == 1)
                    {
                        MessageBox.Show("Ticket added!", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainWindowViewModel.Instance.TicketVM.SearchTicket();
                        ViewService.CloseDialog(this);
                    }
                    else
                    {
                        MessageBox.Show("Error while adding ticket!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
