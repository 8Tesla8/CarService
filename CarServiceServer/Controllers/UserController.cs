using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ModelDb.DTO;
using ModelDb.Factory;
using ModelDb.Models;

namespace CarServiceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryFactory _repositoryFactory = Injection.Resolve<IRepositoryFactory>();

        [HttpPut()]
        public ActionResult<bool> Put([FromBody] UserDTO dto)
        {
            try
            {
                var user = new User()
                {
                    Email = dto.Email,
                    Notify = dto.Notify,
                };

                var repository = _repositoryFactory.GetUserRepository();

                var userExist = repository.AddIfNotExist(user);

                if(!userExist){
                    return repository.Update(user);
                }

                return userExist;
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }
    }
}
