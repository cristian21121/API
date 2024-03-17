using API.Business;
using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly AppDbContext appDbContext;

        public UserController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpPost]
        public IActionResult Create(UserCreateDTO userCreateDTO)
        {
            User user = (User)userCreateDTO;
            BusinessUserCreate businessUserCreate = new(user, appDbContext);

            if (businessUserCreate.Execute())
            {
                return Ok(businessUserCreate.Result);
            }
            else
            {
                return BadRequest(businessUserCreate.Exception);
            }
        }

        [HttpPut]
        public IActionResult Update(UserUpdateDTO userUpdateDTO)
        {
            User user = (User)userUpdateDTO;
            BusinessUserUpdate businessUserUpdate = new(user, appDbContext);

            if (businessUserUpdate.Execute())
            {
                return Ok(businessUserUpdate.Result);
            }
            else
            {
                return BadRequest(businessUserUpdate.Exception);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Int32 id)
        {
            BusinessUserDelete businessUserDelete = new(id, appDbContext);

            if (businessUserDelete.Execute())
            {
                return Ok(businessUserDelete.Result);
            }
            else
            {
                return BadRequest(businessUserDelete.Exception);
            }
        }

        [HttpGet]
        public IActionResult Get(Int32 id)
        {
            BusinessUserGet businessUserGet = new(id, appDbContext);
            
            if (businessUserGet.Execute())
            {
                return Ok(businessUserGet.Result);
            }
            else
            {
                return BadRequest(businessUserGet.Exception);
            }
        }

        [HttpGet("List")]
        public IActionResult GetList([FromQuery]UserGetListDTO userGetListDTO)
        {
            BusinessUserGetList businessUserGetList = new(userGetListDTO, appDbContext);

            if (businessUserGetList.Execute())
            {
                return Ok(businessUserGetList.Result);
            }
            else
            {
                return BadRequest(businessUserGetList.Exception);
            }
        }
    }
}
