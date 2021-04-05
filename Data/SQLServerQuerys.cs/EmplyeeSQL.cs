namespace AdventureWorks.Data.SQLServerQuerys
{
    public class EmployeeSQL
    {
        public static string Get()
        {
            return @"SELECT * 
                     FROM
                        (SELECT PER.BusinessEntityID, FirstName, LastName
                        FROM PERSON.Person AS PER	                 
                        WHERE PER.BusinessEntityID = @BusinessEntityID) AS P, 
                        (SELECT EMP.JobTitle, EMP.Gender
                        FROM HumanResources.Employee AS EMP                 
                        WHERE EMP.BusinessEntityID = @BusinessEntityID) AS e";
        }

        public static string TotalByGender()
        {
            return @"SELECT COUNT(*) FROM HumanResources.Employee WHERE Gender = @gender";
        }
        public static string GenderByCountry()
        {
            return @"SELECT CountryRegionCode,  Gender, COUNT(*) AS TOTAL
                     FROM PERSON.StateProvince
                         INNER JOIN Person.Address ON Person.StateProvince.StateProvinceID = Address.StateProvinceID
                         INNER JOIN PERSON.BusinessEntityAddress AS EntAddress ON EntAddress.AddressID = Address.AddressID
                         INNER JOIN HumanResources.Employee ON Employee.BusinessEntityID = EntAddress.BusinessEntityID
                     GROUP BY  StateProvince.CountryRegionCode, Employee.Gender
                     ORDER BY CountryRegionCode DESC, TOTAL DESC";
        }
        public static string GenderByCountryRelative()
        {
            return @"SELECT CountryRegionCode, GENDER, TOTAL_BY_GENDER, FORMAT(TOTAL_BY_GENDER*1.0 / TOTAL * 1.0, 'P2') AS 'RELATIVE'
                    FROM
                    (SELECT TOP 10 COUNT(*) AS TOTAL, CountryRegionCode AS CR
                    FROM PERSON.StateProvince AS S
                        INNER JOIN Person.Address AS A ON S.StateProvinceID = A.StateProvinceID
                        INNER JOIN PERSON.BusinessEntityAddress AS B ON B.AddressID = A.AddressID
                        INNER JOIN HumanResources.Employee AS E ON E.BusinessEntityID = B.BusinessEntityID
                    GROUP BY CountryRegionCode) AS T
                    INNER JOIN
                    (SELECT TOP 10 Gender, CountryRegionCode, COUNT(*) AS TOTAL_BY_GENDER
                    FROM PERSON.StateProvince AS S2
                        INNER JOIN Person.Address AS A2 ON S2.StateProvinceID = A2.StateProvinceID
                        INNER JOIN PERSON.BusinessEntityAddress AS B2 ON B2.AddressID = A2.AddressID
                        INNER JOIN HumanResources.Employee AS E2  ON E2.BusinessEntityID = B2.BusinessEntityID
                    GROUP BY  S2.CountryRegionCode, E2.Gender
                    ORDER BY CountryRegionCode DESC) AS BYGENDER
                    ON T.CR = BYGENDER.CountryRegionCode
                    where gender = @gender
                    order by 'RELATIVE'";
        }
    }
}