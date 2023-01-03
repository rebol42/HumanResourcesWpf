using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResourcesWpfApp.Models;

namespace HumanResourcesWpfApp.Models.Domains
{
    public class Employee
    {

  
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
        public int AddressId { get; set; }

        public Address Address { get; set; }
    }
}
