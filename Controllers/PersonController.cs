
using System;
using AdventureWorks.Data;
using Microsoft.AspNetCore.Mvc;

public class PersonController : ControllerBase
{
    private readonly IPersonRepo _repo;

    public PersonController(IPersonRepo repo)
    {
        this._repo = repo;
    }
    public ActionResult<Person> Get(int id)
    {
        return Ok(_repo.Get(id));
    }
}