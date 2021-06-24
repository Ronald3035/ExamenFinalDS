using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ExamenFinalDS2.Models.Datebase;

namespace ExamenFinalDS2.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.Migrate(); this will migrate the database on startup
        }
        public DbSet<Producto> Productos { get; set; }
        
        public DbSet<Usuario> Usuarios { get; set; }
       
    }
}