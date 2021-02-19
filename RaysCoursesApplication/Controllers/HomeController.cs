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
        List<CourseViewModel> courseViewModels;
        List<string> dropdownResult;
        Course course;
        University university;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetTableData(string? category)
        {
            courses = new List<Course>();
            courseViewModels = new List<CourseViewModel>();

            HttpClient client = _api.Initial();
            HttpResponseMessage res1 = await client.GetAsync("api/Courses");

            if (res1.IsSuccessStatusCode)
            {
                var result1 = res1.Content.ReadAsStringAsync().Result;
                courses = JsonConvert.DeserializeObject<List<Course>>(result1);

                if(category != null && category != "All")
                {
                    courses = courses.Where(x => x.Ccategory == category).ToList();
                }

                foreach(var i in courses)
                {
                    HttpResponseMessage res2 = await client.GetAsync("api/Universities/" + i.UniRefId);
                    var result2 = res2.Content.ReadAsStringAsync().Result;

                    university = JsonConvert.DeserializeObject<University>(result2);

                    courseViewModels.Add ( new CourseViewModel{ Cid = i.Cid, UniId = i.UniRefId, UniName = university.UniName, Cname = i.Cname, CdateOfIntake = i.CdateOfIntake, Cyears = i.Cyears, Cfee = i.Cfee, UniImgPath = university.UniImgPath });
                }
                return Json(new { data = courseViewModels });
            }

            return Json(new { data = false });
        }

        public async Task<IActionResult> GetCategoriesDropdown()
        {
            courses = new List<Course>();
            dropdownResult = new List<string>();

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Courses");


            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                courses = JsonConvert.DeserializeObject<List<Course>>(result);

                dropdownResult = courses.Select(o => o.Ccategory).Distinct().ToList();
                return Json(new { data = dropdownResult });
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
