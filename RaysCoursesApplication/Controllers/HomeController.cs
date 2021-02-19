using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RaysCoursesApplication.Helper;
using RaysCoursesApplication.Models;
using RaysCoursesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RaysCoursesApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HelperApi _api = new HelperApi();
        List<Course> courses;
        Course course;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetTableData()
        {
            courses = new List<Course>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Courses");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                courses = JsonConvert.DeserializeObject<List<Course>>(result);
                return Json(new { data = courses });
            }

            return Json(new { data = false });
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
