using Assign5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// navigate through the pages while accessing the database
namespace Assign5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private iOidoRepository _repository;
        public int PageSize = 5;
        public HomeController(ILogger<HomeController> logger, iOidoRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }


        public IActionResult Index(string category, int pageNum = 1)
        {
            // check for required fields from Model
            if (ModelState.IsValid)
            {
                //Dynamically builds numbers based on the items per page that we want
                return View(new Assign5.Models.ViewModels.ProjectListViewModel
                {
                    Projects = _repository.Projects
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.BookId)
                    .Skip((pageNum - 1) * PageSize)
                    .Take(PageSize),
                    PageInfo = new Models.ViewModels.PageInfo
                    {
                        CurrentPage = pageNum,
                        itemsPer = PageSize,
                        totalItems = category == null ? _repository.Projects.Count() :
                            _repository.Projects.Where(x =>x.Category == category).Count()
                    }
                });
            }

            else
            {
                return View("Error");
            }
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
