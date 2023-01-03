using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using HumanResourcesWpfApp.Commands;
using HumanResourcesWpfApp.Models;
using HumanResourcesWpfApp.Properties;
using HumanResourcesWpfApp.Views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace HumanResourcesWpfApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        //  private readonly bool _canCloseWindow;

        private DatabaseSettingsModel DbSettings = new DatabaseSettingsModel(false);

        public LoginViewModel()
        {
            CancelCommand = new RelayCommand(CloseLogin);
            OkCommand = new RelayCommand(OkLogin);
            LoadedWindowCommand = new RelayCommand(LoadedWindow);
            //  _canCloseWindow = canCloseWindow;

            LoginSettings = new Login();
        }

        public ICommand CancelCommand { get; set; }
        public ICommand OkCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }


        private async void LoadedWindow(object obj)
        {
            if (!DbSettings.CheckConnection())
            {
                var metroWindow = Application.Current.MainWindow as MetroWindow;
                var dialog = await metroWindow.ShowMessageAsync("Błąd połączenia", $"Nie można połączyć się z bazą danych. Czy chcesz zmienić ustawienia?",
                    MessageDialogStyle.AffirmativeAndNegative);


                if (dialog == MessageDialogResult.Negative)
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    var databseSettigns = new DatabaseSettingsView(false);
                    databseSettigns.ShowDialog();
                }

            }
          
        }


        private Login _loginSettings;

        public Login LoginSettings
        {
            get { return _loginSettings; }
            set
            {
                _loginSettings = value;
                OnPropertyChanged();
            }
        }

        private void OkLogin(object obj)
        {
            if(_loginSettings.login == Settings.Default.LoginUser
                && _loginSettings.password == Settings.Default.LoginPass)
            {
               
                var MainWindow = new MainWindow();
                this.CloseWindow();
                MainWindow.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Błąd logowania");

            }
        }

        private void CloseLogin(object obj)
        {
            Application.Current.Shutdown();
        }

        private void CloseWindow()
        {
            Application.Current.Windows[0].Close();
        }

       
    }
}
