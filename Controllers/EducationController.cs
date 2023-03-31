using APi.Base;
using APi.Models;
using APi.Repositories.Data;
using APi.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APi.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class EducationController : BaseController<int, Education, EducationRepository>
{

    public EducationController(EducationRepository repository) : base(repository)
    {
    }
}
