// ------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Szilveszter Gorgicze</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalog.View
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows;
    using TMCatalog.Common.MVVM;
    using TMCatalog.Logic;
    using TMCatalog.Model;
    using TMCatalog.ViewModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window, INotifyPropertyChanged
    {
        private User currentUser;
        private string errorMessage;
        MainWindow mainWindow;

        public event PropertyChangedEventHandler PropertyChanged;

        public LoginWindow()
        {
            InitializeComponent();
            this.Closed += LoginWindow_Closed;
            mainWindow = null;
        }

        private void LoginWindow_Closed(object sender, EventArgs e)
        {
            if (mainWindow == null)
            {
                Application.Current.Shutdown();
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //string userName = UsernameBox.Text;
            //string plainPassword = PasswordBox.Password.ToString();

            //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(plainPassword))
            //{
            //    this.ErrorMessage = "Username or password is empty!";
            //}

            string userName = "admin1";
            string plainPassword = "admin";

            string hashedPassword = GetPasswordHash(plainPassword);
            this.CurrentUser = Data.Catalog.GetUserByUsernameAndPassword(userName, hashedPassword);

            if (CurrentUser == null)
            {
                this.ErrorMessage = "Invalid username or password!";
            }
            else
            {
                Application.Current.Properties["Name"] = currentUser.FirstName + " " + currentUser.LastName;
                Application.Current.Properties["Type"] = currentUser.Type;

                OpenMainWindow();
            }
        }

        private string GetPasswordHash(string plainPassword)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, plainPassword);
                return hash;
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private void OpenMainWindow()
        {    
            mainWindow = new MainWindow();

            ViewService.CloseDialog((LoginWindowViewModel)this.DataContext);

            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(currentUser.FirstName + " " + currentUser.LastName, currentUser.Type);

            ViewService.AddMainWindowToOpened(mainWindowViewModel, mainWindow);
            ViewService.ShowDialog(mainWindowViewModel);
        }

        public User CurrentUser
        {
            get
            {
                return currentUser;
            }

            set
            {
                this.currentUser = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }

            set
            {
                this.errorMessage = value;
                ErrorLabel.Content = ErrorMessage;
                UsernameBox.Clear();
                PasswordBox.Clear();
                this.RaisePropertyChanged();
            }
        }

        public void RaisePropertyChanged([CallerMemberName]string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
