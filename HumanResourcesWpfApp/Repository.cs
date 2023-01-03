using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResourcesWpfApp.Models.Domains;
using HumanResourcesWpfApp.Models.Wrappers;
using HumanResourcesWpfApp.Models.Converters;
using HumanResourcesWpfApp.Models;
using System.Data.Entity;

namespace HumanResourcesWpfApp
{
    public class Repository
    {

        public List<EmployeeWrapper> GetEmployees(string EmplStatusId) //to jest do zmiany
        {
            using (var context = new ApplicationDbContext())
            {

                var employees = context.
                               Employees
                               .Include(x => x.Address)
                               .AsQueryable();


               
                switch(EmplStatusId)
                {
                    case "wszyscy":
                        employees = context.
                               Employees
                               .Include(x => x.Address)
                               .AsQueryable();
                        break;

                    case "zwolniony":
                        employees = employees.Where(x => x.EmplStatusId == EmplStatus.zwolniony);
                    break;

                    case "zatrudniony":
                        employees = employees.Where(x => x.EmplStatusId == EmplStatus.zatrudniony);
                     break;

                }
                    

                return employees
                        .ToList()
                        .Select(x => x.ToWrapper())
                        .ToList();

            }


        }

        public void addEmployee(EmployeeWrapper employeeWrapper)
        {
            var employee = employeeWrapper.toDao();
            var address = employeeWrapper.toAddressDao();

            using (var context = new ApplicationDbContext())
            {
                var dbEmployee = context.Employees.Add(employee);
                var dbAddress = context.Address.Add(address);
                context.SaveChanges();
            }
        }

        public void UpdateEmployee(EmployeeWrapper employeeWrapper)
        {
            var employee = employeeWrapper.toDao();


            using (var context = new ApplicationDbContext())
            {
                UpdateEmployeeProperties(employee, context);

                context.SaveChanges();
            }
        }

        private void UpdateEmployeeProperties(Employee employee, ApplicationDbContext context)
        {
            var employeeToUpate = context.Employees.Find(employee.Id);

            employeeToUpate.BirthDate   =   employee.BirthDate;
            employeeToUpate.LayOffDate  =   employee.LayOffDate;
            employeeToUpate.Pesel       =   employee.Pesel;
            employeeToUpate.Comments    =   employee.Comments;
            employeeToUpate.FirstName   =   employee.FirstName;
            employeeToUpate.LastName    =   employee.LastName;
            employeeToUpate.AddressId   =   employee.AddressId;
            employeeToUpate.Salary      =   employee.Salary;
            employeeToUpate.EmplStatusId = employee.EmplStatusId;

        }


    }
}
