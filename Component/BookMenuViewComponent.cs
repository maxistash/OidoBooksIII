using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assign5.Models;

namespace Assign5.Components
{
    public class BookMenuViewComponent : ViewComponent
    {
        private iOidoRepository repository;

        public BookMenuViewComponent(iOidoRepository rep)
        {
            repository = rep;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["category"];
            return View(repository.Projects.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
    }
}
