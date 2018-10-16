using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ModelDb.Factory;

namespace CarServiceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class CarModelController : ControllerBase
    {
        private readonly IRepositoryFactory _repositoryFactory = Injection.Resolve<IRepositoryFactory>();

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try{
                var repository = _repositoryFactory.GetModelRepository();

                var list = new List<string>();
                foreach (var model in repository.GetAll())
                {
                    list.Add(model.Name);
                }

                return list;
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
