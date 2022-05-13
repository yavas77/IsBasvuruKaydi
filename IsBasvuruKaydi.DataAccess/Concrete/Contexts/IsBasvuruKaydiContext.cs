using IsBasvuruKaydi.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsBasvuruKaydi.DataAccess.Concrete.Contexts
{
    public class IsBasvuruKaydiContext : IdentityDbContext<User, Role, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=IsBasvuruKaydiDB;Trusted_Connection=True;");

        }

        public DbSet<Cv> Cvler { get; set; }
    }
}
