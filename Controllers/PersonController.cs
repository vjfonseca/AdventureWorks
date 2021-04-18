
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
    public ActionResult<Person> Get(int BusinessEntityID)
    {
        Person p = new Person();
        for(int i = 0; i< 20000; i++)
        {
            p = _repo.Get(i);
        }
        return Ok(p);
    }
}