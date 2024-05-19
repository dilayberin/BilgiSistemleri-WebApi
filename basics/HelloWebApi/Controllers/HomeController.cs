
using HelloWebApi.Models;
using Microsoft.AspNetCore.Mvc;

using HelloWebApi.Models;

namespace HelloWebApi.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessage() {

            var result= new ResponseModel(){
                HttpStatus = 200,
                Message = "hello ASP.NET Core Web Api"
            };
            return Ok(result);
        }
    }
}