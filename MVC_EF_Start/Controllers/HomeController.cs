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
using Microsoft.EntityFrameworkCore;

/*push test*/
namespace MVC_EF_Start.Controllers
{
    public class HomeController : Controller
    {

        HttpClient httpClient = new HttpClient();

        static string BASE_URL = "https://data.ny.gov/resource/ibtm-q4dj.json";
        static string API_KEY = "wHwQfj4aHgZ9oBxLUM7sFZYaByPzRShOVsU9pPFw";


        public ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
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
            List<Class1> boats = new List<Class1>();
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
                    boats = JsonConvert.DeserializeObject<List<Class1>>(boatsData);

                    //List<Class1> selectedCollection = selected.ToList();
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
                    string url = null;
                    string zip = null;
                    string phone_number = null;
                    string latitude = null;
                    string longitude = null;

                    foreach (var x in boats)
                    {

                        // type= x[0]["type"].ToString();
                        type = x.type;
                        home_port = x.home_port;
                        latitude = x.latitude;
                        longitude = x.longitude;
                        vessel_types = x.vessel_types;
                        cruise_type = x.cruise_type;

                        company = x.company;
                        street_address = x.street_address;
                        url = x.company_url.url;
                        zip = x.zip;
                        phone_number = x.phone_number;

                        city = x.city;
                        state = x.state;
                        State obj3 = new State();
                        if (!state_track.Contains(state))
                        {

                            state_track.Add(state);
                            obj3.state = state;

                            dbContext.State_tab.Add(obj3);
                            dbContext.SaveChanges();
                        }


                        City obj2 = new City();
                        if (!city_track.Contains(city))
                        {

                            city_track.Add(city);
                            obj2.city = city;
                            obj2.State = obj3;
                            // obj2.
                            dbContext.City_tab.Add(obj2);
                            dbContext.SaveChanges();
                        }


                        Company obj1 = new Company();
                        if (!company_track.Contains(company))
                        {

                            obj1.company = company;
                            company_track.Add(company);
                            obj1.street_address = street_address;
                            obj1.company_url = url;
                            obj1.zip = zip;
                            obj1.phone_number = phone_number;
                            dbContext.Company_tab.Add(obj1);
                            dbContext.SaveChanges();
                        }


                        Boat obj = new Boat();
                        obj.type = type;
                        obj.home_port = home_port;
                        obj.latitude = latitude;
                        obj.longitude = longitude;
                        obj.vessel_types = vessel_types;
                        dbContext.Boats_tab.Add(obj);

                        //ChartModel obj4 = new ChartModel();
                        // obj4.Labels = home_port;
                        //obj4.Data=
                        dbContext.SaveChanges();

                    }



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

        //search page 
        public IActionResult Search_page()
        {
            var result1 = dbContext.Company_tab.ToList();
            return View(result1);
        }

