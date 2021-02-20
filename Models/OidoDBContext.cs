using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assign5.Models
    //gives the DBContext class the ability to access packages through inheritance
{
    public class OidoDBContext : DbContext
    {
        public OidoDBContext (DbContextOptions<OidoDBContext> options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
    }
}
