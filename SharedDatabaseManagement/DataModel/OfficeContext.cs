using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using FrontDesk.SharedKernel;
using FrontDesk.SharedKernel.Enums;
using VetOffice.SharedDatabase.Model;
using VetOffice.SharedDatabase.Model.ValueObjects;

namespace VetOffice.SharedDatabase.DataModel
{
  public class OfficeContext : DbContext
  {
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<AppointmentType> AppointmentTypes { get; set; }
  }

  public class TestInitializerForVetContext : DropCreateDatabaseAlways<OfficeContext>
  {
    protected override void Seed(OfficeContext context)
    {
        // Add Schedule
        var schedule = new Schedule
        {
        Id = Guid.NewGuid(),
        CompanyId = 1
        };
        context.Schedules.Add(schedule);
      
     
        // add Rooms
        for (int i = 0; i < 5; i++)
        {
        var room = new Room {Name = string.Format("Room {0}", i + 1)};
        context.Rooms.Add(room);
        }

        context.AppointmentTypes.Add(new AppointmentType
        {
        Code = "ES",
        Name = "Estudos",
        Duration = 120
        });
        context.AppointmentTypes.Add(new AppointmentType
        {
        Code = "AP",
        Name = "Apresentação",
        Duration = 70
        });
        context.AppointmentTypes.Add(new AppointmentType
        {
        Code = "MO",
        Name = "Monitoria",
        Duration = 75
        });

        context.Clients.AddRange(CreateListOfClientsWithPatients());

        // add Appointments
        context.Appointments.AddRange(GetAppointments(schedule.Id));

        base.Seed(context);
    }

    private static IEnumerable<Client> CreateListOfClientsWithPatients()
    {
        var clientGraphs = new List<Client>();
        var clientSmith = CreateClient("Steve Smith", "Steve", "Mr.");

        clientGraphs.Add(clientSmith);

        clientGraphs.Add(CreateClient("Julia Lerman", "Julie", "Mrs."));
        clientGraphs.Add(CreateClient("Wes McClure", "Wes", "Mr"));
        clientGraphs.Add(CreateClient("Andrew Mallett", "Andrew", "Mr."));
        clientGraphs.Add(CreateClient("Brian Lagunas", "Brian", "Mr."));
        clientGraphs.Add(CreateClient("Corey Haines", "Corey", "Mr."));
        clientGraphs.Add(CreateClient("Reindert-Jan Ekker", "Reindert", "Mr."));
        clientGraphs.Add(CreateClient("Patrick Hynds", "Patrick", "Mr."));
        clientGraphs.Add(CreateClient("Lars Klint", "Lars", "Mr."));
        clientGraphs.Add(CreateClient("Joe Eames", "Joe", "Mr."));
        clientGraphs.Add(CreateClient("Joe Kunk", "Joe", "Mr."));
        clientGraphs.Add(CreateClient("Ross Bagurdes", "Ross", "Mr."));
        clientGraphs.Add(CreateClient("Patrick Neborg", "Patrick", "Mr."));
        clientGraphs.Add(CreateClient("David Mann", "David", "Mr."));
        clientGraphs.Add(CreateClient("Peter Mourfield", "Peter", "Mr."));
        clientGraphs.Add(CreateClient("Keith Harvey", "Keith", "Mr."));
      
        return clientGraphs;

    }

    private static Client CreateClient(string fullName, string preferredName, string salutation)
    {
        var client = new Client
        {
        FullName = fullName,
        PreferredName = preferredName,
        Salutation = salutation
        };
        return client;
    }

