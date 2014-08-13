using System.Collections.Generic;
using FrontDesk.SharedKernel;

namespace AppointmentScheduling.Core.Model.ScheduleAggregate
{
    public class Client : Entity<int>
    {
        public string FullName { get; private set; }

        public Client(int id)
        {
            this.Id = id;
        }

        protected Client() //required for EF
        {
        }
    }
}