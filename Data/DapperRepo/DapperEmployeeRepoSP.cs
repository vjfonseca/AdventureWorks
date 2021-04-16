using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace AdventureWorks.Data
{
    public class DapperEmployeeRepoSP : IEmployeeRepo
    {
        private string CONN_STRING = "Server=DESKTOP-0PG4D5T\\SQLEXPRESS;Database=AdventureWorks2016;Trusted_Connection=True;User Id=sa;Password=sa";
        public IEnumerable<object> GenderByCountry()
        {
            using (var connection = new SqlConnection(CONN_STRING))
            {
                var proc = "EXEC dbo.Employee_GenderByCountry";
                var data = connection.Query(proc);
                return data;
            }
        }
        public IEnumerable<object> GenderByCountryRelative()
        {
            using (var connection = new SqlConnection(CONN_STRING))
            {
                var proc = "EXEC dbo.Employee_GenderByCountryRelative_LocalVariable";
                var data = connection.Query(proc);
                return data;
            }
        }
        public IEnumerable<Employee> GetAll()
        {
            using (var connection = new SqlConnection(CONN_STRING))
            {
                var proc = "EXEC dbo.Employee_GetAll";
                var emp = connection.QueryMultiple(proc)
                                    .Read<Employee>()
                                    .AsList<Employee>();
                return emp;
            }
        }
        public int TotalByGender(char gender)
        {
            using (var connection = new SqlConnection(CONN_STRING))
            {
                var proc = "dbo.Employee_TotalByGender";

                var para = new DynamicParameters();
                para.Add("gender", gender);

                var total = connection.ExecuteScalar<int>(proc, para,
                                                          commandType: CommandType.StoredProcedure);
                return total;
            }
        }

    }
}