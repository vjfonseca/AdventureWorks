using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace AdventureWorks.Data
{
    public class DapperPersonRepo : IPersonRepo
    {
        private string CONN_STRING = "Server=(localdb)\\mssqllocaldb;Database=AdventureWorks2016;Trusted_Connection=True";
        public Person Get(int id)
        {
            using (var connection = new SqlConnection(CONN_STRING))
            {
                //define uma sql
                var sql = @"SELECT BusinessEntityID AS Id, FirstName, LastName
                        FROM Person.Person";

                // define atributos dinamicos, extraidos de variaveis desse codigo e n de strings
                var dynamicPara = new DynamicParameters();
                sql += " where BusinessEntityID = @id";
                dynamicPara.Add("id", id);

                var pers = connection.QueryFirstOrDefault<Person>(sql, dynamicPara);
                return pers;
            }
        }
    }
}