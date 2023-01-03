using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HumanResourcesWpfApp.Models.Domains;
using HumanResourcesWpfApp.Models.Wrappers;
using HumanResourcesWpfApp.Views;
using HumanResourcesWpfApp.Commands;
using HumanResourcesWpfApp.Models;

namespace HumanResourcesWpfApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();

      //  private DatabaseSettingsModel DbSettings = new DatabaseSettingsModel(false);

        public MainViewModel()
        {

            // to ustawiamy na pierwszym uruchomieniu zeby na podstawie utworzonych klas Domains/Wrappers/Configurations utworzyl baze danych.
            /*
           using (var context = new ApplicationDbContext())
           {
               var employees = context.Employees.ToList();
           }
           */
                AddEmployeeCommand = new RelayCommand(AddEditEmployee);
                EditEmployeeCommand = new RelayCommand(AddEditEmployee, CanEditEmployee);
                DatabaseSettingsCommand = new RelayCommand(DatabaseSettings);
                RefreshEmployeeCommand = new RelayCommand(RefreshEmployee);
            //  LoadedWindowCommand = new RelayCommand(LoadedWindow);

            InitComoBox();
            InitEmployees();


            //  LoadedWindow(null);

        }

        

        private void RefreshEmployee(object obj)
        {
            InitEmployees();
        }

        public ICommand AddEmployeeCommand { get; set; }
        public ICommand EditEmployeeCommand { get; set; }
        public ICommand DatabaseSettingsCommand { get; set; }
        public ICommand RefreshEmployeeCommand { get; set; }
    //    public ICommand LoadedWindowCommand { get; set; }

        private EmployeeWrapper _selectedEmployee;

        public EmployeeWrapper SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<EmployeeWrapper> _employees;

        public ObservableCollection<EmployeeWrapper> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }


        private void AddEditEmployee(object obj)
        {
            //to nie jest dobra praktyka 
            var addEditEmployeeWindow = new AddEditEmployeeView(obj as EmployeeWrapper);

            addEditEmployeeWindow.Closed += AddEditEmployeeWindow_Closed;
            addEditEmployeeWindow.ShowDialog();


        }
        private bool CanEditEmployee(object obj)
        {
            return SelectedEmployee != null;
        }

        private void DatabaseSettings(object obj)
        {
            //to nie jest dobra praktyka 
            var databseSettigns = new DatabaseSettingsView(true);

           //  databseSettigns.Closed += addEditStudentWindow_Closed;
            databseSettigns.ShowDialog();

        }

        private void InitEmployees()
        {
            Employees = new ObservableCollection<EmployeeWrapper>(
               _repository.GetEmployees(SelectedEmplStatus));
        }

        private void AddEditEmployeeWindow_Closed(object sender, EventArgs e)
        {
            InitEmployees();
        }

        private ObservableCollection<string> _emplStatusCombo;

        public ObservableCollection<string> EmplStatusCombo
        {
            get { return _emplStatusCombo; }
            set
            {
                _emplStatusCombo = value;
                OnPropertyChanged();
            }
        }

        private string _selectedEmplStatus;

        public string SelectedEmplStatus
        {
            get { return _selectedEmplStatus; }
            set
            {
                _selectedEmplStatus = value;
                OnPropertyChanged();
            }
        }


        private void  InitComoBox()
        {
            List<string> emplStatComb = new List<string>();

            emplStatComb.Add("zatrudniony");
            emplStatComb.Add("zwolniony");
            emplStatComb.Add("wszyscy");

            EmplStatusCombo = new ObservableCollection<string>(emplStatComb);
        }


    }


}
