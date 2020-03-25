using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

using System.Threading.Tasks;
using Client.Models.ModelsView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Client.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string UrlApi = "http://localhost:8012/api/Customer/";

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


        [HttpPost]
        public async Task<IActionResult> Login(CustomerView customer)
        {
            HttpClient _client = new HttpClient();
           

            var content = JsonConvert.SerializeObject(customer);
            var httpResponse = await _client.PostAsync(UrlApi + "Login", new StringContent(content, Encoding.Default, "application/json"));

            var createdTask = JsonConvert.DeserializeObject<CustomerView>(await httpResponse.Content.ReadAsStringAsync());
            return View();

        }


        [HttpPost]
        public IActionResult SearchRoom(CustomerView customer)
        {
            return View();
        }


    }
}
