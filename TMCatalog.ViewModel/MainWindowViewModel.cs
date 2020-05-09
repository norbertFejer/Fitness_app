// ------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Szilveszter Gorgicze</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalog.ViewModel
{
    using TMCatalog.Common.MVVM;
    using TMCatalog.ViewModel.UserControls;
    using TMCatalogClient.Model;

    public class MainWindowViewModel : ViewModelBase
    {

        private int selectedTabIndex;
        public static MainWindowViewModel Instance { get; private set; }

        public MainWindowViewModel()
        {
            Instance = this;
            this.CloseCommand = new RelayCommand(this.CloseCommandExecute);
            this.selectedTabIndex = 0;

            this.AdmissionVM = new AdmissionVM();
            this.ClientVM = new ClientVM();
            this.ClientMembershipVM = new ClientMembershipVM();
        }

        public RelayCommand CloseCommand { get; set; }

        public ClientVM ClientVM { get; }

        public AdmissionVM AdmissionVM { get; }

        public ClientMembershipVM ClientMembershipVM { get; }

        public void CloseCommandExecute()
        {
          ViewService.CloseDialog(this);
        }

        public void SetAndOpenMembership(string name)
        {
            this.SelectedTabIndex = 3;
            this.ClientMembershipVM.SearchText = name;
        }

        public int SelectedTabIndex
        {
            get
            {
                return this.selectedTabIndex;
            }

            set
            {
                this.selectedTabIndex = value;
                this.RaisePropertyChanged();
            }
        }

    }
}
