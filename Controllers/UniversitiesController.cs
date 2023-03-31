using APi.Base;
using APi.Models;
using APi.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UniversitiesController : BaseController<int, University, UniversityRepository>
{
    private readonly UniversityRepository repository;

    public UniversitiesController(UniversityRepository repository) : base(repository)
    {
        this.repository = repository;
    }

}
