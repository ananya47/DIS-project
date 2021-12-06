using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF_Start.Models
{
    public class State
    {
        [Key]
        public int state_id { get; set; }
        public string state { get; set; }
        // public string state_name { get; set; }
        public List<City> City { get; set; }

        // public List<Company> Companies { get; set; }
    }

    public class City
    {
        [Key]
        public int city_id { get; set; }
        public string city { get; set; }
        public State State { get; set; }
        public List<Company> Company { get; set; }

    }
    public class Company
    {
       // internal string compURL;
        //internal string compName;

        [Key]
        public int company_id { get; set; }
        public string company_url { get; set; }
        public string company { get; set; }
        public string street_address { get; set; }

        public string zip { get; set; }
        public string phone_number { get; set; }
        public City City { get; set; }
        public List<Boat> Boat { get; set; }       

    }

    public class Boat
    {
        [Key]
        public int boat_id { get; set; }
        public string home_port { get; set; }
        public string type { get; set; }
        public string vessel_types { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string cruise_type { get; set; }
        public Company Company { get; set; }
    }
   

    public class ChartModel
    {
        public string ChartType { get; set; }
        public string Labels { get; set; }
        public string Data { get; set; }
        public string Title { get; set; }

    }

    /*public class Boats
    {
        public BoatDetail[] Property1 { get; set; }
    }
    public class BoatDetail
    {
        [Key]
        public int boatID { get; set; }
        public string type { get; set; }
        public string company { get; set; }
        public string street_address { get; set; }

       // public Company_Url company_url { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone_number { get; set; }
        public string vessel_types { get; set; }
        public string home_port { get; set; }
        public string waterways { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
       // public Georeference georeference { get; set; }
        public string cruise_type { get; set; }
        public Location_1 location_1 { get; set; }
        public string computed_region_yamh_8v7k { get; set; }
        public string computed_region_wbg7_3whc { get; set; }
        public string computed_region_kjdx_g34t { get; set; }
    }
    public class Location_1
    {
        [Key]
        public int locationID { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string human_address { get; set; }
    }*/
    /* public class Company_Url
     {
         [Key]
         public int companyID { get; set; }
         public string url { get; set; }
     }*/


    /* public class Georeference
     {
         public string type { get; set; }
         public float[] coordinates { get; set; }
     }*/


    public class Rootobject
    {
        public List<Class1> Property1 { get; set; }
    }

    public class Class1
    {
        public string type { get; set; }
        public string company { get; set; }
        public string street_address { get; set; }
        public Company_Url company_url { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone_number { get; set; }
        public string vessel_types { get; set; }
        public string cruise_type { get; set; }
        public string home_port { get; set; }
        public string waterways { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public Georeference georeference { get; set; }

        public Rootobject Rootobject { get; set; }

    }

    public class Company_Url
    {
        public string url { get; set; }
    }

    public class Georeference
    {
        public string type { get; set; }
        public float[] coordinates { get; set; }
    }
}









