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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using HumanResourcesWpfApp.Models;
using HumanResourcesWpfApp.Models.Wrappers;
using HumanResourcesWpfApp.ViewModels;

namespace HumanResourcesWpfApp.Views
{
    /// <summary>
    /// Interaction logic for DatabaseSettingsView.xaml
    /// </summary>
    public partial class DatabaseSettingsView : MetroWindow
    {
        public DatabaseSettingsView(bool canCloseWindow)
        {
            InitializeComponent();
            DataContext = new DatabaseSettingsModel(canCloseWindow);
        }
    }
}
