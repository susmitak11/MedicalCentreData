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
        [Key]
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
        [ForeignKey("PatientsData")]
        public int PatientId { get; set; }
        public PatientsData patient { get; set; }
        [ForeignKey("DoctorData")]
        public int DoctorId { get; set; }
        public DoctorData doctor { get; set; }
    }
}
