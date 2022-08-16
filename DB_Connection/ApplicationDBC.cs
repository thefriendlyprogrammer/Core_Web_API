using CoreWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.DB_Connection
{
    public class ApplicationDBC : DbContext
    {
        public ApplicationDBC(DbContextOptions<ApplicationDBC> Options):base(Options)
        {

        }

        public DbSet<SoftwareEnginnerModel> softwareEnginners { get; set; }
    }
}
