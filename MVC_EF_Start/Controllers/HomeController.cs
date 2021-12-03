using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Mywebproject_core.Models;
using Newtonsoft.Json;
using System.Net.Http;
using MVC_EF_Start.Models;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Infrastructure;

/*push test*/
namespace MVC_EF_Start.Controllers
{
  public class HomeController : Controller
  {

        public ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        HttpClient httpClient;

        static string BASE_URL = "https://data.ny.gov/resource/ibtm-q4dj.json";
        static string API_KEY = "wHwQfj4aHgZ9oBxLUM7sFZYaByPzRShOVsU9pPFw";
        public ActionResult About_us()
        {
            return View();
        }
        public ActionResult Boatloc()
        {
            return View();
        }
        public ActionResult Search_page()
        {
            return View();
        }
        public ActionResult Stats()
        {
            return View();
        }
       
        public IActionResult Index()
        {

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();

            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string BOAT_API_PATH = BASE_URL;
            string boatsData = "";

            //BoatDetail boats = null;
            List<Boat> boats = new List<Boat>();
            httpClient.BaseAddress = new Uri(BOAT_API_PATH);
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(BOAT_API_PATH).GetAwaiter().GetResult();

                if (response.IsSuccessStatusCode)
                {
                    boatsData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!boatsData.Equals(""))
                {

                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    //boats = JsonConvert.DeserializeObject<BoatDetail>(boatsData);
                    boats = JsonConvert.DeserializeObject<List<Boat>>(boatsData);
                    Console.WriteLine(boats);
                    Console.WriteLine("Data displayed");
                    // Console.Log(boat);

                    // var boats = dbContext.Boats_tab.ToList();
                  /*  var companies = dbContext.Company_tab.ToList();
                    var cities = dbContext.City_tab.ToList();
                    var states = dbContext.State_tab.ToList();*/

                    HashSet<string> state_track = new HashSet<string>();
                    HashSet<string> company_track = new HashSet<string>();
                    HashSet<string> city_track = new HashSet<string>();
                    string type = null;
                    string home_port = null;
                    string vessel_types = null;
                    string cruise_type = null;
                    string city = null;
                    string state = null;
                    string company = null;
                    string street_address = null;
                    string company_url = null;
                    int zip = 0;
                    string phone_number = null;
                    double latitude = 0.0;
                    double longitude = 0.0;

                    foreach (var x in boats)
                    {

                        // type= x[0]["type"].ToString();
                        type = x.type;
                        home_port = x.home_port;
                        latitude = x.latitude;
                        longitude = x.longitude;
                        vessel_types = x.vessel_types;
                        cruise_type = x.cruise_type;

                        /*company = x.company1.company;
                        street_address = x.company1.street_address;
                        company_url = x.company1.company_url;
                        zip = x.company1.zip;
                        phone_number = x.company1.phone_number;*/

                       // city = x.company.city;

                        Boat obj = new Boat();
                        obj.type = type;
                        obj.home_port = home_port;
                        obj.latitude = latitude;
                        obj.longitude = longitude;
                        obj.vessel_types = vessel_types;
                        dbContext.Boats_tab.Add(obj);

                        

                        /*if (!company_track.Contains(company))
                        {*/
                            /*Company obj1 = new Company();
                            obj1.company = company;
                            company_track.Add(company);
                            obj1.street_address = street_address;
                            obj1.company_url = company_url;
                            obj1.zip = zip;
                            obj1.phone_number = phone_number;
                            dbContext.Company_tab.Add(obj1);*/
                        
                       /* if (!city_track.Contains(city))
                        {
                            City obj2 = new City();
                            city_track.Add(city);
                            obj2.city = city;
                        }
                        if (!state_track.Contains(state))
                        {
                            State obj3 = new State();
                            state_track.Add(state);
                            obj3.state = state;

                        }*/



                    }
                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }
            //   dbContext.SaveChanges();
        
            return View(boats);
        }
            

    }

    }
