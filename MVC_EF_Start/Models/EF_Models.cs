using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{
  
    //Assignment4 
    public class Doctor
    {
        [Key]
        public int doctorID { get; set; } 
        public string docFname { get; set; }
        public string docLname { get; set; }
        public int docAge { get; set; }
        public string docEmail { get; set; }
        public long docMobile { get; set; }
        public List<Appointment> Appointments { get; set; }
    }

    public class Patient
    {
        [Key]
        public int patientID { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public long mobile { get; set; }
        public List<Appointment> Appointments { get; set; }
    }

    public class Brand
    {
        [Key]
        public int brandID { get; set; }
        public string brandName { get; set; }
        public List<Medicine> Medicine { get; set; }
    }

    public class Medicine
    {
        [Key]
        public int medID { get; set; }
        public string medName { get; set; }
        public float price { get; set; }
        public bool isRegulated { get; set; }
        public Brand Brand { get; set; }
    }

    public class Prescription
    {
        [Key]
        public int presID { get; set; }
        public int presNumber { get; set; }
        public List<Appointment> Appointments { get; set; }
        public Medicine Medicine { get; set; }
    }

    public class Appointment
    {
        [Key]
        public int appointmentID { get; set; }
        public string apptdate  { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
        public Prescription Prescription { get; set; }
    
    }
}