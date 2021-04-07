
using System.Data;

namespace AdventureWorks.Data
{
    public interface IEmployeeRepo
    {
        public Employee Get (int BusinessEntityID);
        public int TotalByGender(char gender);
        public object GenderByCountry();
        public object GenderByCountryRelative();
    }
}