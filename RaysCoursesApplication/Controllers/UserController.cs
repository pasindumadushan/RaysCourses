﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RaysCoursesApplication.Helper;
using RaysCoursesWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RaysCoursesApplication.Controllers
{
    public class UserController : Controller
    {
        HelperApi _api = new HelperApi();
        List<User> users;
        User user;


        public async Task<IActionResult> Index()
        {
            users = new List<User>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Users"); 

            if(res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<User>>(result);
            }

            return View(users);
        }

        public IActionResult RegisterView()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] User viewModel)
        {
            HttpClient client = _api.Initial();

            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(viewModel.Upassword);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            viewModel.Upassword = BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();

            StringContent content = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");

            HttpResponseMessage res = await client.PostAsync("api/Users", content);

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

        public IActionResult LoginView()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] User viewModel)
        {
            user = new User();
            user.Umail = viewModel.Umail;
            var success = false;

            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(viewModel.Upassword);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            user.Upassword = BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();

            HttpClient client = _api.Initial();
            StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            HttpResponseMessage res = await client.PostAsync("api/Users/Login", content);

            if (res.IsSuccessStatusCode)
            {
                HttpContext.Session.SetString("Access_Token", res.Content.ReadAsStringAsync().Result);
                
                res = await client.GetAsync("api/Users/GetUserFromMail/" + user.Umail);

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    var userList = JsonConvert.DeserializeObject<List<User>>(result);
                    
                    foreach(var i in userList)
                    {
                        if(i.Umail.ToUpper() == user.Umail.ToUpper() && i.Upassword == user.Upassword)
                        {
                            HttpContext.Session.SetString("UserId", i.Uid.ToString());
                            HttpContext.Session.SetString("UserName", i.Uname);
                            
                        }
                    }

                }
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }

        }

        public IActionResult logOut()
        {
            HttpContext.Session.Clear();
            return Json(new {success = true });
        }
    }
}
