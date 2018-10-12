using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ModelDb.Factory;
using ModelDb.Repository;

namespace CarServiceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        private readonly IRepositoryFactory _repositoryFactory = new RepositoryFactory();

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
