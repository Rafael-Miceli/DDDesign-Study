using System;
using System.Collections.Generic;
using System.Web.Http;
using AppointmentScheduling.Data;
using FrontDesk.Web.Models;
using System.Linq;

namespace FrontDesk.Web.Controllers.Api
{
    public class ClientsController : ApiController
    {
        private SchedulingContext db = new SchedulingContext();

        // GET api/values
        public IEnumerable<ClientViewModel> Get()
        {
            try
            {
                return db.Clients.Select(c => new ClientViewModel()
                {
                    ClientId = c.Id,
                    FullName = c.FullName
                })
            .OrderBy(c => c.FullName);

            }
            catch (Exception)
            {
                
                throw;
            }
            

        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]
                         string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]
                        string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}