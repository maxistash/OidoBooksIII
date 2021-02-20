using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assign5.Models
// The database repository
{
    public interface iOidoRepository
    {
        IQueryable<Project> Projects { get; }
    }
}
