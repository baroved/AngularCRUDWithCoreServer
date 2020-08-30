using Microsoft.EntityFrameworkCore;
using ServerCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCore.DAL
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Beer> Beers { get; set; }
    }
}
