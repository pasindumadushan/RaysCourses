using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RaysCoursesApplication.Helper;
using RaysCoursesApplication.Models;
using RaysCoursesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RaysCoursesApplication.Controllers
{
    public class CourseController : Controller
    {
        List<CourseCategory> courseCategory;
        List<University> university;
        List<string> dropdownResult;
        HelperApi _api = new HelperApi();

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCategoriesDropdown()
        {
            courseCategory = new List<CourseCategory>();
            dropdownResult = new List<string>();

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/CourseCategories");


            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                courseCategory = JsonConvert.DeserializeObject<List<CourseCategory>>(result);

                dropdownResult = courseCategory.Select(o => o.CatName).Distinct().ToList();


                return Json(new { data = dropdownResult });
            }

            return Json(new { data = false });
        }

        public async Task<IActionResult> GetUniversityDropdown()
        {
            university = new List<University>();
            dropdownResult = new List<string>();

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Universities");


            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                university = JsonConvert.DeserializeObject<List<University>>(result);

                dropdownResult = university.Select(o => o.UniName).Distinct().ToList();


                return Json(new { data = dropdownResult });
            }

            return Json(new { data = false });
        }

        public async Task<IActionResult> Create(CourseViewModel viewModel)
        {
            System.Diagnostics.Debug.WriteLine(viewModel.Cname);
            System.Diagnostics.Debug.WriteLine(viewModel.Cfaculty);
            System.Diagnostics.Debug.WriteLine(viewModel.CdateOfIntake);
            System.Diagnostics.Debug.WriteLine(viewModel.Cyears);
            System.Diagnostics.Debug.WriteLine(viewModel.Cfee);
            System.Diagnostics.Debug.WriteLine(viewModel.Ccategory);
            System.Diagnostics.Debug.WriteLine(viewModel.UniName);
            return Json(new { data = false });
        }

    }

}

