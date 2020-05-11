// ------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="DVSE GmbH">
//   Copyright (c) by DVSE Gesellschaft für Datenverarbeitung, Service und Entwicklung mbH. All rights reserved.
// </copyright>
// <author>Szilveszter Gorgicze</author>
// ------------------------------------------------------------------------------------------------------------------

namespace TMCatalog.View
{
    using System;
    using System.Windows;
    using TMCatalog.Common.MVVM;
    using TMCatalog.ViewModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginWindow loginWindow;
        public MainWindow()
        {
            InitializeComponent();
            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            if (loginWindow == null)
            {
                Application.Current.Shutdown();
            }
        }

        private void LogOutCommandWindowExecute(object obj, RoutedEventArgs e)
        {
            loginWindow = new LoginWindow();
            LoginWindowViewModel loginWindowViewModel = new LoginWindowViewModel();

            this.Close();

            ViewService.AddMainWindowToOpened(loginWindowViewModel, loginWindow);
            ViewService.ShowDialog(loginWindowViewModel);
            this.Close();
        }
    }
}
