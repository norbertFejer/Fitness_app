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

namespace TMCatalog.View
{
    /// <summary>
    /// Interaction logic for EditClientDataWindow.xaml
    /// </summary>
    public partial class EditClientDataWindow : Window
    {
        Window mainWindow;

        public EditClientDataWindow()
        {
            InitializeComponent();
            mainWindow = Application.Current.MainWindow;
            this.Closed += EditClientDataWindow_Closed;
        }

        private void EditClientDataWindow_Closed(object sender, EventArgs e)
        {
            if (mainWindow == null)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