        //create record 
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Company e)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(e);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Listings");
            }
            return View(e);
        }

        //read records
        public IActionResult Listings()
        {
            return View(dbContext.Company_tab);
        }

        //update records
        public IActionResult Modify(int id)
        {
            return View(dbContext.Company_tab.Where(a => a.company_id == id).FirstOrDefault());
        }
        [HttpPost]
        [ActionName("Modify")]
        public IActionResult Modify_post(Company com)
        {
            dbContext.Company_tab.Update(com);
            dbContext.SaveChanges();
            return RedirectToAction("Listings");
        }

        //delete records
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var compdel = dbContext.Company_tab.Where(a => a.company_id == id).FirstOrDefault();
            dbContext.Company_tab.Remove(compdel);
            dbContext.SaveChanges();
            return RedirectToAction("Listings");
        }
        //boat location details
        public ActionResult Boatloc()
        {
            return View();
        }

        //stats- chart page 
        public ActionResult Stats()
        {
            string api_link = "https://data.ny.gov/resource/ibtm-q4dj.json";

            httpClient.BaseAddress = new Uri(api_link);

            HttpResponseMessage response = httpClient.GetAsync(api_link).GetAwaiter().GetResult();


            var results = (from b in dbContext.Boats_tab
                           group b by b.home_port into res
                           select new
                           {
                               home_port = res.Key
                           }).Take(5);

            int[] label = new int[] { 1, 3, 4, 9, 2 };
            List<int> labels = new List<int>(label);

            List<string> ChartLabels = new List<string>();
            ChartLabels = results.Select(p => p.home_port).ToList();
            /*List<long> ChartData = new List<long>();
            ChartData = results.Select(p => p.covid_19_deaths).ToList();*/
            ViewBag.Labels = String.Join(",", ChartLabels.Select(d => "'" + d + "'"));
            ViewBag.Data = String.Join(",", labels.Select(d => d));


            return View();
        }

        //about us page
        public ActionResult About_us()
        {
            return View();
        }


        /*[Route("Search_page")]
        public IActionResult Search_page(string search)
        {

            Dictionary<string, int> zips = new Dictionary<string, int>();
            zips.Add("florida", 33614); zips.Add("ohio", 44264); zips.Add("california", 95389); zips.Add("texas", 79834); zips.Add("michigan", 38124);
            zips.Add("utah", 84767); zips.Add("alaska", 99755); zips.Add("illinois", 62234); zips.Add("arizona", 86001); zips.Add("alabama", 35203);
            zips.Add("kansas", 66701); zips.Add("maryland", 20601); zips.Add("newyork", 10007); zips.Add("indiana", 46304); zips.Add("colorado", 80517);
            zips.Add("oregon", 33614); zips.Add("missouri", 33614);
            if (search != null)
            {
                Company stated = dbContext.Company_tab.Where(c => c.company == search).FirstOrDefault();
                try
                {
                    int x = 0;
                    if (zips.TryGetValue(stated.company, out x))
                    { ViewBag.zip = x; }
                    else
                        ViewBag.zip = 30412;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                if (stated != null)
                {
                    List<Company> data = dbContext.Company_tab.Include(c => c.company).Where(c => c.company_id == stated.company_id).ToList();
                    ViewBag.data = data;
                    ViewBag.state = stated.company;
                }
            }
            return View("Search_page");
            
        }*/



        // public IActionResult Delete()
        //{
        //    return View();
        //}
       
        public ActionResult Zipdetails(string zipid)
        {
            //return View(dbContext.Company_tab.Where(a => a.zip == zipid).ToList());
            ViewBag.zip1 = zipid;
           /* ViewBag.comp1 = (from c in dbContext.Company_tab
                            where c.zip == zipid into res
                             select new
                             {
                                 com = res.Key
                             }).Take(5);
*/
           
            ViewBag.comp1 = (from c in dbContext.Company_tab
                              where c.zip == zipid
                              select c.street_address).ToList();
            /*ViewBag.ph1 = (from c in dbContext.Company_tab
                           where c.zip == zipid
                           select c.phone_number).ToList();*/
            //dbContext.Company_tab.Where(a => a.zip == zipid).Take(5);

            return View();


            ////string compName = null;
            ////string compURL = null;
            //List<string> zips = new List<string>();
            //List<string> compName = new List<string>();
            //List<string> compURL = new List<string>();
            //zips = zipdtl.Select(p => p.zip).ToList();
            //compName = zipdtl.Select(p => p.compName).ToList();
            //compURL = zipdtl.Select(p => p.compName).ToList();
            //ViewBag.zips = String.Join(",", zips.Select(d => "'" + d + "'"));
            //ViewBag.compName = String.Join(",", compName.Select(d => "'" + d + "'"));
            //ViewBag.compURL = String.Join(",", compURL.Select(d => "'" + d + "'"));

        }

        //public async Task<IActionResult> Modify(int id)
        //{
        //    if (id == null)
        //    {
        //        return RedirectToAction("Index");
        //    }

        //    var getcompdtls = await dbContext.Company_tab.FindAsync(id);
        //    return View(getcompdtls);
        //}
        //[HttpPost]
        ///*public async Task<IActionResult> Modify(Company nc)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        dbContext.Update(nc);
        //        await dbContext.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(nc);
        //}

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    var getResult = await dbContext.Company_tab.FindAsync(id);
        //    return View(getResult);
        //}

        [HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{

        //    var getResult = await dbContext.Company_tab.FindAsync(id);
        //    dbContext.Company_tab.Remove(getResult);
        //    await dbContext.SaveChangesAsync();
        //    return RedirectToAction("Index");

        //}
        //public async Task<IActionResult> Details(int id)
        //{
        //    var companyDetail = await dbContext.Company_tab
        //        .FirstOrDefaultAsync(m => m.company_id == id);
        //    if (companyDetail == null)
        //    {
        //        return NotFound();
        //    }
        //    return View();
        //}
      
        //public IActionResult Update(string cond)
        //{

        //    //fetch the records which match the given condition
        //    var level = dbContext.Company_tab.Where(c => c.company == cond).First();

        //    return View(level);
        //}
        //[HttpPost]
        //public IActionResult UpdateRecord(Company data)
        //{
        //    var exe = dbContext.Company_tab.FirstOrDefault(x => x.company_id == data.company_id);

        //    if (exe != null)
        //    {
        //        exe.street_address = data.street_address;
        //        exe.company_url = data.company_url;
        //        exe.phone_number = data.phone_number;

        //        dbContext.SaveChanges();
        //    }



        //    return RedirectToAction("mean", new { val = exe.street_address });
        //}
      /*  public IActionResult Delete(string cond)
        {
            var exe = dbContext.Company_tab.FirstOrDefault(x => x.company == cond);
            if (exe != null)
            {
                dbContext.Company_tab.Remove(exe);
                dbContext.SaveChanges();
                TempData["shortMessage"] = "Deleted Successfully";
            }



            return RedirectToAction("mean", new { val = exe.street_address });
        }*/
        public IActionResult InsertApi()
        {

            return View();
            
        }


    }

}