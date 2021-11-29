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
    
    public IActionResult Index()
    {

            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
        
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            string BOAT_API_PATH = BASE_URL;
            string boatsData = "";

            //BoatDetail boats = null;
            List<Boat> boats= null;
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

                    boats.ForEach(p =>
                    {
                        Boat boat = new Boat()
                        {
                            type = p.type,
                           // company = p.company,
                           // street_address = p.street_address
                        };
                        dbContext.Boats_tab.Add(boat);
                        dbContext.SaveChanges();
                    });
                    //DbParser.boatsParser(boats);
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

      
        // GET: CandidatesController/Details/5

        /* public IActionResult Delete(string cond)
         {

         }
         public IActionResult Update(string cond)
         {

         }*/

    }
}