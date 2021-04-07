using System.Collections.Generic;
using AdventureWorks.Data;
using Microsoft.AspNetCore.Mvc;

using System.Data;
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepo _repo;
    public EmployeeController(IEmployeeRepo repo)
    {
        _repo = repo;
    }
    public ActionResult<Employee> Get(int BusinessEntityID)
    {
        var e = _repo.Get(BusinessEntityID);
        if (e == null) return StatusCode(500);
        return e;
    }
    public ActionResult<int> TotalByGender(char gender)
    {
        return _repo.TotalByGender(gender);
    }
    public ActionResult<object> AllGenderByCountry()
    {
        var a = _repo.GenderByCountry();
        return a;
    }
    public ActionResult<object> AllGenderByCountryRelative()
    {
        var data = _repo.GenderByCountryRelative();
        return data;
    }
}