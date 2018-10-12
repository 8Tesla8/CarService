using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelDb;
using ModelDb.Models;
using ModelDb.Repository;

namespace CarServiceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //using (var db = new Context())
            //{
            //    db.Database.Migrate();

            //    db.User.Add(new User { Email = "Test" });
            //    var count = db.SaveChanges();
            //    Console.WriteLine("{0} records saved to database", count);

            //    Console.WriteLine();
            //    Console.WriteLine("All blogs in database:");
            //    foreach (var user in db.User)
            //    {
            //        Console.WriteLine(" - {0}", user.FirstName);
            //    }
            //}

            //work
            //var rep = new UserRepository();
            //var res1 = rep.AddIfNotExist(new User(){ Email = "Test"});
            //var res2 = rep.AddIfNotExist(new User() { Email = "Test2" });

            //rep.Update(new User() { Email = "Test", Notify = true });

            //var d = rep.GetAll();

            var rep = new ServiceTypeRepository();
            var res1 = rep.AddIfNotExist(new ServiceType() { Name = "Test" });
            var res2 = rep.AddIfNotExist(new ServiceType() { Name = "Test2" });
            var res3 = rep.AddIfNotExist(new ServiceType() { Name = "Test2" });
            var d = rep.GetAll();

            var d2 = 0;
            using (var db = new Context())
            {
                var d34 = db.User.FirstOrDefault(u => u.Id == 1);
                if (d34 != null)
                    d2 = d34.Id;
            }


            var e = new AppointmentRepository();
            e.AddIfNotExist(new Appointment(){StartTime = new DateTime(1000)});

            e.Update(new Appointment() { StartTime = new DateTime(1000), EndTime = new DateTime(500) });

            var f = e.GetAll();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
