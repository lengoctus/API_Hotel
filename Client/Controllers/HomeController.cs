using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //HttpClient client = new HttpClient();
            //Task<string> customer = client.GetStringAsync("http://localhost:8012/api/Customer/");
            //string urlcontent = await customer;

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


    }
}