    private static IEnumerable<Appointment> GetAppointments(Guid scheduleId)
    {
        var appointmentList = new List<Appointment>
        {
        new Appointment
        {
            AppointmentTypeId = 1,
            ScheduleId = scheduleId,
            ClientId = 1,
            Id = Guid.NewGuid(),
            RoomId = 1,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 10, 0, 0),
            new DateTime(2014, 6, 9, 11, 0, 0)),
            Title = "(WE) Darwin - Steve Smith"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 2,
            Id = Guid.NewGuid(),
            RoomId = 2,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 11, 0, 0),
            new DateTime(2014, 6, 9, 11, 30, 0))
            ,
            Title = "(DE) Sampson - Julie Lerman"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 3,
            Id = Guid.NewGuid(),
            RoomId = 2,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 12, 0, 0),
            new DateTime(2014, 6, 9, 12, 30, 0))
            ,
            Title = "(DE) Pax - Wes McClure"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 19,
            Id = Guid.NewGuid(),
            RoomId = 3,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 9, 0, 0),
            new DateTime(2014, 6, 9, 9, 30, 0))
            ,
            Title = "(DE) Charlie - Jesse Liberty"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 19,
            Id = Guid.NewGuid(),
            RoomId = 3,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 9, 30, 0),
            new DateTime(2014, 6, 9, 10, 30, 0))
            ,
            Title = "(DE) Allegra - Jesse Liberty"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 19,
            Id = Guid.NewGuid(),
            RoomId = 3,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 10, 30, 0),
            new DateTime(2014, 6, 9, 11, 00, 0))
            ,
            Title = "(DE) Misty - Jesse Liberty"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 4,
            Id = Guid.NewGuid(),
            RoomId = 4,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 8, 0, 0),
            new DateTime(2014, 6, 9, 8, 30, 0))
            ,
            Title = "(DE) Barney - Andrew Mallett"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 5,
            Id = Guid.NewGuid(),
            RoomId = 3,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 8, 0, 0),
            new DateTime(2014, 6, 9, 9, 0, 0))
            ,
            DateTimeConfirmed=new DateTime(2014,6,8,8,0,0),
            Title = "(DE) Rocky - Brian Lagunas"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 20,
            Id = Guid.NewGuid(),
            RoomId = 2,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 9, 0, 0),
            new DateTime(2014, 6, 9, 9, 30, 0))
            ,
            Title = "(DE) Willie - Tyler Young"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 20,
            Id = Guid.NewGuid(),
            RoomId = 2,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 9, 30, 0),
            new DateTime(2014, 6, 9, 10, 00, 0))
            ,
            Title = "(DE) JoeFish - Tyler Young"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 20,
            Id = Guid.NewGuid(),
            RoomId = 2,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 10, 0, 0),
            new DateTime(2014, 6, 9, 10, 30, 0))
            ,
            Title = "(DE) Fabian - Tyler Young"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 6,
            Id = Guid.NewGuid(),
            RoomId = 4,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 11, 0, 0),
            new DateTime(2014, 6, 9, 11, 30, 0))
            ,
            Title = "(DE) Zak - Corey Haines"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 7,
            Id = Guid.NewGuid(),
            RoomId = 4,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 9, 0, 0),
            new DateTime(2014, 6, 9, 9, 30, 0))
            ,
            Title = "(DE) Tinkelbel - Reindert Ekkert"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 18,
            Id = Guid.NewGuid(),
            RoomId = 4,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 9, 0, 0),
            new DateTime(2014, 6, 9, 9, 30, 0))
            ,
            Title = "(DE) Ruske - Julie Yack"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 18,
            Id = Guid.NewGuid(),
            RoomId = 4,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 9, 30, 0),
            new DateTime(2014, 6, 9, 10, 00, 0))
            ,
            Title = "(DE) Lizzie - Julie Yack"
        },
        new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 18,
            Id = Guid.NewGuid(),
            RoomId = 4,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 10, 0, 0),
            new DateTime(2014, 6, 9, 10, 30, 0))
            ,
            Title = "(DE) Ginger - Julie Yack"
        }
        ,
            new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 8,
            Id = Guid.NewGuid(),
            RoomId = 5,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 8, 0, 0),
            new DateTime(2014, 6, 9, 9, 00, 0))
            ,
            Title = "(DE) Anubis - Patrick Hynds"
        },
            new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 21,
            Id = Guid.NewGuid(),
            RoomId = 1,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 9, 0, 0),
            new DateTime(2014, 6, 9, 9, 30, 0))
            ,
            Title = "(DE) Radar - Michael Perry"
        },
            new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 21,
            Id = Guid.NewGuid(),
            RoomId = 1,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 9, 0, 0),
            new DateTime(2014, 6, 9, 9, 30, 0))
            ,
            Title = "(DE) Tinkerbell - Michael Perry"
        },
            new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 10,
            Id = Guid.NewGuid(),
            RoomId = 1,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 8, 0, 0),
            new DateTime(2014, 6, 9, 9, 00, 0))
            ,
            Title = "(DE) Corde - Joe Eames"
        },
            new Appointment
        {
            AppointmentTypeId = 2,
            ScheduleId = scheduleId,
            ClientId = 21,
            Id = Guid.NewGuid(),
            RoomId = 5,
            TimeRange = new DateTimeRange(
            new DateTime(2014, 6, 9, 9, 0, 0),
            new DateTime(2014, 6, 9, 9, 30, 0))
            ,
            Title = "(DE) Callie - Michael Perry"
        }
        };

        return appointmentList;
    }
  }
}