using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Data.Entity.ModelConfiguration;

namespace WebApplication2.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<UserSerial> UserSerials { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Seria> Serias { get; set; }
        public DbSet<SerialSeazon> SerialsSeazons { get; set; }
        public DbSet<Seazon> Seazons { get; set; }
        public DbSet<Serial> Serials { get; set; }
        public DbSet<Ganer> Ganers { get; set; }
        public DbSet<SerialGaner> SerialGaners { get; set; }
        public DbSet<Cookie> Cookies { get; set; }
        public DbSet<CookieSerial> CookieSerials { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<UserSerial> UserSerials { get; set; }
        public ApplicationDbContext()
            : base("Serial2", throwIfV1Schema: false)
        {
            Database.SetInitializer(new Initialiser());
        }

        public static ApplicationDbContext Create()
        {

            return new ApplicationDbContext();
        }

    }
   
       
}