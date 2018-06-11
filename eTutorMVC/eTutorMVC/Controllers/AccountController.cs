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

namespace eTutorMVC.Controllers
{
    public class AccountController : Controller
    {
        Models.User Korisnik = new Models.User();
        // GET: Account
        public async Task<ActionResult> LogIn(FormCollection form)
        {
            var email = form["email"].ToString();
            var password = form["password"].ToString();

            List<User> users = new List<User>();
            List<Password> passwords = new List<Password>();

            string Baseurl = "http://etutorwebapi.azurewebsites.net/";

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/users");
                HttpResponseMessage Res2 = await client.GetAsync("api/passwords");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    users = JsonConvert.DeserializeObject<List<User>>(EmpResponse);

                }
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res2.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    passwords = JsonConvert.DeserializeObject<List<Password>>(EmpResponse);
                    
                }
                int ID1=30000;
                foreach (var p in passwords)
                {
                    if (p.password1.Equals(password))
                        ID1 = p.user_id;
                }
                int ID2=40000;
                foreach(var u in users)
                {
                    if (u.e_mail.Equals(email))
                    {
                        ID2 = u.user_id;
                        Korisnik = u;
                    }
                }
                if(ID1==ID2)
                {
                    ViewBag.SucessMessage = "Welcome " + Korisnik.first_name + " " + Korisnik.last_name + "!";
                    return RedirectToAction("Dashboard", "Account");
                }
                else
                {
                    ViewBag.SucessMessage = "Invalid email and password combination!";
                    Korisnik = null;
                }

                    return View();
            }
        }
        public ActionResult DashBoard()
        {
            return View(Korisnik);
        }

        public async Task<ActionResult> ViewMessages()
        {
            string Baseurl = "http://etutorwebapi.azurewebsites.net/";

            List<Notification> messages = new List<Notification>();
            List<Notification> myMsg = new List<Notification>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/notifications");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    messages = JsonConvert.DeserializeObject<List<Notification>>(EmpResponse);
                }
              
            }
            foreach(var not in messages)
            {
                if (not.user_id == Korisnik.user_id)
                { myMsg.Add(not); }
            }

            return View(myMsg);
        }
    }
}