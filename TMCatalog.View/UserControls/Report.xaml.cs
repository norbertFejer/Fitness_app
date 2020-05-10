using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMCatalog.Logic;
using TMCatalog.ViewModel;
using TMCatalog.ViewModel.UserControls;

namespace TMCatalog.View.UserControls
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : UserControl
    {
        ReportVM reportVM;
        private List<CheckBox> ticketStatusCheckBoxes;
        private List<CheckBox> ticketTypeCheckBoxes;
        private List<CheckBox> entranceLeftNumCheckBoxes;
        private DatePicker validTicketFrom;
        private List<CheckBox> clientNamesCheckBoxes;
        private List<string> checkedTicketStatuses;
        private List<string> checkedTicketTypes;
        private List<int> checkedTicketEntranceLeftNum;
        public Report()
        {
            InitializeComponent();
            reportVM = MainWindowViewModel.Instance.ReportVM;
        }

        private void createTicketFilters()
        {
            /// filter 1
            FilterGrid.Children.Clear();
            TextBox ticketStatus = new TextBox();
            Grid.SetColumn(ticketStatus, 0);
            Grid.SetRow(ticketStatus, 0);
            FilterGrid.Children.Add(ticketStatus);

            ListView activeTickets = new ListView();
            Grid.SetColumn(activeTickets, 0);
            Grid.SetRow(activeTickets, 1);

            ticketStatusCheckBoxes = new List<CheckBox>();
            List<string> tStatusTypes = new List<string>(new string[] { "Active", "Inactive"});
            foreach (string cardNum in tStatusTypes)
            {
                CheckBox tmp = new CheckBox();
                tmp.Content = cardNum;
                tmp.Checked += ticketFilterCheckBox_Checked;
                tmp.Unchecked += ticketFilterCheckBox_Checked;
                ticketStatusCheckBoxes.Add(tmp);
            }

            activeTickets.ItemsSource = ticketStatusCheckBoxes;
            FilterGrid.Children.Add(activeTickets);

            /// filter 2

            TextBox ticketType = new TextBox();
            Grid.SetColumn(ticketType, 1);
            Grid.SetRow(ticketType, 0);
            FilterGrid.Children.Add(ticketType);

            ListView ticketTypes = new ListView();
            Grid.SetColumn(ticketTypes, 1);
            Grid.SetRow(ticketTypes, 1);

            ticketTypeCheckBoxes = new List<CheckBox>();
            var tmpTicketTypes = Data.Catalog.GetTicketTypes();
            foreach (string tType in tmpTicketTypes)
            {
                CheckBox tmp = new CheckBox();
                tmp.Content = tType;
                tmp.Checked += ticketFilterCheckBox_Checked;
                tmp.Unchecked += ticketFilterCheckBox_Checked;
                ticketTypeCheckBoxes.Add(tmp);
            }

            ticketTypes.ItemsSource = ticketTypeCheckBoxes;
            FilterGrid.Children.Add(ticketTypes);

            /// filter 3

            TextBox validUntil = new TextBox();
            Grid.SetColumn(validUntil, 2);
            Grid.SetRow(validUntil, 0);
            FilterGrid.Children.Add(validUntil);

            ListView validityNum = new ListView();
            Grid.SetColumn(validityNum, 2);
            Grid.SetRow(validityNum, 1);

            entranceLeftNumCheckBoxes = new List<CheckBox>();
            List<int> validityNumLists = new List<int>(new int[] { 1, 2, 5, 10, 15 });
            foreach (int vNum in validityNumLists)
            {
                CheckBox tmp = new CheckBox();
                tmp.Content = vNum.ToString();
                tmp.Checked += ticketFilterCheckBox_Checked;
                tmp.Unchecked += ticketFilterCheckBox_Checked;
                entranceLeftNumCheckBoxes.Add(tmp);
            }

            validityNum.ItemsSource = entranceLeftNumCheckBoxes;
            FilterGrid.Children.Add(validityNum);

            /// filter 4

            validTicketFrom = new DatePicker();
            validTicketFrom.SelectedDate = DateTime.Today.AddDays(-30);
            validTicketFrom.SelectedDateChanged += ticketFilterCheckBox_Checked;
            Grid.SetColumn(validTicketFrom, 3);
            Grid.SetRow(validTicketFrom, 1);
            FilterGrid.Children.Add(validTicketFrom);
        }

        private void createEntranceFilters()
        {
            /// filter 1
            /// 
            FilterGrid.Children.Clear();
            TextBox clientName = new TextBox();
            Grid.SetColumn(clientName, 0);
            Grid.SetRow(clientName, 0);
            FilterGrid.Children.Add(clientName);

            ListView clientNames = new ListView();
            Grid.SetColumn(clientNames, 0);
            Grid.SetRow(clientNames, 1);

            List<CheckBox> chkBoxes = new List<CheckBox>();
            var tmpClientNames = Data.Catalog.GetAllClientName();
            foreach (string client in tmpClientNames)
            {
                CheckBox tmp = new CheckBox();
                tmp.Content = client;
                chkBoxes.Add(tmp);
            }

            clientNames.ItemsSource = chkBoxes;
            FilterGrid.Children.Add(clientNames);

            /// filter 2

            TextBox cardNumber = new TextBox();
            Grid.SetColumn(cardNumber, 1);
            Grid.SetRow(cardNumber, 0);
            FilterGrid.Children.Add(cardNumber);

            ListView cardNumbers = new ListView();
            Grid.SetColumn(cardNumbers, 1);
            Grid.SetRow(cardNumbers, 1);

            chkBoxes = new List<CheckBox>();
            var tmpCardNumbers = Data.Catalog.GetCardNumbers();
            foreach (int cardNum in tmpCardNumbers)
            {
                CheckBox tmp = new CheckBox();
                tmp.Content = cardNum.ToString();
                chkBoxes.Add(tmp);
            }

            cardNumbers.ItemsSource = chkBoxes;
            FilterGrid.Children.Add(cardNumbers);

            /// filter 3

            TextBox ticketType = new TextBox();
            Grid.SetColumn(ticketType, 2);
            Grid.SetRow(ticketType, 0);
            FilterGrid.Children.Add(ticketType);

            ListView ticketTypes = new ListView();
            Grid.SetColumn(ticketTypes, 2);
            Grid.SetRow(ticketTypes, 1);

            chkBoxes = new List<CheckBox>();
            var tmpTicketTypes = Data.Catalog.GetTicketTypes();
            foreach (string tType in tmpTicketTypes)
            {
                CheckBox tmp = new CheckBox();
                tmp.Content = tType;
                chkBoxes.Add(tmp);
            }

            ticketTypes.ItemsSource = chkBoxes;
            FilterGrid.Children.Add(ticketTypes);

            /// filter 4

            DatePicker startDate = new DatePicker();
            Grid.SetColumn(startDate, 3);
            Grid.SetRow(startDate, 0);
            FilterGrid.Children.Add(startDate);

            DatePicker endDate = new DatePicker();
            Grid.SetColumn(endDate, 3);
            Grid.SetRow(endDate, 1);
            FilterGrid.Children.Add(endDate);
        }

        private void createClientFilters()
        {
            /*FilterGrid.Children.Clear();
            TextBox clientName = new TextBox();
            Grid.SetColumn(clientName, 0);
            Grid.SetRow(clientName, 0);
            FilterGrid.Children.Add(clientName);*/

            CheckBox selectAllName = new CheckBox();
            selectAllName.Content = "Select all";
            selectAllName.Checked += selectAllClientName_Checked;
            selectAllName.Unchecked += selectAllClientName_Checked;
            Grid.SetColumn(selectAllName, 0);
            Grid.SetRow(selectAllName, 0);
            FilterGrid.Children.Add(selectAllName);

            ListView clientNames = new ListView();
            Grid.SetColumn(clientNames, 0);
            Grid.SetRow(clientNames, 2);

            clientNamesCheckBoxes = new List<CheckBox>();
            var clients = Data.Catalog.GetAllClientName();

            foreach (string client in clients)
            {
                CheckBox tmp = new CheckBox();
                tmp.Content = client;
                tmp.Checked += clientCheckBox_Checked;
                tmp.Unchecked += clientCheckBox_Checked;
                clientNamesCheckBoxes.Add(tmp);
            }

            clientNames.ItemsSource = clientNamesCheckBoxes;
            FilterGrid.Children.Add(clientNames);
            selectAllName.IsChecked = true;
        }

        private void ReportTypeComboBox_SelectionChanged(object sender, EventArgs e)
        {
            if (ReportTypeComboBox.SelectedIndex > -1)
            {
                this.reportVM.DeleteMainDataContainer();
                FilterGrid.Children.Clear();

                switch (ReportTypeComboBox.SelectedIndex)
                {
                    case 0:
                        createClientFilters();
                        break;
                    case 1:
                        createTicketFilters();
                        this.reportVM.InitializeMainDataContainerWithTickets();
                        break;
                    case 2:
                        createEntranceFilters();
                        break;

                }
            }
        }

        private void ExportData_Click(object sender, RoutedEventArgs e)
        {

            if ( MainDataGrid.Items.Count == 0)
            {
                MessageBox.Show("No data selected!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            SaveFileDialog sf = new SaveFileDialog();
            sf.FileName = "reports.xls";
            sf.DefaultExt = "xls";
            bool ret = (bool)sf.ShowDialog();

            if (!ret)
            {
                return;
            }

            string filePath = sf.FileName;

            if (!string.IsNullOrEmpty(filePath))
            {
                ExportToExcel(filePath);
            }
        }

        private void ExportToExcel(string filePath)
        {
            MainDataGrid.SelectAllCells();
            MainDataGrid.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, MainDataGrid);
            String resultat = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            String result = (string)Clipboard.GetData(DataFormats.Text);
            MainDataGrid.UnselectAllCells();
            System.IO.StreamWriter file = new System.IO.StreamWriter(filePath);
            file.WriteLine(result.Replace(',', ' '));
            file.Close();

            MessageBox.Show("Exporting DataGrid data to Excel file created", "Fitness App", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void clientCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            bool value = (sender as CheckBox).IsChecked ?? false;
            if (value)
            {
                reportVM.AddNewClientToMainContainerByName((string)(sender as CheckBox).Content);
            }
            else
            {
                reportVM.RemoveClientFromMainContainerByName((string)(sender as CheckBox).Content);
            }
        }

        private bool isAnyClientNameSelected()
        {
            foreach(CheckBox clientNameCheckBox in clientNamesCheckBoxes)
            {
                if (clientNameCheckBox.IsChecked == true)
                {
                    return true;
                }
            }

            return false;
        }

        private void selectAllClientName_Checked(object sender, RoutedEventArgs e)
        {
            foreach (CheckBox clientNameChkBox in clientNamesCheckBoxes)
            {
                bool value = (sender as CheckBox).IsChecked ?? false;
                clientNameChkBox.IsChecked = value;
            }
        }

        private void ticketFilterCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            FilterTicketList();
        }


        private void GetCheckedTicketStatuses()
        {
            checkedTicketStatuses = new List<string>();
            foreach (CheckBox chkBox in ticketStatusCheckBoxes)
            {
                bool value = chkBox.IsChecked ?? false;
                if (value)
                {
                    checkedTicketStatuses.Add((string)chkBox.Content);
                }
            }
        }

        private void GetCheckedTicketTypes()
        {
            checkedTicketTypes = new List<string>();
            foreach (CheckBox chkBox in ticketTypeCheckBoxes)
            {
                bool value = chkBox.IsChecked ?? false;
                if (value)
                {
                    checkedTicketTypes.Add((string)chkBox.Content);
                }
            }
        }

        private void GetCheckedTicketEntranceLeftNum()
        {
            checkedTicketEntranceLeftNum = new List<int>();
            foreach (CheckBox chkBox in entranceLeftNumCheckBoxes)
            {
                bool value = chkBox.IsChecked ?? false;
                if (value)
                {
                    checkedTicketEntranceLeftNum.Add(int.Parse((string)chkBox.Content));
                }
            }
        }

        private void FilterTicketList()
        {
            GetCheckedTicketStatuses();
            GetCheckedTicketTypes();
            GetCheckedTicketEntranceLeftNum();

            reportVM.FilterMainDataContainerByTicketParams(checkedTicketStatuses, checkedTicketTypes, checkedTicketEntranceLeftNum, validTicketFrom.DisplayDate);
        }
    }
}
