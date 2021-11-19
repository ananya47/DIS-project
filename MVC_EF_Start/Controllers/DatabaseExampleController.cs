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
            return View();
        }

        public async Task<ViewResult> DatabaseOperations()
        {
            // Assignment 4
            //Table 1 - Doctor Records

            Doctor DocRec1 = new Doctor();
            // DocRec1.doctorID = 1;
            DocRec1.docFname = "John";
            DocRec1.docLname = "Smith";
            DocRec1.docAge = 30;
            DocRec1.docEmail = "john@gmail.com";
            DocRec1.docMobile = 8130001234;

            Doctor DocRec2 = new Doctor();
            //   DocRec2.doctorID = 2;
            DocRec2.docFname = "Emily";
            DocRec2.docLname = "Green";
            DocRec2.docAge = 35;
            DocRec2.docEmail = "emily@gmail.com";
            DocRec2.docMobile = 8130005678;

            Doctor DocRec3 = new Doctor();
            //  DocRec3.doctorID = 3;
            DocRec3.docFname = "Joe";
            DocRec3.docLname = "T";
            DocRec3.docAge = 40;
            DocRec3.docEmail = "joe@gmail.com";
            DocRec3.docMobile = 8130009123;

            Doctor DocRec4 = new Doctor();
            //  DocRec4.doctorID = 4;
            DocRec4.docFname = "Simsons";
            DocRec4.docLname = "Bing";
            DocRec4.docAge = 45;
            DocRec4.docEmail = "sim@gmail.com";
            DocRec4.docMobile = 8130004567;

            Doctor DocRec5 = new Doctor();
            // DocRec5.doctorID = 5;
            DocRec5.docFname = "Phoebe";
            DocRec5.docLname = "Buffay";
            DocRec5.docAge = 30;
            DocRec5.docEmail = "phoe@gmail.com";
            DocRec5.docMobile = 8130008912;

            dbContext.Doctors.Add(DocRec1);
            dbContext.Doctors.Add(DocRec2);
            dbContext.Doctors.Add(DocRec3);
            dbContext.Doctors.Add(DocRec4);
            dbContext.Doctors.Add(DocRec5);
            dbContext.SaveChanges();

            //Table 2 - Patient records
            Patient PatRec1 = new Patient();
            // PatRec1.patientID = 1;
            PatRec1.fname = "Ross";
            PatRec1.lname = "Geller";
            PatRec1.age = 43;
            PatRec1.email = "ross@usf.edu";
            PatRec1.mobile = 8135933431;

            Patient PatRec2 = new Patient();
            //PatRec2.patientID = 2;
            PatRec2.fname = "Rachel";
            PatRec2.lname = "green";
            PatRec2.age = 41;
            PatRec2.email = "green@usf.edu";
            PatRec2.mobile = 8135937432;

            Patient PatRec3 = new Patient();
            //PatRec3.patientID = 3;
            PatRec3.fname = "Monica";
            PatRec3.lname = "Geller";
            PatRec3.age = 40;
            PatRec3.email = "geller@usf.edu";
            PatRec3.mobile = 8135931234;

            Patient PatRec4 = new Patient();
            //PatRec4.patientID = 4;
            PatRec4.fname = "Chandler";
            PatRec4.lname = "bing";
            PatRec4.age = 38;
            PatRec4.email = "bing@usf.edu";
            PatRec4.mobile = 8135937457;

            Patient PatRec5 = new Patient();
            // PatRec5.patientID = 5;
            PatRec5.fname = "Mariah";
            PatRec5.lname = "Better Half";
            PatRec5.age = 41;
            PatRec5.email = "mariah@usf.edu";
            PatRec5.mobile = 8135937432;

            dbContext.Patients.Add(PatRec1);
            dbContext.Patients.Add(PatRec2);
            dbContext.Patients.Add(PatRec3);
            dbContext.Patients.Add(PatRec4);
            dbContext.Patients.Add(PatRec5);
            dbContext.SaveChanges();


            //Table 3 - Brand Records
            Brand Brand1 = new Brand();
            //Brand1.brandID = 1;
            Brand1.brandName = "A Nil";

            Brand Brand2 = new Brand();
            //Brand2.brandID = 2;
            Brand2.brandName = "Advil";

            Brand Brand3 = new Brand();
            //Brand3.brandID = 3;
            Brand3.brandName = "Abcin";

            Brand Brand4 = new Brand();
            //Brand4.brandID = 4;
            Brand4.brandName = "L Nuron";

            Brand Brand5 = new Brand();
            //Brand5.brandID = 5;
            Brand5.brandName = "T Clar";

            dbContext.Brands.Add(Brand1);
            dbContext.Brands.Add(Brand2);
            dbContext.Brands.Add(Brand3);
            dbContext.Brands.Add(Brand4);
            dbContext.Brands.Add(Brand5);
            dbContext.SaveChanges();

            ////Table 4 Medicine records 
            Medicine Med1 = new Medicine();
            //Med1.medID = 1;
            Med1.medName = "Advair Diskus";
            Med1.price = 413;
            Med1.isRegulated = true;
            Med1.Brand = Brand1;

            Medicine Med2 = new Medicine();
            //Med2.medID = 2;
            Med2.medName = "Lantus Solostar";
            Med2.price = 141;
            Med2.isRegulated = true;
            Med2.Brand = Brand2;

            Medicine Med3 = new Medicine();
            //Med3.medID = 3;
            Med3.medName = "Vyvanse";
            Med3.price = 140;
            Med3.isRegulated = true;
            Med3.Brand = Brand3;

            Medicine Med4 = new Medicine();
            //Med4.medID = 4;
            Med4.medName = "Lyrica";
            Med4.price = 38;
            Med4.isRegulated = true;
            Med4.Brand = Brand4;

            Medicine Med5 = new Medicine();
            //Med5.medID = 5;
            Med5.medName = "Januvia";
            Med5.price = 151;
            Med5.isRegulated = false;
            Med5.Brand = Brand5;

            dbContext.Medicines.Add(Med1);
            dbContext.Medicines.Add(Med2);
            dbContext.Medicines.Add(Med3);
            dbContext.Medicines.Add(Med4);
            dbContext.Medicines.Add(Med5);
            dbContext.SaveChanges();


            ////Table 5 - Prescription 

            Prescription Pres1 = new Prescription();
            //Pres1.presID = 1;
            Pres1.presNumber = 100;
            Pres1.Medicine = Med1;

            Prescription Pres2 = new Prescription();
            //Pres1.presID = 2;
            Pres2.presNumber = 200;
            Pres2.Medicine = Med2;

            Prescription Pres3 = new Prescription();
            //Pres1.presID = 3;
            Pres3.presNumber = 300;
            Pres3.Medicine = Med3;

            Prescription Pres4 = new Prescription();
            //Pres1.presID = 4;
            Pres4.presNumber = 400;
            Pres4.Medicine = Med4;

            Prescription Pres5 = new Prescription();
            //Pres1.presID = 5;
            Pres5.presNumber = 500;
            Pres5.Medicine = Med5;

            dbContext.Prescriptions.Add(Pres1);
            dbContext.Prescriptions.Add(Pres2);
            dbContext.Prescriptions.Add(Pres3);
            dbContext.Prescriptions.Add(Pres4);
            dbContext.Prescriptions.Add(Pres5);
            dbContext.SaveChanges();


            //Table 6- Appointmentdetails 
            Appointment Appt1 = new Appointment();
            //Appt1.appointmentID = 1;
            Appt1.apptdate = "10-11-2021";
            Appt1.Doctor = DocRec1;
            Appt1.Patient = PatRec1;
            Appt1.Prescription = Pres1;

            Appointment Appt2 = new Appointment();
            //Appt2.appointmentID = 2;
            Appt2.apptdate = "24-12-2021";
            Appt2.Doctor = DocRec2;
            Appt2.Patient = PatRec2;
            Appt2.Prescription = Pres2;

            Appointment Appt3 = new Appointment();
            //Appt3.appointmentID = 3;
            Appt3.apptdate = "21-11-2021";
            Appt3.Doctor = DocRec3;
            Appt3.Patient = PatRec3;
            Appt3.Prescription = Pres3;

            Appointment Appt4 = new Appointment();
            // Appt4.appointmentID = 4;
            Appt4.apptdate = "30-10-2021";
            Appt4.Doctor = DocRec4;
            Appt4.Patient = PatRec4;
            Appt4.Prescription = Pres4;

            Appointment Appt5 = new Appointment();
            // Appt5.appointmentID = 5;
            Appt5.apptdate = "15-11-2021";
            Appt5.Doctor = DocRec5;
            Appt5.Patient = PatRec5;
            Appt5.Prescription = Pres5;

            dbContext.Appointments.Add(Appt1);
            dbContext.Appointments.Add(Appt2);
            dbContext.Appointments.Add(Appt3);
            dbContext.Appointments.Add(Appt4);
            dbContext.Appointments.Add(Appt5);
            dbContext.SaveChanges();



            //    // READ operation
            //    Company CompanyRead1 = dbContext.Companies
            //                            .Where(c => c.Id == "MCOB")
            //                            .First();

            //    Company CompanyRead2 = dbContext.Companies
            //                            .Include(c => c.Quotes)
            //                            .Where(c => c.Id == "MCOB")
            //                            .First();

            //    // UPDATE operation
            //    CompanyRead1.iexId = "MCOB";
            //    dbContext.Companies.Update(CompanyRead1);
            //    //dbContext.SaveChanges();
            //    await dbContext.SaveChangesAsync();

            //    // DELETE operation
            //    dbContext.Companies.Remove(CompanyRead1);
            //    await dbContext.SaveChangesAsync();

            return View();
        }
        //Query 1: List the first and last names of all the patients in the database.
        public ViewResult GetAllPatients()
        {

            var query1 = from pat in dbContext.Patients
                               select new { pat.fname, pat.lname };
            return View(query1);
        }
        //Query 2: List the first and last name of the patients who consulted a particular doctor on a given date (Ex: doctor name: “John Smith”, Date: “2021-08-01”).
        public ViewResult GetPatientsConsultingADoctor()
        {

            var query2 = from a in dbContext.Appointments
                         where a.Doctor.doctorID == 5 && a.apptdate == "15-11-2021"
                         select new { a.Patient.fname, a.Patient.lname };
            return View(query2);
        }

        //Query 3: List names of the Generic medicine’s names along with its brand name and price which has unit price greater than $100. (Note: Brand name is the manufacturing company of that medicine).

        public ViewResult GenericMed()
        {
            var query3 = from m in dbContext.Medicines
                         where m.price > 100
                         select new { m.medName, m.Brand.brandName };
            return View(query3);
        }
        //public ViewResult GetMedicineRecords(int Price, Boolean GenericCategory)
        //{
        //    var MedicineRecord = (from Med in dbContext.Medicine

        //                          where Med.Price >= 100 and Med.isGeneric == GenericCategory
        //        select  new { Med.Name, Med.BrandName, Med.Price }).ToList();
        //    return View(MedicineRecord);
        //}

        //Query 4: List the top 5 doctors first and last names along with number of patients visited them, who as the highest patient count.
        public ViewResult GetTopPatientsCount()
        {
            var query4 = from app in dbContext.Appointments
                         join doc in dbContext.Doctors
                         on app.Doctor.doctorID equals doc.doctorID
                         join pt in dbContext.Patients
                         on app.Patient.patientID equals pt.patientID
                         select new{ doc.docFname,doc.docLname};

           // var docs = dbContext.Doctors.OrderBy(doc => doc.Patient.Count).Take(5);
            return View(query4);
        }

        // Query 5: For a given patient list of all doctors first and last names he visited(Ex: name: ‘John’).
        public ViewResult doc_data()
        {



            var query5 = from a in dbContext.Appointments
                         where (a.Patient.fname == "Monica" && a.Patient.lname=="Geller")
                         select new { a.Doctor.docFname, a.Doctor.docLname };
            return View(query5);
        }

        public ViewResult GetDocNames()
        {
            var query6 = from m in dbContext.Medicines
                         join pr in dbContext.Prescriptions
                         on m.medID equals pr.Medicine.medID
                         join appt in dbContext.Appointments
                         on pr.presID equals appt.Prescription.presID
                         join pat in dbContext.Patients
                         on appt.Patient.patientID equals pat.patientID
                         join d in dbContext.Doctors
                         on appt.Doctor.doctorID equals d.doctorID
                         where (m.medName == "Lyrica")

                         select new { d.docFname, d.docLname };



            return View(query6);



        }

        public ViewResult DocCountres()
        {
            var query4 = from a in dbContext.Appointments
                         group a by a.Doctor.doctorID into docGroup
                         select new
         
                         {
                             doctorID = docGroup.Key,
                             Count = docGroup.Count(),
                             
                         } ;

            return View(query4);
        }

        public ViewResult GetTopPatientsCount1()
        {
            var query4 = (from app in dbContext.Appointments
                          join doc in dbContext.Doctors
                          on app.Doctor.doctorID equals doc.doctorID
                          join pt in dbContext.Patients
                          on app.Patient.patientID equals pt.patientID
                          group doc by new { doc.doctorID, doc.docFname, doc.docLname } into res
                          select new
                          {
                              DocName = res.Key.docFname
                          ,
                              lname = res.Key.docLname
                          ,
                              pcnt = res.Count()
                          });
            return View(query4);
          
        }
        //public viewresult gettoppatientscount()
        //{
        //   var toppatientsdoctorsrecord = (from pr in dbcontext.prescriptions
        //                                  join dt in dbcontext.doctors on pr.doctorid == dt.doctorid
        //                   join pt in dbcontext.patient on pr.patientid == pt.patientid
        //                   group by dt.doctorid
        //      select  new { dt.firstname, dt.lastname, count(pt.patientid) }).tolist().take(5);
        //    return view(toppatientsdoctorsrecord);
        //}
        //Query 6: List all the doctor first and last names who have prescribed a given medicine to their patients (Ex: medicine name: “Molnupiravir”).
        //public ViewResult DoctorsVisited()
        //{
        //    var PatientRead2 = (from d in dbContext.Doctors
        //                        join ad in dbContext.Appointments on d.doctorID = ad.doctorID
        //                   join pd in dbContext.Patients pd on pd.patientID = ad.doctorID
        //        where pd.patient_fname = 'John'
        //        select new { d.doc_fname, d.doc_lname }).ToList();
        //    return View(PatientRead2);
        //}
        // Debug.WriteLine(pat.fname + " " + pat.lname);

        //    foreach(Patient pat in dbContext.Patients)
        //{
        //    Console.WriteLine(pat.fname + " " + pat.lname);
        //}

        //    Company CompanyRead1 = dbContext.Companies
        //                                    .Where(c => c.Id == "MCOB")
        //                                    .First();

        //    Company CompanyRead2 = dbContext.Companies
        //                                    .Include(c => c.Quotes)
        //                                    .Where(c => c.Id == "MCOB")
        //                                    .First();

        //    Quote Quote1 = dbContext.Companies
        //                            .Include(c => c.Quotes)
        //                            .Where(c => c.Id == "MCOB")
        //                            .FirstOrDefault()
        //                            .Quotes
        //                            .FirstOrDefault();

        //public ViewResult GetPatientsConsultingADoctor()
        //{

        //    var query2 = from a in dbContext.Appointments
        //                 where a.Doctor.doctorID == 5 && a.apptdate == "15-11-2021"
        //                 select new { a.Patient.fname, a.Patient.lname };
        //    return View(query2);
        //}
        //Query 3: List names of the Generic medicine’s names along with its brand name and price which has unit price greater than $100. (Note: Brand name is the manufacturing company of that medicine).
        //public ViewResult GetMedicineRecords(int Price, Boolean GenericCategory)
        //{
        //    var MedicineRecord = (from Med in dbContext.Medicine

        //                          where Med.Price >= 100 and Med.isGeneric == GenericCategory
        //        select  new { Med.Name, Med.BrandName, Med.Price }).ToList();
        //    return View(MedicineRecord);
        //}

        //  //Query 4: List the top 5 doctors first and last names along with number of patients visited them, who as the highest patient count.
        //public viewresult gettoppatientscount()
        //{
        //    var toppatientsdoctorsrecord = (from pr in dbcontext.prescriptions
        //                                    join dt in dbcontext.doctors on pr.doctorid == dt.doctorid
        //                    join pt in dbcontext.patient on pr.patientid == pt.patientid
        //                    group by dt.doctorid
        //        select  new { dt.firstname, dt.lastname, count(pt.patientid) }).tolist().take(5);
        //    return view(toppatientsdoctorsrecord);
        //}


        //public ViewResult patient_details()
        //{
        //    var sample = from md in dbContext.Medicines // outer sequence
        //                 join bd in dbContext.Brands //inner sequence
        //                 on md.Brand equals bd.brandID // key selector
        //                 select new
        //                 {
        //                     md.medName,
        //                     bd.brandName
        //                 };
        //    return View(sample);
        //}
        //public ViewResult patient_details()
        //{
        //    var res = from ad in dbContext.Appointments
        //              where ad.Doctor.doctorID == 1
        //              select new { ad.Patient.fname };
        //    return View(res);
        //}

        ////Query-6
        //public ViewResult DocswhopresbMed()
        //{
        //    var doc_details = (from d in dbContext.Doctors
        //                       where d.Appointments.Prescriptions.Medicines.medName == 'Zjj'
        //                       select new { d.docFname, d.docLname }).ToList();
        //    return View(doc_details);
        //}
        //public ViewResult DocswhopresbMedicien()
        //{
        //    var rec = dbContext.Doctors
        //        .Include(c => dbContext.Patients)

        //        .Where(c => dbContext.Patients.fname == "Ross")
        //        .Where(c => c.lname == "Geller");

        //    return View(rec);
        //}
        //}
    }
}

