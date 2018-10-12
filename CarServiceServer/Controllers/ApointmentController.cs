using System;
using CarServiceServer.Converter;
using Microsoft.AspNetCore.Mvc;
using ModelDb.DTO;
using ModelDb.Factory;
using ModelDb.Models;

namespace CarServiceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApointmentController : ControllerBase
    {
        private readonly IRepositoryFactory _repositoryFactory = Injection.Resolve<IRepositoryFactory>();

        [HttpPost]
        public ActionResult<bool> Post([FromBody] AppointmentDTO dto)
        {
            try
            {
                var converter = new AppointmentConverter(_repositoryFactory);

                var appointmentRepository = _repositoryFactory.GetAppointmentRepository();
                return appointmentRepository.AddIfNotExist(
                    converter.Convert(dto)
                );
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
