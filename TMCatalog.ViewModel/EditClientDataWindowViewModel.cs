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
    public class EditClientDataWindowViewModel : ViewModelBase
    {
        public static EditClientDataWindowViewModel Instance { get; private set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand ChoosePhotoCommand { get; set; }
        public RelayCommand EditClientCommand { get; set; }
        public RelayCommand DeleteClientCommand { get; set; }
        private OpenFileDialog openFileDialog;

        private Client client;
        private bool editEnabled;
        private bool readOnly;
        private string errorMessage;

        public EditClientDataWindowViewModel(Client client)
        {
            Instance = this;
            this.Client = client;
            this.editEnabled = false;
            this.ReadOnly = true;
            this.OkCommand = new RelayCommand(this.OkCommandExecute);
            this.ChoosePhotoCommand = new RelayCommand(this.ChoosePhotoCommandExecute);
            this.EditClientCommand = new RelayCommand(this.EditClientCommandExecute);
            this.DeleteClientCommand = new RelayCommand(this.DeleteClientCommandExecute);
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

        public bool EditEnabled
        {
            get
            {
                return this.editEnabled;
            }

            private set
            {
                this.editEnabled = value;
                this.RaisePropertyChanged();
            }
        }

        public bool ReadOnly
        {
            get
            {
                return this.readOnly;
            }

            private set
            {
                this.readOnly = value;
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

        private void OkCommandExecute()
        {
            if (this.Client.Active == false || this.ReadOnly == true)
            {
                ViewService.CloseDialog(this);
            }
            else
            {
                if (OkCommandCanExecute())
                {
                    this.ErrorMessage = "";
                    if (MessageBox.Show("Are you sure to continue?", "Comfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Data.Catalog.EditClient(client) == 1)
                        {
                            MessageBox.Show("Changes saved successfully", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainWindowViewModel.Instance.ClientMembershipVM.SearchClientMembership();
                            ViewService.CloseDialog(this);
                        }
                        else
                        {
                            MessageBox.Show("Error while applying changes", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    this.ErrorMessage = "There are invalid or empty fields!";
                }
            }
        }

        private bool OkCommandCanExecute()
        {
            /*return this.Client.Cnp != null &&
                this.Client.FirstName != null &&
                this.Client.LastName != null &&
                this.Client.CardNumber != 0 &&
                this.Client.PhoneNumber != null &&
                this.Client.Email != null &&
                this.Client.BirthDate != null &&
                this.Client.Photo != null;*/

            return !String.IsNullOrEmpty(this.Client.Cnp.Trim()) &&
                !String.IsNullOrEmpty(this.Client.FirstName.Trim()) &&
                !String.IsNullOrEmpty(this.Client.LastName.Trim()) &&
                !String.IsNullOrEmpty(this.Client.PhoneNumber.Trim()) &&
                !String.IsNullOrEmpty(this.Client.Email.Trim()) &&
                this.Client.BirthDate != null &&
                this.Client.Photo != null &&
                this.Client.BirthDate.Date < DateTime.Now.Date &&
                this.Client.CardNumber != 0;
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
                this.Client.Photo = BitMapToByteArray(new Bitmap(openFileDialog.FileName));
            }
        }

        private void EditClientCommandExecute()
        {
            if (this.Client.Active == false)
            {
                MessageBox.Show("Client datasheet is closed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.EditEnabled = true;
                this.ReadOnly = false;
            }
        }

        private void DeleteClientCommandExecute()
        {
            if (this.Client.Active == false)
            {
                MessageBox.Show("Client datasheet is closed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure to delete?", "Comfirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (Data.Catalog.RemoveClient(this.Client.Id) == 1)
                    {
                        MessageBox.Show("Changes saved successfully", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ViewService.CloseDialog(this);
                    }
                    else
                    {
                        MessageBox.Show("Error while applying changes", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool EditClientCommandCanExecute()
        {
            return this.ReadOnly;
        }

        private byte[] BitMapToByteArray(Bitmap bitmap)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
        }
    }
}
