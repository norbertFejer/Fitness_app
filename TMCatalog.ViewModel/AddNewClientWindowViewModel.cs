using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMCatalog.Common.MVVM;
using TMCatalog.Logic;
using TMCatalog.Model;

namespace TMCatalog.ViewModel
{
    public class AddNewClientWindowViewModel : ViewModelBase
    {
        public static AddNewClientWindowViewModel Instance { get; private set; }
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand ChoosePhotoCommand { get; set; }
        public RelayCommand AddClientCommand { get; set; }
        private OpenFileDialog openFileDialog;

        private int cardNumber;
        private string cnp;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string email;
        private int gender;
        private DateTime birthDate;
        private byte[] photo;
        private string comment;
        private string errorMessage;

        public AddNewClientWindowViewModel()
        {
            Instance = this;
            this.CardNumber = 0;
            this.BirthDate = DateTime.Now;
            this.CloseCommand = new RelayCommand(this.CloseCommandExecute);
            this.ChoosePhotoCommand = new RelayCommand(this.ChoosePhotoCommandExecute);
            this.AddClientCommand = new RelayCommand(this.AddClientCommandExecute);
        }

        public int CardNumber
        {
            get
            {
                return this.cardNumber;
            }

            set
            {
                this.cardNumber = value;
                this.RaisePropertyChanged();
            }
        }

        public string Cnp
        {
            get
            {
                return this.cnp;
            }

            set
            {
                this.cnp = value;
                this.RaisePropertyChanged();
            }
        }
        
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
                this.RaisePropertyChanged();
            }
        }
        
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
                this.RaisePropertyChanged();
            }
        }
        
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                this.phoneNumber = value;
                this.RaisePropertyChanged();
            }
        }
        
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
                this.RaisePropertyChanged();
            }
        }
        
        public int Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
                this.RaisePropertyChanged();
            }
        }
        
        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }

            set
            {
                this.birthDate = value;
                this.RaisePropertyChanged();
            }
        }

        public byte[] Photo
        {
            get
            {
                return this.photo;
            }

            set
            {
                this.photo = value;
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

        private void CloseCommandExecute()
        {
            ViewService.CloseDialog(this);
        }

        private void ChoosePhotoCommandExecute()
        {
            this.openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"\\Pictures\";
            openFileDialog.Title = "Choose Profile Picture";
            openFileDialog.DefaultExt = "png";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.PNG)| *.BMP; *.JPG; *.PNG";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.Photo = BitMapToByteArray(new Bitmap(openFileDialog.FileName));
            }
        }

        private void AddClientCommandExecute()
        {
            if (AddClientCommandCanExecute())
            {
                this.ErrorMessage = "";
                if (MessageBox.Show("Are you sure to add this client?", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Client client = new Client
                    {
                        Id = Data.Catalog.GetMaxId() + 1,
                        CardNumber = this.CardNumber,
                        Cnp = this.Cnp,
                        FirstName = this.FirstName,
                        LastName = this.LastName,
                        PhoneNumber = this.PhoneNumber,
                        Email = this.Email,
                        Gender = this.Gender,
                        BirthDate = this.BirthDate,
                        RegisteredDate = DateTime.Now,
                        Photo = this.Photo,
                        Comment = this.Comment,
                        Active = true
                    };

                    if (Data.Catalog.AddClient(client) == 1)
                    {
                        MessageBox.Show("Client added successfully", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainWindowViewModel.Instance.ClientVM.SearchClient();
                        ViewService.CloseDialog(this);
                    }
                    else
                    {
                        MessageBox.Show("Error while adding new client", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                this.ErrorMessage = "There are invalid or empty fields!";
            }
        }

        private bool AddClientCommandCanExecute()
        {
            /*return this.Cnp != null &&
                this.FirstName != null &&
                this.LastName != null &&
                this.CardNumber != 0 &&
                !Data.Catalog.CardNumberExists(this.CardNumber) &&
                this.PhoneNumber != null &&
                this.Email != null &&
                this.BirthDate != null &&
                this.Photo != null &&
                this.BirthDate.Date < DateTime.Now.Date;*/
            return !String.IsNullOrEmpty(this.Cnp.Trim()) &&
                !String.IsNullOrEmpty(this.FirstName.Trim()) &&
                !String.IsNullOrEmpty(this.LastName.Trim()) &&
                !String.IsNullOrEmpty(this.PhoneNumber.Trim()) &&
                !String.IsNullOrEmpty(this.Email.Trim()) &&
                this.BirthDate != null &&
                this.Photo != null &&
                this.BirthDate.Date < DateTime.Now.Date &&
                this.CardNumber != 0 &&
                !Data.Catalog.CardNumberExists(this.CardNumber);
        }

        private byte[] BitMapToByteArray(Bitmap bitmap)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
        }
    }
}
