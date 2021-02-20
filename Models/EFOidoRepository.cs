using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assign5.Models
//Creating the repository class that makes the Project's accesible in the html page
{
    public class EFOidoRepository : iOidoRepository
    {
        private OidoDBContext _context;
        public EFOidoRepository (OidoDBContext context)
        {
            _context = context;
        }
        public IQueryable<Project> Projects => _context.Projects;
    }
}
