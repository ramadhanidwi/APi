using APi.Models;
using APi.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ControllerBase
    {
        private readonly UniversityRepository repository;

        public UniversitiesController(UniversityRepository repository)
        {
            this.repository = repository;
        }



        //Get
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await repository.GetAll();
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

        //Insert 
        //Post
        [HttpPost]
        public async Task<ActionResult> Insert(University entity)
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
                    return Ok(new {
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
        public async Task<ActionResult> Update(University entity)
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
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
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

        //GetByID
        [HttpGet]
        [Route("{key}")]
        public async Task<ActionResult>GetById(int key)
        {
            var result = await repository.GetById(key);
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
}
