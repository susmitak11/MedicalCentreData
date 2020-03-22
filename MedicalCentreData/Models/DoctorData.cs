using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCentreData.Models
{
    public class DoctorData
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsAvailable { get; set; }
        public string Address { get; set; }
        public int SpecializationId { get; set; }
        public string Specialization { get; set; }
        public int PhysicianId { get; set; }
        public string Physician { get; set; }

    }
}
