using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMCatalog.Common.MVVM;
using TMCatalog.Logic;

namespace TMCatalog.ViewModel.UserControls
{
    public class ReportVM : ViewModelBase
    {
        private List<string> reportTypes;
        private string selectedReportType;
        private ObservableCollection<object> mainDataContainer;
        private List<object> reportClientsList;
        private List<object> reportTicketList;

        public ReportVM()
        {
            reportTypes = new List<string>(new string[] { "Clients list", "Tickets list", "Entrances list" });
            this.SelectedReportType = reportTypes[0];
            this.ReportClientsList = Data.Catalog.GetReportClientsList().Cast<dynamic>().ToList();
            this.ReportTicketList = Data.Catalog.GetReportTicketsList().Cast<dynamic>().ToList();
        }

        public List<string> ReportTypes
        {
            get
            {
                return this.reportTypes;
            }

            set
            {
                this.reportTypes = value;
                this.RaisePropertyChanged();
            }
        }

        public string SelectedReportType
        {
            get
            {
                return this.selectedReportType;
            }

            set
            {
                this.selectedReportType = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<object> MainDataContainer
        {
            get
            {
                return this.mainDataContainer;
            }

            set
            {
                this.mainDataContainer = value;
                this.RaisePropertyChanged();
            }
        }

        public List<object> ReportClientsList
        {
            get
            {
                return this.reportClientsList;
            }

            set
            {
                this.reportClientsList = value;
                this.RaisePropertyChanged();
            }
        }

        public void AddNewClientToMainContainerByName(string name)
        {
            ObservableCollection<object> tmpClients = new ObservableCollection<object>( this.ReportClientsList.Where( c => (string)GetPropertyValue(c, "Name") == name) );

            foreach (var client in tmpClients)
            {
                this.MainDataContainer.Add(client);
            }
        }

        public void RemoveClientFromMainContainerByName(string name)
        {
            ObservableCollection<object> tmpClients = new ObservableCollection<object>( this.ReportClientsList.Where(c => (string)GetPropertyValue(c, "Name") == name) );

            foreach (var client in tmpClients)
            {
                this.MainDataContainer.Remove(client);
            }
        }

        public object GetPropertyValue(object car, string propertyName)
        {
            return car.GetType().GetProperties()
               .Single(pi => pi.Name == propertyName)
               .GetValue(car, null);
        }

        public void DeleteMainDataContainer()
        {
            if (this.MainDataContainer != null)
            {
                this.MainDataContainer.Clear();
            }
            this.MainDataContainer = new ObservableCollection<object>();
        }

        public void InitializeMainDataContainerWithClients()
        {
            this.MainDataContainer = new ObservableCollection<Object>(this.ReportClientsList);
        }

        public List<object> ReportTicketList
        {
            get
            {
                return this.reportTicketList;
            }

            set
            {
                this.reportTicketList = value;
                this.RaisePropertyChanged();
            }
        }

        public void InitializeMainDataContainerWithTickets()
        {
            this.MainDataContainer = new ObservableCollection<Object>(this.ReportTicketList);
        }

        private void FilterByTicketStatus(List<string> statuses)
        {
            ObservableCollection <Object> tmpTickets = new ObservableCollection<Object>( this.MainDataContainer.Where(c => !statuses.Contains( (string)GetPropertyValue(c, "Active") )));
            foreach (var ticket in tmpTickets)
            {
                this.MainDataContainer.Remove(ticket);
            }
        }

        private void FilterByTicketType(List<string> ticketTypes)
        {
            ObservableCollection<Object> tmpTickets = new ObservableCollection<Object>(this.MainDataContainer.Where(c => !ticketTypes.Contains((string)GetPropertyValue(c, "Type"))));
            foreach (var ticket in tmpTickets)
            {
                this.MainDataContainer.Remove(ticket);
            }
        }

        private void FilterByEntranceLeftNumber(List<int> validityNums)
        {
            ObservableCollection<Object> tmpTickets = new ObservableCollection<Object>(this.MainDataContainer.Where(c => validityNums.Any(n => (short)GetPropertyValue(c, "EntranceLeft") >= n) ));
            foreach (var ticket in tmpTickets)
            {
                this.MainDataContainer.Remove(ticket);
            }
        }

        private void FilterByEntranceLeftNumber(DateTime validTicketFrom)
        {
            ObservableCollection<Object> tmpTickets = new ObservableCollection<Object>(this.MainDataContainer.Where(c => (DateTime)GetPropertyValue(c, "ValidAfter") <= validTicketFrom));
            foreach (var ticket in tmpTickets)
            {
                this.MainDataContainer.Remove(ticket);
            }
        }

        public void FilterMainDataContainerByTicketParams(List<string> statuses, List<string> ticketTypes, List<int> validityNums, DateTime validTicketFrom)
        {
            this.InitializeMainDataContainerWithTickets();

            if (statuses.Count != 0)
            {
                this.FilterByTicketStatus(statuses);
            }

            if (ticketTypes.Count != 0)
            {
                this.FilterByTicketType(ticketTypes);
            }

            if (validityNums.Count != 0)
            {
                this.FilterByEntranceLeftNumber(validityNums);
            }

            this.FilterByEntranceLeftNumber(validTicketFrom);
        }

    }
}
