using APi.Models;
using APi.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository empRepository;

        public EmployeeController(EmployeeRepository empRepository)
        {
            this.empRepository = empRepository;
        }

        //Read / get 
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await empRepository.GetAll();
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

        //Create / Insert 
        [HttpPost]
        public async Task<ActionResult> Insert(Employee entity)
        {
            try
            {
                var results = await empRepository.Insert(entity);
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

        //Update / Edit 
        [HttpPut]
        public async Task<ActionResult> Update(Employee entity)
        {
            try
            {
                var results = await empRepository.Update(entity);
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
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var results = await empRepository.Delete(id);
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
        public async Task<ActionResult> GetById(string key)
        {
            var result = await empRepository.GetById(key);
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
