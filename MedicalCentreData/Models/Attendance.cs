using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCentreData.Models
{[Authorize]
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public string ClinicRemarks { get; set; }
        public string Diagnosis { get; set; }
        public string SecondDiagnosis { get; set; }
        public string ThirdDiagnosis { get; set; }
        public string Therapy { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("PatientsData")]
        public int PatientId { get; set; }
        public PatientsData patient { get; set; }
    }
}
