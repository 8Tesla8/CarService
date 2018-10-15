using System;
using Microsoft.AspNetCore.Mvc;
using ModelDb.DTO;
using ModelDb.Factory;
using ModelDb.Models;

namespace CarServiceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryFactory _repositoryFactory = Injection.Resolve<IRepositoryFactory>();

        [HttpPut()]
        public ActionResult<bool> Put([FromBody] UserDTO dto)
        {
            try
            {
                var repository = _repositoryFactory.GetUserRepository();

                return repository.Update(new User()
                {
                    Email = dto.Email,
                    Notify = dto.Notify,
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
