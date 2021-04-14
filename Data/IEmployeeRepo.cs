
using System.Collections.Generic;
using System.Data;

namespace AdventureWorks.Data
{
    public interface IEmployeeRepo
    {
        public IEnumerable<Employee> GetAll();
        public int TotalByGender(char gender);
        public object GenderByCountry();
        public object GenderByCountryRelative();
    }
}