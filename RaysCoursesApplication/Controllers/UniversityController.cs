using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RaysCoursesApplication.Helper;
using RaysCoursesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RaysCoursesApplication.Controllers
{
    public class UniversityController : Controller
    {
        HelperApi _api = new HelperApi();
        List<University> universities;
        University university;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateView()
        {
            return View();
        }

        public IActionResult EditView(int uniId)
        {
            ViewBag.ViewBagUniId = uniId;
            return View();
        }

        public async Task<IActionResult> GetTableData()
        {
            HttpClient client = _api.Initial();
            client = _api.RequestHeader(client, HttpContext.Session.GetString("Access_Token"));

            universities = new List<University>();

            HttpResponseMessage res1 = await client.GetAsync("/api/Universities");

            if (res1.IsSuccessStatusCode)
            {
                var result1 = res1.Content.ReadAsStringAsync().Result;
                universities = JsonConvert.DeserializeObject<List<University>>(result1);

                return Json(new { data = universities });
            }

            return Json(new { data = false });
        }

        public async Task<IActionResult> Create(University university)
        {
            HttpClient client = _api.Initial();
            client = _api.RequestHeader(client, HttpContext.Session.GetString("Access_Token"));

            StringContent content = new StringContent(JsonConvert.SerializeObject(university), Encoding.UTF8, "application/json");

            var res = await client.PostAsync("api/Universities", content);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;

                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        public async Task<IActionResult> GetEditdata(int uniId)
        {
            university = new University();

            HttpClient client = _api.Initial();
            client = _api.RequestHeader(client, HttpContext.Session.GetString("Access_Token"));

            HttpResponseMessage res = await client.GetAsync("api/Universities/" + uniId);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                university = JsonConvert.DeserializeObject<University>(result);

                return Json(new { data = university });
            }

            return Json(new { data = false });
        }

        public async Task<IActionResult> Edit(University university)
        {
            HttpClient client = _api.Initial();
            client = _api.RequestHeader(client, HttpContext.Session.GetString("Access_Token"));

            StringContent content = new StringContent(JsonConvert.SerializeObject(university), Encoding.UTF8, "application/json");

            HttpResponseMessage res = await client.PutAsync("api/Universities/" + university.UniId + "/", content);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;

                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        public async Task<IActionResult> Delete(int uniId)
        {
            university = new University();

            HttpClient client = _api.Initial();
            client = _api.RequestHeader(client, HttpContext.Session.GetString("Access_Token"));

            HttpResponseMessage res = await client.DeleteAsync("api/Universities/" + uniId);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                university = JsonConvert.DeserializeObject<University>(result);

                return Json(new { data = university });
            }
            return Json(new { data = false });
        }
    }

}
