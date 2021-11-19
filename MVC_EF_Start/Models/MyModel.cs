﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_EF_Start.Models
{
    public class Boats
    {
        public BoatDetail[] Property1 { get; set; }
    }
    public class BoatDetail
    {
        public string type { get; set; }
        public string company { get; set; }
        public string street_address { get; set; }
        //public Company_Url company_url { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone_number { get; set; }
        public string vessel_types { get; set; }
        public string home_port { get; set; }
        public string waterways { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        //public Georeference georeference { get; set; }
        public string cruise_type { get; set; }
        public Location_1 location_1 { get; set; }
        public string computed_region_yamh_8v7k { get; set; }
        public string computed_region_wbg7_3whc { get; set; }
        public string computed_region_kjdx_g34t { get; set; }
    }
    public class Location_1
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string human_address { get; set; }
    }
}









