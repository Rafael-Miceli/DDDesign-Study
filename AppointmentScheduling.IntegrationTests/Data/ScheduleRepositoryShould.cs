using System;
using System.Data.Entity;
using System.Linq;
using AppointmentScheduling.Data;
using AppointmentScheduling.Data.Repositories;
using NUnit.Framework;

namespace AppointmentScheduling.IntegrationTests.Data
{
    [TestFixture]
    public class ScheduleRepositoryShould
    {
        private int testCompanyId = 1;
        private DateTime testDateWithNoAppointments = new DateTime(2001, 1, 1);
        private DateTime testDateWithAppointments = new DateTime(2014, 6, 9);

        public ScheduleRepositoryShould()
        {
            Database.SetInitializer<SchedulingContext>(null);
        }

        [Test]
        public void NotReturnNullAppointmentsCollectionInScheduleTypeIfNoAppointmentsFound()
        {
            var repo = new ScheduleRepository(new SchedulingContext());
            Assert.IsNotNull(repo.GetScheduleForDate(testCompanyId, testDateWithNoAppointments).Appointments);
        }

        [Test]
        public void ReturnAppointmentsFromGetScheduledAppointmentsForDate()
        {
            var repo = new ScheduleRepository(new SchedulingContext());
            Assert.IsNotNull(repo.GetScheduleForDate(testCompanyId, testDateWithAppointments).Appointments);
        }


    }
}