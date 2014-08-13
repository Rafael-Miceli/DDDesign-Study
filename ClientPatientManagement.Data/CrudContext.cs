using System.Data.Entity;
using ClientPatientManagement.Core.Model;
using FrontDesk.SharedKernel.Enums;

namespace ClientPatientManagement.Data
{
    public class CrudContext : DbContext
    {
     
     
        public CrudContext()
        : base("name=OfficeContext")
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }

    public class TestInitializerForCrudContext : DropCreateDatabaseAlways<CrudContext>
    {
        protected override void Seed(CrudContext context)
        {
            base.Seed(context);

            var clientSteve = new Client
            {
                FullName = "Steve Smith",
                PreferredName = "Steve",
                Salutation = "Mr."
            };
            context.Clients.Add(clientSteve);

            var clientJulie = new Client
            {
                FullName = "Julia Lerman",
                PreferredName = "Julie",
                Salutation = "Mrs."
            };
            context.Clients.Add(clientJulie);

            // add Rooms
            for (int i = 0; i < 5; i++)
            {
                var room = new Room { Name = string.Format("Room {0}", i+1) };
                context.Rooms.Add(room);
            }
        }
    }
}