using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResourcesWpfApp.Models;
using HumanResourcesWpfApp.Models.Domains;
using HumanResourcesWpfApp.Models.Wrappers;
using HumanResourcesWpfApp.Views;
using HumanResourcesWpfApp.Commands;
using System.Windows.Input;
using System.Windows;
using MahApps.Metro.Controls;
using HumanResourcesWpfApp.Properties;
using System.Diagnostics;

namespace HumanResourcesWpfApp.ViewModels
{
    class DatabaseSettingsModel : ViewModelBase
    {

        private ApplicationDbContext _appCbContext = new ApplicationDbContext();

        private DbConnect _databaseSettigns;

        private readonly bool _canCloseWindow;


        public ICommand SaveDbSettingsCommand { get; set; }
        public ICommand CloseDbSettingsCommand { get; set; }
        public ICommand DbConnectionTestCommand { get; set; }


        public DatabaseSettingsModel(bool canCloseWindow)
        {
            SaveDbSettingsCommand = new RelayCommand(SaveDbSettigns);
            CloseDbSettingsCommand = new RelayCommand(CloseDbSettigns);
            DbConnectionTestCommand = new RelayCommand(DbTestConnection);
            _canCloseWindow = canCloseWindow;


            DatabaseSettigns = new DbConnect
            {
                Server = Settings.Default.Server,
                ServerDbName = Settings.Default.ServerDbName,
                Database = Settings.Default.Database,
                User = Settings.Default.User,
                Password = Settings.Default.Password
            };
            

        }


        public DbConnect DatabaseSettigns
        {
            get { return _databaseSettigns; }
            set
            {
                _databaseSettigns = value;
                OnPropertyChanged();
            }
        }




        private void SaveDbSettigns(object obj)
        {
            _appCbContext.DbConnection(_databaseSettigns);
            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
                
        }

        private void CloseDbSettigns(object obj)
        {
            if(_canCloseWindow)
                CloseWindow(obj as MetroWindow);
            else
               Application.Current.Shutdown();
        }

        private void DbTestConnection(object obj)
        {
            _appCbContext.ChangeConnectionString(_databaseSettigns);


            if (this.CheckConnection())
            {
                MessageBox.Show("Prawidłowe połączenie z bazą danych");
            }
            else
                MessageBox.Show("Brak połączenia z bazą danych");
        }
        private void CloseWindow(MetroWindow window)
        {
            window.Close();
        }


        public  bool CheckConnection()
        {
            bool flag = false;
            try
            {
                
                using (var context = new ApplicationDbContext())
                {
                    context.Database.Connection.Open();
                    context.Database.Connection.Close();
                    flag = true;

                }
                

            }
            catch (Exception t)
            {
                flag = false;
            }
            return flag;
        }
    }
}
