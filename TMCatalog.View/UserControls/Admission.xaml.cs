using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMCatalog.ViewModel;
using TMCatalog.ViewModel.UserControls;

namespace TMCatalog.View.UserControls
{
    /// <summary>
    /// Interaction logic for Admission.xaml
    /// </summary>
    public partial class Admission : UserControl
    {

        AdmissionVM admissionVM;
        public Admission()
        {
            InitializeComponent();
            admissionVM = MainWindowViewModel.Instance.AdmissionVM;
        }

        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            if (admissionVM.SearchText.Equals(admissionVM.PlaceholderText))
            {
                admissionVM.SearchText = "";
                admissionVM.SearchClientTickets();
            }
        }

        private void SetPlaceholderText(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(admissionVM.SearchText.Trim()))
            {
                admissionVM.SearchText = admissionVM.PlaceholderText;
                admissionVM.SearchClientTickets();
            }
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            admissionVM.SearchText = ((TextBox)sender).Text;
            admissionVM.SearchClientTickets();
        }

    }
}
