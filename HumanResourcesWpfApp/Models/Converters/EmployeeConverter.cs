using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanResourcesWpfApp.Models.Wrappers;
using HumanResourcesWpfApp.Models.Domains;

namespace HumanResourcesWpfApp.Models.Converters
{
    public static class EmployeeConverter
    {

        public static EmployeeWrapper ToWrapper(this Employee model)
        {
            return new EmployeeWrapper
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Pesel = model.Pesel,
                BirthDate = model.BirthDate,
                EmploymentDate = model.EmploymentDate,
                LayOffDate = model.LayOffDate,
                EmplStatusId = model.EmplStatusId,
                Salary = model.Salary,
                Comments = model.Comments,


                Address = new AddressWrapper
                {
                    Id = model.Address.Id,
                    City = model.Address.City,
                    Street = model.Address.Street,
                    ZipCode = model.Address.ZipCode
                },
                Street = model.Address.Street,
                ZipCode = model.Address.ZipCode,
                City = model.Address.City

            };
        }

        public static Employee toDao(this EmployeeWrapper model)
        {
            return new Employee
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Pesel = model.Pesel,
                BirthDate = model.BirthDate,
                EmploymentDate = model.EmploymentDate,
                LayOffDate = model.LayOffDate,
                EmplStatusId = model.EmplStatusId,
                Salary = model.Salary,
                Comments = model.Comments,
                AddressId = model.Address.Id

            };
        }

        public static Address toAddressDao(this EmployeeWrapper model)
        {
            return  new Address
            {
                Id = model.Address.Id,
                City = model.City,
                Street = model.Street,
                ZipCode = model.ZipCode
            };
        }
    }

}
