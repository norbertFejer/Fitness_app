// ------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Szilveszter Gorgicze</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalog.ViewModel
{
    using System.Windows;
    using TMCatalog.Common.MVVM;
    using TMCatalog.ViewModel.UserControls;
    using TMCatalogClient.Model;

    public class LoginWindowViewModel : ViewModelBase
    {

        public static LoginWindowViewModel Instance { get; private set; }

        public LoginWindowViewModel()
        {
            Instance = this;
            this.CloseCommand = new RelayCommand(this.CloseCommandExecute);
        }

        public RelayCommand CloseCommand { get; set; }

        public void CloseCommandExecute()
        {
            ViewService.CloseDialog(this);
        }

    }
}
