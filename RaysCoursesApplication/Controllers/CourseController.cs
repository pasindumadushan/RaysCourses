using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RaysCoursesApplication.Helper;
using RaysCoursesApplication.Models;
using RaysCoursesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RaysCoursesApplication.Controllers
{
    public class CourseController : Controller
    {
        RaysCoursesContext raysCoursesContext;
        List<CourseCategory> courseCategories;
        List<University> universities;
        List<string> dropdownResult;
        Course course;
        University university;
        CourseViewModel courseViewModel;
        HelperApi _api = new HelperApi();


        public IActionResult CreateView()
        {
            return View();
        }

        public IActionResult EditView(int cid)
        {
            ViewBag.ViewBagcid = cid;
            return View();
        }

        public async Task<IActionResult> GetEditdata(int cid)
        {
            course = new Course();
            university = new University();
            courseViewModel = new CourseViewModel();

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Courses/" + cid);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                course = JsonConvert.DeserializeObject<Course>(result);

                res = await client.GetAsync("api/Universities/" + course.UniRefId);

                if (res.IsSuccessStatusCode)
                {
                    result = res.Content.ReadAsStringAsync().Result;
                    university = JsonConvert.DeserializeObject<University>(result);

                    courseViewModel.Cid = course.Cid;
                    courseViewModel.UniId = university.UniId;
                    courseViewModel.UniName = university.UniName;
                    courseViewModel.Cname = course.Cname;
                    courseViewModel.Cfaculty = course.Cfaculty;
                    courseViewModel.Ccategory = course.Ccategory;
                    courseViewModel.CdateOfIntake = course.CdateOfIntake;
                    courseViewModel.Cyears = course.Cyears;
                    courseViewModel.Cfee = course.Cfee;
                    courseViewModel.UniImgPath = university.UniImgPath;

                    return Json(new { data = courseViewModel });
                }
                else
                {
                    return Json(new { data = false });
                }
            }

            return Json(new { data = false });
        }

        public async Task<IActionResult> GetCategoriesDropdown()
        {
            courseCategories = new List<CourseCategory>();
            dropdownResult = new List<string>();

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/CourseCategories");


            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                courseCategories = JsonConvert.DeserializeObject<List<CourseCategory>>(result);

                dropdownResult = courseCategories.Select(o => o.CatName).Distinct().ToList();


                return Json(new { data = dropdownResult });
            }

            return Json(new { data = false });
        }

        public async Task<IActionResult> GetUniversityDropdown()
        {
            universities = new List<University>();
            dropdownResult = new List<string>();

            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Universities");


            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                universities = JsonConvert.DeserializeObject<List<University>>(result);

                dropdownResult = universities.Select(o => o.UniName).Distinct().ToList();


                return Json(new { data = dropdownResult });
            }

            return Json(new { data = false });
        }

        public async Task<IActionResult> Create(CourseViewModel viewModel)
        {
            university = new University();
            course = new Course();
            HttpClient client = _api.Initial();

            HttpResponseMessage res = await client.GetAsync("api/Universities/University/" +viewModel.UniName);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                university = JsonConvert.DeserializeObject<University>(result);

                course.UniRefId = university.UniId;
                course.Cname = viewModel.Cname;
                course.Cfaculty = viewModel.Cfaculty;
                course.Ccategory = viewModel.Ccategory;
                course.CdateOfIntake = viewModel.CdateOfIntake;
                course.Cyears = viewModel.Cyears;
                course.Cfee = viewModel.Cfee;

                StringContent content = new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");
                res = await client.PostAsync("api/Courses", content);

                if (res.IsSuccessStatusCode)
                {
                    result = res.Content.ReadAsStringAsync().Result;
                    //user = JsonConvert.DeserializeObject<List<User>>(result);
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            else
            {
                return Json(new { data = false });
            }
        }

    }

}

