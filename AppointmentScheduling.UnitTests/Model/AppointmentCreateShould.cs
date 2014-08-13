using System;
using NUnit.Framework;
using AppointmentScheduling.Core.Model.ScheduleAggregate;

namespace AppointmentScheduling.UnitTests.Model
{
    [TestFixture]
    public class AppointmentCreateShould
    {
        private int invalidId = 0;
        private int testClientId = 456;
        private int testRoomId = 567;
        private int testAppointmentTypeId = 1;
        private Guid testScheduleId = Guid.Empty;
        private DateTime testStartTime = new DateTime(2014, 7, 1, 9, 0, 0);
        private DateTime testEndTime = new DateTime(2014, 7, 1, 9, 30, 0);
        private string testTitle = "(WE) Darwin - Steve Smith";

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            MatchType = MessageMatch.Contains, ExpectedMessage = "clientId")]
        public void ThrowExceptionGivenInvalidClientId()
        {
            var appointment = Appointment.Create(testScheduleId, invalidId, testRoomId, testStartTime, testEndTime,
                testAppointmentTypeId, testTitle);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            MatchType = MessageMatch.Contains, ExpectedMessage = "patientId")]
        public void ThrowExceptionGivenInvalidPatientId()
        {
            var appointment = Appointment.Create(testScheduleId, testClientId, testRoomId, testStartTime, testEndTime,
                testAppointmentTypeId, testTitle);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            MatchType = MessageMatch.Contains, ExpectedMessage = "roomId")]
        public void ThrowExceptionGivenInvalidRoomId()
        {
            var appointment = Appointment.Create(testScheduleId, testClientId, invalidId, testStartTime, testEndTime,
                testAppointmentTypeId, testTitle);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            MatchType = MessageMatch.Contains, ExpectedMessage = "appointmentTypeId")]
        public void ThrowExceptionGivenInvalidAppointmentTypeId()
        {
            var appointment = Appointment.Create(testScheduleId, testClientId, testRoomId, testStartTime, testEndTime,
                invalidId, testTitle);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            MatchType = MessageMatch.Contains, ExpectedMessage = "title")]
        public void ThrowExceptionGivenInvalidTitle()
        {
            var appointment = Appointment.Create(testScheduleId, testClientId,testRoomId, testStartTime, testEndTime,
                testAppointmentTypeId,  String.Empty);
        }

        [Test]
        public void RelateToAClientAndPatient()
        {
            var appointment = Appointment.Create(testScheduleId, testClientId, testRoomId, testStartTime, testEndTime, testAppointmentTypeId,testTitle);

            Assert.AreEqual(testClientId, appointment.ClientId);
            Assert.AreEqual(testRoomId, appointment.RoomId);
            Assert.AreEqual(testAppointmentTypeId, appointment.AppointmentTypeId);
            Assert.AreEqual(testTitle, appointment.Title);
        }

    }
}
