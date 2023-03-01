using APi.Models;
using APi.Repositories.Data;
using APi.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly EducationRepository eduRepository;

        public EducationController(EducationRepository eduRepository)
        {
            this.eduRepository = eduRepository;
        }

        //Get
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await eduRepository.GetAll();
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
        public async Task<ActionResult> Insert(Education entity)
        {
            try
            {
                var results = await eduRepository.Insert(entity);
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
        public async Task<ActionResult> Update(Education entity)
        {
            try
            {
                var results = await eduRepository.Update(entity);
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
                var results = await eduRepository.Delete(id);
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
        public async Task<ActionResult> GetById(int key)
        {
            var result = await eduRepository.GetById(key);
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
