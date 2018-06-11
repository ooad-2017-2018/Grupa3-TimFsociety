using eTutorMVC.Models;
using eTutorMVC.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace eTutorMVC.Controllers
{
    public class BrowseCoursesController : Controller
    {
        public static int CourseID;
        public static int TutorID;
        // GET: BrowseCourses
        [HttpGet]
        public async Task<ActionResult> CourseList()
        {
            //HttpClient client = new HttpClient();
            string Baseurl = "http://etutorwebapi.azurewebsites.net/";

            List<Models.Course> courses = new List<Models.Course>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/cours");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    courses = JsonConvert.DeserializeObject<List<Course>>(EmpResponse);

                }
                var courseListViewModel = new CourseListViewModel();
                courseListViewModel.courses = courses;
                return View(courseListViewModel);
            }
        }

        public async Task<ActionResult> Course(int CourseID)
        {
            Course currentCourse = new Course();
            //HttpClient client = new HttpClient();
            string Baseurl = "http://etutorwebapi.azurewebsites.net/";

            List<Models.Course> courses = new List<Models.Course>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/cours/"+ CourseID.ToString());

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    courses = JsonConvert.DeserializeObject<List<Course>>(EmpResponse);
                }
                currentCourse = courses[0];
                return View(currentCourse);
            }
        }

        public async Task<ActionResult> MessageTutor(int TutorID)
        {
            Notification msg = new Notification();
            //HttpClient client = new HttpClient();
            string Baseurl = "http://etutorwebapi.azurewebsites.net/";


            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/cours/" + CourseID.ToString());
                async Task<Uri> CreateProductAsync(Notification msgtoSend)
                {
                    var serializer = new JavaScriptSerializer();
                    var json = serializer.Serialize(msg);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("api/notifications", content);
                    response.EnsureSuccessStatusCode();

                    // return URI of the created resource.
                    return response.Headers.Location;
                }

                return View();
            }
        }
    }
}