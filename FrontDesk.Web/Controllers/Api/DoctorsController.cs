using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AppointmentScheduling.Data;
using FrontDesk.Web.Models;
using AppointmentScheduling.Core.Model.ScheduleAggregate;

namespace FrontDesk.Web.Controllers.Api
{
    public class DoctorsController : ApiController
    {
        private SchedulingContext db = new SchedulingContext();
       

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

}