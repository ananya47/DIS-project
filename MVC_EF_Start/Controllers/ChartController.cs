using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
    public class ChartController : Controller
    {
        public ApplicationDbContext dbContext;

        public ChartController(ApplicationDbContext context)
        {
            dbContext = context;
        }
        static string api_link = "https://data.ny.gov/resource/ibtm-q4dj.json";

        HttpClient httpclient = new HttpClient();

       /* Covid_Conditions covid_conditions = new Covid_Conditions();*/

        public ViewResult Chart()
        {
            httpclient.BaseAddress = new Uri(api_link);

            HttpResponseMessage response = httpclient.GetAsync(api_link).GetAwaiter().GetResult();
           // DbDomain d = new DbDomain(_context);
            /*if (d._context.Covid_Conditions_data.ToList().Count == 0)
            {
                d.covidConditionPost(covid_conditions);
            }*/

            var results = (from b in dbContext.Boats_tab
                           group b by b.home_port into res
                          select new
                          {
                              home_port = res.Key
                          }).Take(5);

            int[] label = new int[]{1,3,4,9,2};
            List<int> labels = new List<int>(label);

            List<string> ChartLabels = new List<string>();
            ChartLabels = results.Select(p => p.home_port).ToList();
            /*List<long> ChartData = new List<long>();
            ChartData = results.Select(p => p.covid_19_deaths).ToList();*/
            ViewBag.Labels = String.Join(",", ChartLabels.Select(d => "'" + d + "'"));
              ViewBag.Data = String.Join(",", labels.Select(d => d));


            return View();
        }

        
    }
    
}
