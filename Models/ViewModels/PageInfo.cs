using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assign5.Models.ViewModels
{
    public class PageInfo
    {
        public int totalItems { get; set; }
        public int itemsPer { get; set; }
        public int CurrentPage { get; set; }
        public int totalPages => (int)(Math.Ceiling(totalItems / (decimal)itemsPer));
    }
}
