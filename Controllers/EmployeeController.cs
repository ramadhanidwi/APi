using APi.Base;
using APi.Models;
using APi.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace APi.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class EmployeeController : BaseController<string, Employee, EmployeeRepository>
{
    public EmployeeController(EmployeeRepository repository) : base(repository)
    {
    }
}
