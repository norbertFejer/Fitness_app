// ------------------------------------------------------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Szilveszter Gorgicze</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalog
{
    using System;
    using System.Windows;
    using TMCatalog.Common.MVVM;
    using TMCatalog.Model.DBContext;
    using TMCatalog.View;
    using TMCatalog.ViewModel;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.Initialize();
            this.InitializeData();
            this.OpenLoginWindow();
        }
        private void Initialize()
        {
            ViewService.RegisterView(typeof(MainWindowViewModel), typeof(MainWindow));
            ViewService.RegisterView(typeof(LoginWindowViewModel), typeof(LoginWindow));
        }

        private void OpenLoginWindow()
        {
            LoginWindow loginWindow = new LoginWindow();
            LoginWindowViewModel loginWindowViewModel = new LoginWindowViewModel();

            ViewService.AddMainWindowToOpened(loginWindowViewModel, loginWindow);
            ViewService.ShowDialog(loginWindowViewModel);
        }

        private void InitializeData()
        {
            try
            {
                DBInitializer dbinit = new DBInitializer();
                dbinit.InitializeDatabase(new TMCatalogDB());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
