using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
    public class DatabaseExampleController : Controller
    {
        public ApplicationDbContext dbContext;


        public DatabaseExampleController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            var boats = dbContext.Boats_tab.ToList();
            /*HashSet<string> state_track= new HashSet<string>;
            HashSet<string> company_track;
            HashSet<string> city_track;
            boats.ForEach(p =>
            {
                string type = p.type;
                string home_port = p.home_port;
                string vessel_types = p.vessel_types;
                double latitude = p.latitude;
                double longitude = p.longitude;
                string company_url = p.company_url;

                
                string company = p.company;
                if(company_track.Contains(company))
                {

                }

                Boat boat = new Boat()
                {
                    

                type = p.type,
                    // company = p.company,

                    //street_address = p.street_address
                    //company = p.company,
                }
          
                                   
                dbContext.Boats_tab.Add(boat);
                dbContext.SaveChanges();
            };*/


            /*});*/

            // return View();
            return View(boats);
        }


    }

}