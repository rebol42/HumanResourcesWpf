using HumanResourcesWpfApp.Commands;
using HumanResourcesWpfApp.Models.Wrappers;
using HumanResourcesWpfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace HumanResourcesWpfApp.ViewModels
{
    public class AddEditEmployeeViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();

       // private EnumBindingSourceExtension _enumExtension = new EnumBindingSourceExtension();


        public AddEditEmployeeViewModel(EmployeeWrapper employee = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);

            if (employee == null)
            {
                Employee = new EmployeeWrapper();

                //Dla daty zatrudnienia
                Employee.BirthDate = new DateTime(1901, 01, 01);
                // Dla daty urodzenia 
                Employee.EmploymentDate = DateTime.Now;
                //Dla daty zwolnienia
                Employee.LayOffDate = new DateTime(1901, 01, 01);
            }
            else
            {
                Employee = employee;
                IsUpdate = true;
            }



        }

        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

        private void CloseWindow(Window window)
        {
            window.Close();
           // RestartApplication();
        }

        private void RestartApplication()
        {
            Process.Start
                 (Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private bool _isUpdate;

        public bool IsUpdate
        {
            get { return _isUpdate; }
            set
            {
                _isUpdate = value;
                OnPropertyChanged();
            }
        }



        private EmployeeWrapper _employee;

        public EmployeeWrapper Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                OnPropertyChanged();
            }
        }


        private void Confirm(object obj)
        {

            // if (!_employee.IsValid) to potem
            //    return;

            if (!IsUpdate)
                AddEmployee();
            else
                UpdateEmployee();



            // tutaj bedzie dopisana logika 
            this.CloseWindow(obj as Window);
        }

        private void UpdateEmployee()
        {
            _repository.UpdateEmployee(Employee);
        }

        private void AddEmployee()
        {
            _repository.addEmployee(Employee);
        }

        private void Close(object obj)
        {
            this.CloseWindow(obj as Window);
        }

        private EmplStatus _selectedMyEnumType;

        public EmplStatus SelectedMyEnumType
        {
            get
            {
                if (Employee != null)
                    _selectedMyEnumType = Employee.EmplStatusId;

                return _selectedMyEnumType;
            }
            set
            {
                _selectedMyEnumType = value;
                OnPropertyChanged("SelectedMyEnumType");

                setEmplDateAndStatus();

                
                
            }
        }

        public IEnumerable<EmplStatus> MyEnumTypeValues
        {
            get
            {
                return Enum.GetValues(typeof(EmplStatus))
                    .Cast<EmplStatus>();
            }
        }



        private void setEmplDateAndStatus()
        {
            if (_selectedMyEnumType != Employee.EmplStatusId
                && _selectedMyEnumType == EmplStatus.zwolniony)
            {
                Employee.LayOffDate = DateTime.Now;
            }
            else if (_selectedMyEnumType != Employee.EmplStatusId
                && _selectedMyEnumType == EmplStatus.zatrudniony)
            {
                Employee.EmplStatusId = _selectedMyEnumType;
                Employee.LayOffDate = new DateTime(1901, 01, 01);
                Employee.EmploymentDate = DateTime.Now;
            }
        }



    }
}
