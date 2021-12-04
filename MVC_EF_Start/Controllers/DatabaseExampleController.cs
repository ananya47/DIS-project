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
            /*var boats = dbContext.Boats_tab.ToList();
            var companies= dbContext.Company_tab.ToList();
            var cities = dbContext.City_tab.ToList();
            var states = dbContext.State_tab.ToList();

            HashSet<string> state_track = new HashSet<string>();
            HashSet<string> company_track= new HashSet<string>();
            HashSet<string> city_track = new HashSet<string>();
            boats.ForEach(p =>
            {
                string type = p.type;
                string home_port = p.home_port;
                string vessel_types = p.vessel_types;
                double latitude = p.latitude;
                double longitude = p.longitude;

                companies.ForEach(c =>
                {
                    string company = c.company;
                    if (!company_track.Contains(company))
                    {
                        company_track.Add(company);
                        string company_url = c.company_url;
                        string street_address = c.street_address;
                        int zip = c.zip;
                        string phone_number = c.phone_number;
                    }
                });

                foreach (Boat boat in boats)
                {
                    dbContext.Boats_tab.Add(boat);
                }
                foreach (Company company in companies)
                {
                    dbContext.Company_tab.Add(company);
                }

                dbContext.SaveChanges();
            });*/
            return View();
        }
    }
    }
