using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCentreData.Models
{
    public class AppointmentData
    {
        //used for the primary key in the table that is unique
        [Key]
        //these are the columns name
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Detail { get; set; }
        //this is the foreign key contraint in the table that comes from the patient table
        public bool Status { get; set; }
        [ForeignKey("PatientsData")]
        public int PatientId { get; set; }
        //this is the foreign key contraint in the table that comes from the Doctor table
        public PatientsData patient { get; set; }
        [ForeignKey("DoctorData")]
        public int DoctorId { get; set; }
        public DoctorData doctor { get; set; }
    }
}
