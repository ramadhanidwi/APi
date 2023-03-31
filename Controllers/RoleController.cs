using APi.Models;
using APi.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class RoleController : ControllerBase
{
    private readonly RoleRepository roleRepository;

    public RoleController(RoleRepository roleRepository)
    {
        this.roleRepository = roleRepository;
    }

    //Get All/ read 
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var result = await roleRepository.GetAll();
        if (result is null)
        {
            return NotFound(new
            {
                StatusCode = 200,
                Message = "Data Kosong!"
            });
        }
        else
        {
            return Ok(new
            {
                StatusCode = 200,
                Message = "Data Ada",
                Data = result
            });
        }
    }

    //Create / Insert 
    [HttpPost]
    public async Task<ActionResult> Insert(Role entity)
    {
        try
        {
            var results = await roleRepository.Insert(entity);
            if (results == 0)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Data Gagal Disimpan"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Data Berhasil Disimpan!"
                });
            }
        }
        catch
        {
            return BadRequest(new
            {
                StatusCode = 500,
                Message = "Something Wrong! + "
            });
        }
    }

    //Update
    //Update / Edit 
    [HttpPut]
    public async Task<ActionResult> Update(Role entity)
    {
        try
        {
            var results = await roleRepository.Update(entity);
            if (results == 0)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Data Gagal Diupdate"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Data Berhasil Diupdate!"
                });
            }
        }
        catch
        {
            return BadRequest(new
            {
                StatusCode = 500,
                Message = "Something Wrong! + "
            });
        }
    }

    //Delete 
    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var results = await roleRepository.Delete(id);
            if (results == 0)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Data Gagal Disimpan"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Data Berhasil Disimpan!"
                });
            }
        }
        catch
        {
            return BadRequest(new
            {
                StatusCode = 500,
                Message = "Something Wrong! + "
            });
        }
    }

    //GetById
    [HttpGet("{key}")]
    public async Task<ActionResult> GetById(int key)
    {
        var result = await roleRepository.GetById(key);
        if (result is null)
        {
            return Ok(new
            {
                StatusCode = 200,
                Message = "Data Kosong!"
            });
        }
        else
        {
            return Ok(new
            {
                StatusCode = 200,
                Message = "Data Ada",
                Data = result
            });
        }
    }

}
