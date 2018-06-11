using eTutorMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace eTutorMVC.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            //HttpClient client = new HttpClient();
            string Baseurl = "http://etutorwebapi.azurewebsites.net/";

            List<User> UserInfo = new List<User>();
            List<User> UserIndexInfo = new List<User>();
            User noviUser = new User();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/users");
                HttpResponseMessage Res2 = await client.GetAsync("api/users/1");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    UserInfo = JsonConvert.DeserializeObject<List<User>>(EmpResponse);

                }
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    UserIndexInfo = JsonConvert.DeserializeObject<List<User>>(EmpResponse);
                    noviUser = UserIndexInfo[0];

                }

                return View(noviUser);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Mapa()
        {
            ViewBag.Message = "Vaša lokacija";

            return View();
        }

        public ActionResult GetLocations()
        {
            var task = Task.Run(async () => await asyncGetLocations());
            task.Wait();
            var asyncFunctionResult = task.Result;
            return asyncFunctionResult;
        }

        public async Task<ActionResult> asyncGetLocations()
        {

            var client = new HttpClient();
            var address = new Uri("https://api.foursquare.com/v2/venues/search?ll=43.85,18.23&categoryId=4bf58dd8d48988d175941735&client_id=KHAWRYD4PJ0LKVSZQF4CEXTX5GK3BDPTWS3XLCTVAYQPK515&client_secret=BSTBTSNVENYHWGGNYGGQ00X33NJNNFTPZVIPOB3LGC1UVXBI&v=20160202");
            HttpResponseMessage response = await client.GetAsync(address);
            String stream = await response.Content.ReadAsStringAsync();
            dynamic dyn = JsonConvert.DeserializeObject(stream);
            var sp = stream.Split('"');
            double lat = 0;
            var locations = new List<Lokacija>();
            string loc = "n";
            for (int i = 0; i < sp.Length; i++)
            {
                if (sp[i] == "lat")
                    lat = Convert.ToDouble(sp[i + 1].Substring(1, sp[i + 1].Length - 2));
                if (sp[i] == "lng")
                {
                    for (int j = i; j >= 0; j--)
                        if (sp[j] == "name")
                        {
                            loc = sp[j + 2];
                            break;
                        }
                    locations.Add(new Lokacija(lat, Convert.ToDouble(sp[i + 1].Substring(1, sp[i + 1].Length - 4)), loc));
                }
            }

            return Json(locations, JsonRequestBehavior.AllowGet);
        }

        private class Lokacija
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
            public string naziv { get; set; }

            public Lokacija(double latitude, double longitude, string naziv)
            {
                this.latitude = latitude;
                this.longitude = longitude;
                this.naziv = naziv;
            }
        }

    }

    
}