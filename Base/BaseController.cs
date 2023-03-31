using APi.Models;
using APi.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APi.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseController <Key, Entity, Repository>: ControllerBase
    where Entity : class
    where Repository : iRepository<Key,Entity>
{
    private readonly Repository repository;

    public BaseController(Repository repository)
    {
        this.repository = repository;
    }

    //GetAll
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var result = await repository.GetAll();
        if (result is null)
        {
            return Ok(new
            {
                StatusCode = 400,
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


    //GetById
    [HttpGet("{key}")]
    public async Task<ActionResult> GetById(Key key)
    {
        var result = await repository.GetById(key);
        if (result is null)
        {
            return Ok(new
            {
                StatusCode = 400,
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

    //Insert 
    //Post
    [HttpPost]
    public async Task<ActionResult> Insert(Entity entity)
    {
        try
        {
            var results = await repository.Insert(entity);
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
    [HttpPut]
    public async Task<ActionResult> Update(Entity entity)
    {
        try
        {
            var results = await repository.Update(entity);
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

    ////Delete
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Key id)
    {
        try
        {
            var results = await repository.Delete(id);
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
                    Message = "Data Berhasil Dihapus!"
                });
            }
        }
        catch
        {
            return BadRequest(new
            {
                StatusCode = 500,
                Message = "Something Wrong! "
            });
        }
    }
}
