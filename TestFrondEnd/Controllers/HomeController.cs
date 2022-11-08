using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestFrondEnd.Models;

namespace TestFrondEnd.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var httpClient = new HttpClient();
            var result = httpClient.GetAsync("https://localhost:44374/api/Backend/GetData").Result;
            var readResult = result.Content.ReadAsStringAsync().Result;
            var convertResult = JsonConvert.DeserializeObject<Root>(readResult);

            //List<LocVM> locVm = new List<LocVM>();
            //foreach (var lock in convertResult.data)
            //{

            //}

            ViewBag.test = convertResult.data;
            return View();
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

        [HttpPost("InsertData")]
        public IActionResult InsertData(formClass form)
        {
            try
            {
                //Consume API With Http Client Method Post
                var httpClient = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(form), Encoding.UTF8, "application/json");
                var result = httpClient.PostAsync("https://localhost:44374/api/Backend/InsertData", content).Result;
                var readResult = result.Content.ReadAsStringAsync().Result;
                var convertResult = JsonConvert.DeserializeObject<dynamic>(readResult);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //return Ok(new { Code = convertResult.Code, Status = convertResult.Status, Message = convertResult.Message, Data = form });
                    return Content("Berhasil Menambahkan Data");
                }
                else
                {
                    return Content("Gagal Menambahkan Data");
                }
            }
            catch (Exception e)
            {
                string data = null;
                return Content("Internal Server Error");
            }
        }
    }
}
