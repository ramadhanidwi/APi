using Microsoft.EntityFrameworkCore;
using APi.Models;
using System;

namespace APi.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {


        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<University> Universities { get; set; }


        //Fluent API (untuk membuat relasi antar tabel dan constraint yang tidak bisa dilakukan data notation)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Membuat atribute menjadi unique
            //modelBuilder.Entity<Employee>().HasAlternateKey(e => new        //karena ada 2 atribut unique maka menggunakan anonymous function
            //{
            //    e.Email,
            //    e.PhoneNumber,
            //});

            //Relasi one Employee ke one Account sekaligus menjadi Primary Key 
            modelBuilder.Entity<Employee>()
                    .HasOne(e => e.Account)
                    .WithOne(a => a.Employee)
                    .HasForeignKey<Account>(fk => fk.EmployeeNIK);
            //Buat relasi banyak employee ke 1 manager 
            modelBuilder.Entity<Employee>().HasOne(e => e.Managers).WithMany(e => e.Employees)
                .HasForeignKey(fk => fk.ManagerId)
                .OnDelete(DeleteBehavior.NoAction);

            //menambahkan data secara default ke tabel 
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                
                new Role
                {
                    Id = 2,
                    Name = "User"
                });
        }
    }
}
