using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCentreData.Models
{
    public class PatientsData
    {

        //used for the primary key in the table that is unique
        [Key]
        //these are the fields that need to be filled while entering the patientsr data
        public int Id { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        
        public string Cities { get; set; }
        
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Appointments { get; set; }
       
    


    }
}
