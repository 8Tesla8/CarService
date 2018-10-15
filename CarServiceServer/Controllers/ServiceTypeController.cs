using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ModelDb.Factory;
using ModelDb.Repository;

namespace CarServiceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class ServiceTypeController : ControllerBase
    {
        private readonly IRepositoryFactory _repositoryFactory = Injection.Resolve<IRepositoryFactory>();

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try{
                var repository = _repositoryFactory.GetServiceType();

                var responceList = new List<string>();
                foreach(var serviceType in repository.GetAll()) {
                    responceList.Add(serviceType.Name);
                }

                return responceList;
            }
            catch(Exception){
                return BadRequest();
            }
        }
    }
}
