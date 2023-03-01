using APi.Repositories.Data;
using APi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace APi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountRepository accRepository;

        public AccountController(AccountRepository accRepository)
        {
            this.accRepository = accRepository;
        }

        // POST : Account/Register
        [HttpPost("/Register")]
        public async Task<ActionResult> Register(RegisterVM registerVM)
        {
            try
            {
                var results = await accRepository.Register(registerVM);
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

        [HttpPost("/Login")]
        public async Task<ActionResult>Login(LoginVM loginVM)
        {
            try
            {
                var results = await accRepository.Login(loginVM);
                if (results is false)
                {

                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Berhasil Login!"
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        StatusCode = 400,
                        Message = "Gagal Login!"
                    });
                }
            }
            catch
            {
                return BadRequest(new
                {
                    StatusCode = 500,
                    Message = "Something Wrong!"
                });
            }
        }

    }
}
