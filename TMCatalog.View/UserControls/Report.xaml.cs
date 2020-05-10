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

namespace TMCatalog.View.UserControls
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : UserControl
    {
        public Report()
        {
            InitializeComponent();
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

            List<CheckBox> chkBoxes = new List<CheckBox>();
            List<bool> tStatusTypes = new List<bool>(new bool[] { true, false});
            foreach (bool cardNum in tStatusTypes)
            {
                CheckBox tmp = new CheckBox();
                tmp.Content = cardNum.ToString();
                chkBoxes.Add(tmp);
            }

            activeTickets.ItemsSource = chkBoxes;
            FilterGrid.Children.Add(activeTickets);

            /// filter 2

            TextBox ticketType = new TextBox();
            Grid.SetColumn(ticketType, 1);
            Grid.SetRow(ticketType, 0);
            FilterGrid.Children.Add(ticketType);

            ListView ticketTypes = new ListView();
            Grid.SetColumn(ticketTypes, 1);
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

            /// filter 3

            TextBox validUntil = new TextBox();
            Grid.SetColumn(validUntil, 2);
            Grid.SetRow(validUntil, 0);
            FilterGrid.Children.Add(validUntil);

            ListView validityNum = new ListView();
            Grid.SetColumn(validityNum, 2);
            Grid.SetRow(validityNum, 1);

            chkBoxes = new List<CheckBox>();
            List<int> validityNumLists = new List<int>(new int[] { 1, 2, 5, 10, 15 });
            foreach (int vNum in validityNumLists)
            {
                CheckBox tmp = new CheckBox();
                tmp.Content = vNum.ToString();
                chkBoxes.Add(tmp);
            }

            validityNum.ItemsSource = chkBoxes;
            FilterGrid.Children.Add(validityNum);

            /// filter 4

            DatePicker validFrom = new DatePicker();
            Grid.SetColumn(validFrom, 3);
            Grid.SetRow(validFrom, 1);
            FilterGrid.Children.Add(validFrom);
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
            FilterGrid.Children.Clear();
            TextBox clientName = new TextBox();
            Grid.SetColumn(clientName, 0);
            Grid.SetRow(clientName, 0);
            FilterGrid.Children.Add(clientName);

            ListView clientNames = new ListView();
            Grid.SetColumn(clientNames, 0);
            Grid.SetRow(clientNames, 1);

            List<CheckBox> chkBoxes = new List<CheckBox>();
            var clients = Data.Catalog.GetAllClientName();
            foreach (string client in clients)
            {
                CheckBox tmp = new CheckBox();
                tmp.Content = client;
                chkBoxes.Add(tmp);
            }

            clientNames.ItemsSource = chkBoxes;
            FilterGrid.Children.Add(clientNames);
        }

        private void ReportTypeComboBox_SelectionChanged(object sender, EventArgs e)
        {
            if (ReportTypeComboBox.SelectedIndex > -1)
            {
                switch (ReportTypeComboBox.SelectedIndex)
                {
                    case 0:
                        createClientFilters();
                        break;
                    case 1:
                        createTicketFilters();
                        break;
                    case 2:
                        createEntranceFilters();
                        break;

                }
            }
        }

        private void ExportData_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
