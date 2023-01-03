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

namespace HumanResourcesWpfApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
      //  private readonly bool _canCloseWindow;

        public LoginViewModel()
        {
            CancelCommand = new RelayCommand(CloseLogin);
            OkCommand = new RelayCommand(OkLogin);
            //  _canCloseWindow = canCloseWindow;

            LoginSettings = new Login();
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

        public ICommand CancelCommand { get; set; }
        public ICommand OkCommand { get; set; }
    }
}
