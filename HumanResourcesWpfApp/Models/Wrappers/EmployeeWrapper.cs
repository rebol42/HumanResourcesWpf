using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResourcesWpfApp.Models;

namespace HumanResourcesWpfApp.Models.Wrappers
{
    public class EmployeeWrapper
    {

        public EmployeeWrapper()
        {
            Address = new AddressWrapper();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime LayOffDate { get; set; }
        public EmplStatus EmplStatusId { get; set; } 
        public decimal Salary { get; set; }
        public string Comments { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }

        public AddressWrapper Address { get; set; }


        private bool _isFirstNameValid;
        private bool _isLastNameValid;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(FirstName):

                        if (string.IsNullOrWhiteSpace(FirstName))
                        {
                            Error = "Pole Imię jest wymagane.";
                            _isFirstNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isFirstNameValid = true;
                        }
                        break;

                    case nameof(LastName):

                        if (string.IsNullOrWhiteSpace(LastName))
                        {
                            Error = "Pole Nazwisko jest wymagane.";
                            _isLastNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isLastNameValid = true;
                        }
                        break;


                    default:
                        break;

                }
                return Error;
            }

        }

        public string Error { get; set; }

    }
}
