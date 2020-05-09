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
            this.VehicleSearchVM = new VehicleSearchVM();
            this.selectedTabIndex = 0;
            this.ArticleVM = new ArticleVM();
            this.ShoppingBasketVM = new ShoppingBasketVM();
            this.ClientVM = new ClientVM();
            this.ClientMembershipVM = new ClientMembershipVM();
        }

        public VehicleSearchVM VehicleSearchVM { get; }

        public ShoppingBasketVM ShoppingBasketVM { get; }

        public RelayCommand CloseCommand { get; set; }

        public ArticleVM ArticleVM { get;  }

        public ClientVM ClientVM { get; }

        public ClientMembershipVM ClientMembershipVM { get; }

        public void CloseCommandExecute()
        {
          ViewService.CloseDialog(this);
        }

        public void SetAndOpenArticle(VehicleType selectedVehicle)
        {
            this.SelectedTabIndex = 1;
            this.ArticleVM.VehicleType = selectedVehicle;
        }

        public ArticleVM ArticleVM { get;  }

        public void SetAndOpenMembership(string name)
        {
            this.SelectedTabIndex = 4;
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

        public void AddStockWithArticleToBasket(Stock stock)
        {
            this.ShoppingBasketVM.AddStockWithArticleToBasket(stock);
        }

    }
}
