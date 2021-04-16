
using System.Collections.Generic;
using System.Data;

namespace AdventureWorks.Data
{
    public interface IEmployeeRepo
    {
        public IEnumerable<Employee> GetAll();
        public int TotalByGender(char gender);
        public IEnumerable<object> GenderByCountry();
        public IEnumerable<object> GenderByCountryRelative();
    }
}