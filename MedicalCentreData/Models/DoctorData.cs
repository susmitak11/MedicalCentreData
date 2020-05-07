using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCentreData.Models
{[Authorize]
    public class DoctorData
    {

        //used for the primary key in the table that is unique
        [Key]
        //these are the fields that need to be filled while entering the doctor data
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsAvailable { get; set; }
        public string Address { get; set; }
        
        public string Specialization { get; set; }
       
        

    }
}
