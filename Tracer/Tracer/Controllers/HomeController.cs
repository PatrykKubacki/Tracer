using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tracer.Models;
using Tracer.Repository;

namespace Tracer.Controllers
{
    public class HomeController : Controller
    {
        readonly ILogger<HomeController> _logger;
        readonly IElementsRepostiory<Element> _repostiory;

        public HomeController(IElementsRepostiory<Element> repo, ILogger<HomeController> logger)
        {
            _repostiory = repo;
            _logger = logger;
        }

        public IActionResult Index(string SearchText)
        {
            ViewData["CurrentFilter"] = SearchText;
            var elements = _repostiory.Elements;

            if (!string.IsNullOrEmpty(SearchText))
                elements = elements.Where(x => x.Title.ToLower().Contains(SearchText.ToLower()));

            return User.Identity.IsAuthenticated
                ? View(elements.ToList())
                : View("NoAuthorizedIndex");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
