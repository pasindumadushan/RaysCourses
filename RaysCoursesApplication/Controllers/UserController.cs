using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RaysCoursesApplication.Helper;
using RaysCoursesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RaysCoursesApplication.Controllers
{
    public class UserController : Controller
    {
        HelperApi _api = new HelperApi();
        List<User> user = new List<User>();


        public async Task<IActionResult> Index()
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Users"); 

            if(res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<List<User>>(result);
            }

            return View(user);
        }

        public IActionResult RegisterView()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] User viewModel)
        {
            HttpClient client = _api.Initial();
            StringContent content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");

            HttpResponseMessage res = await client.PostAsync("api/Users", content);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<List<User>>(result);
            }

            return View();
        }
    }
}
