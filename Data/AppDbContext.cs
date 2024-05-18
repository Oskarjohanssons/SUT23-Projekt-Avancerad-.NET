using ClassLibary;
using Microsoft.EntityFrameworkCore;

namespace SUT23_Projekt___Avancerad_.NET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ChangeHistory> ChangeHistorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 1,
                CustomerName = "Göran Nilsson",
                CustomerAddress = "AborreGatan 5",
                CustomerEmail = "Göran@qlok.se",
                CustomerPhone = "0701233214",


            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 2,
                CustomerName = "Astrid Johansson",
                CustomerAddress = "Bruksvägen 45",
                CustomerEmail = "Astrid@qlok.se",
                CustomerPhone = "0723516101",


            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 3,
                CustomerName = "Anna Jacobsson",
                CustomerAddress = "Hjälmvägen 1",
                CustomerEmail = "Anna@qlok.se",
                CustomerPhone = "0723112233",

            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerID = 4,
                CustomerName = "Peo Jacobsson",
                CustomerAddress = "Hjälmvägen 1",
                CustomerEmail = "Peo@qlok.se",
                CustomerPhone = "0723459469",

            });


            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentID = 1,
                AppointmentName = "Snabb besök",
                AppointmentLength = 0.5,
                AppointmentStart = new DateTime(2024, 12, 08, 10, 30, 0),
                AppointmentEnd = new DateTime(2024, 12, 08, 11, 0, 0),
                CustomerID = 1,
                CompanyID = 1,

            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentID = 2,
                AppointmentName = "Massage",
                AppointmentLength = 1,
                AppointmentStart = new DateTime(2024, 12, 2, 13, 0, 0),
                AppointmentEnd = new DateTime(2024, 12, 2, 15, 0, 0),
                CustomerID = 2,
                CompanyID = 1,

            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentID = 3,
                AppointmentName = "Rehab besök",
                AppointmentLength = 2,
                AppointmentStart = new DateTime(2024, 12, 14, 4, 0, 0),
                AppointmentEnd = new DateTime(2024, 12, 14, 5, 0, 0),
                CustomerID = 2,
                CompanyID = 1,

            });



            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyID = 1,
                CompanyName = "SportRehab",

            });

            modelBuilder.Entity<ChangeHistory>().HasData(new ChangeHistory
            {
                ChangeID = 1,
                ChangeType = "Ombokning",
                OldAppointmentTime = new DateTime(2024, 12, 14, 10, 30, 00),
                NewAppointmentTime = new DateTime(2024, 12, 15, 10, 30, 00),
                WhenChanged = new DateTime(2024, 12, 14, 10, 30, 00)
            });


        }
    }
}
