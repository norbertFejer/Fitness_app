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
    using static System.Net.Mime.MediaTypeNames;

    public class MainWindowViewModel : ViewModelBase
    {

        private int selectedTabIndex;
        private string userName;
        private short userType;
        private string adminTabVisibility;
        public static MainWindowViewModel Instance { get; private set; }

        public MainWindowViewModel(string userName, short userType)
        {
            Instance = this;
            this.UserName = userName;
            this.UserType = userType;

            this.CloseCommand = new RelayCommand(this.CloseCommandExecute);
            this.selectedTabIndex = 0;

            this.AdmissionVM = new AdmissionVM();
            this.ClientVM = new ClientVM();
            this.ClientMembershipVM = new ClientMembershipVM();

            if (UserType == 1)
            {
                this.ReportVM = new ReportVM();
                this.TicketVM = new TicketVM();
            }
            else
            {
                AdminTabVisibility = "Hidden";
            }
        }

        public RelayCommand CloseCommand { get; set; }

        public RelayCommand LogOutCommand { get; set; }

        public ClientVM ClientVM { get; }

        public AdmissionVM AdmissionVM { get; }

        public ReportVM ReportVM { get; }

        public ClientMembershipVM ClientMembershipVM { get; }

        public TicketVM TicketVM { get; }

        public void CloseCommandExecute()
        {
            ViewService.CloseDialog(this);
        }

        public void SetAndOpenMembership(string name)
        {
            this.SelectedTabIndex = 2;
            this.ClientMembershipVM.SearchText = name;
        }

        public void SetAndOpenClients(string cardNum)
        {
            this.SelectedTabIndex = 1;
            this.ClientVM.SearchText = cardNum;
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

        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                this.userName = value;
                this.RaisePropertyChanged();
            }
        }
        public short UserType
        {
            get
            {
                return this.userType;
            }

            set
            {
                this.userType = value;
                this.RaisePropertyChanged();
            }
        }

        public string AdminTabVisibility
        {
            get
            {
                return this.adminTabVisibility;
            }

            set
            {
                this.adminTabVisibility = value;
                this.RaisePropertyChanged();
            }
        }

    }
}
