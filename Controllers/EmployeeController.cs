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
    public ActionResult<IEnumerable<Employee>> GetAll()
    {
        var e = _repo.GetAll();
        if (e == null) return StatusCode(500);
        return Ok(e);
    }
    public ActionResult<int> TotalByGender(char gender)
    {
        return _repo.TotalByGender(char.ToUpper(gender));
    }
    public ActionResult<IEnumerable<object>> AllGenderByCountry()
    {
        var data = _repo.GenderByCountry();
        return Ok(data);
    }
    public ActionResult<IEnumerable<object>> AllGenderByCountryRelative()
    {
        var data = _repo.GenderByCountryRelative();
        return Ok(data);
    }
}