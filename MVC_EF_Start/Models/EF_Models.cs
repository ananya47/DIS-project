using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{

    //Assignment4 
    public class clState
    {
        [Key]
        public int clstate_id { get; set; }
        public string clstate { get; set; }
        public List<clCity> cities { get; set; }

    }

    public class clCity
    {
        [Key]
        public int clcity_id { get; set; }
        public string clcity { get; set; }
        public clState States { get; set; }
        public List<clCompany> Companies { get; set; }
    }

    public class clCompany
    {
        [Key]
        public int clcompany_id { get; set; }
        public string clcompany_url { get; set; }
        public string clcompany { get; set; }
        public string clstreet_address { get; set; }
        public string clzip { get; set; }
        public string clphone_number { get; set; }
        public clCity city { get; set; }
        public List<clBoat> Boats { get; set; }

    }
    public class clBoat
    {
        [Key]
        public int boat_id { get; set; }
        public string home_port { get; set; }
        public string type { get; set; }
        public string vessel_types { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string cruise_type { get; set; }
        public clCompany Company { get; set; }

    }
  
    //public class Doctor
    //{
    //    [Key]
    //    public int doctorID { get; set; } 
    //    public string docFname { get; set; }
    //    public string docLname { get; set; }
    //    public int docAge { get; set; }
    //    public string docEmail { get; set; }
    //    public long docMobile { get; set; }
    //    public List<Appointment> Appointments { get; set; }
    //}

    //public class Patient
    //{
    //    [Key]
    //    public int patientID { get; set; }
    //    public string fname { get; set; }
    //    public string lname { get; set; }
    //    public int age { get; set; }
    //    public string email { get; set; }
    //    public long mobile { get; set; }
    //    public List<Appointment> Appointments { get; set; }
    //}

    //public class Brand
    //{
    //    [Key]
    //    public int brandID { get; set; }
    //    public string brandName { get; set; }
    //    public List<Medicine> Medicine { get; set; }
    //}

    //public class Medicine
    //{
    //    [Key]
    //    public int medID { get; set; }
    //    public string medName { get; set; }
    //    public float price { get; set; }
    //    public bool isRegulated { get; set; }
    //    public Brand Brand { get; set; }
    //}

    //public class Prescription
    //{
    //    [Key]
    //    public int presID { get; set; }
    //    public int presNumber { get; set; }
    //    public List<Appointment> Appointments { get; set; }
    //    public Medicine Medicine { get; set; }
    //}

    //public class Appointment
    //{
    //    [Key]
    //    public int appointmentID { get; set; }
    //    public string apptdate  { get; set; }
    //    public Doctor Doctor { get; set; }
    //    public Patient Patient { get; set; }
    //    public Prescription Prescription { get; set; }
    
    //}
}