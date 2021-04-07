using System.Data.SqlClient;
using Dapper;

using AdventureWorks.Data.SQLServerQuerys;
using System.Collections.Generic;

using System.Data;

namespace AdventureWorks.Data
{
    public class DapperEmployeeRepo : IEmployeeRepo
    {
        private string CONN_STRING = "Server=DESKTOP-0PG4D5T\\SQLEXPRESS;Database=AdventureWorks2016;Trusted_Connection=True;User Id=sa;Password=sa";

        public Employee Get(int BusinessEntityID)
        {
            using (var connection = new SqlConnection(CONN_STRING))
            {
                var sql = EmployeeSQL.Get();
                
                var dynPara = new DynamicParameters();
                dynPara.Add("BusinessEntityID", BusinessEntityID);

                Employee emp = connection.QueryFirstOrDefault<Employee>(sql, dynPara);
                return emp;
            }
        }
        public int TotalByGender(char gender)
        {
            gender = char.ToUpper(gender);
            using(var connection = new SqlConnection(CONN_STRING))
            {
                var sql = EmployeeSQL.TotalByGender();

                var dynPara = new DynamicParameters();
                dynPara.Add("Gender", gender);

                int t = connection.ExecuteScalar<int>(sql, dynPara);
                return t;
            }
        }
        public object GenderByCountry()
        {
            using(var connection = new SqlConnection(CONN_STRING))
            {
                var sql = EmployeeSQL.GenderByCountry();
                
                var data = connection.Query(sql);
                return data;
            }
        }
        public object GenderByCountryRelative()
        {
            using(var connection = new SqlConnection(CONN_STRING))
            {
                var sql = EmployeeSQL.GenderByCountryRelative();
                var data = connection.Query(sql);
                return data;
            }
        }
    }
}