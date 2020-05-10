using System;
using System.Collections.Generic;
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
        private List<object> mainDataContainer;

        public ReportVM()
        {
            reportTypes = new List<string>(new string[] { "Clients list", "Tickets list", "Entrances list" });
            this.SelectedReportType = reportTypes[0];
            this.MainDataContainer = Data.Catalog.GetAllClients().Cast<dynamic>().ToList();
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

        public List<object> MainDataContainer
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
    }
}
