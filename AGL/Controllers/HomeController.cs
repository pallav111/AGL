using AGL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using static AGL.Helper;

namespace AGL.Controllers
{
    public class HomeController : Controller
    {
        public string JsonData { get; set; }
        public HomeController()
        {
            JsonData = new WebClient().DownloadString("http://agl-developer-test.azurewebsites.net/people.json");
        }
        public ActionResult Index()
        {
            var owner = Deserialize.FromJson(JsonData);

            var model = new HomeModel()
            {
                CatsOfMales = JsonQuery.GetAnimalNamesByGender(owner, "Male", "Cat"),
                CatsOfFemales = JsonQuery.GetAnimalNamesByGender(owner, "Female", "Cat")
            };

            return View(model);
        }
    }
}
