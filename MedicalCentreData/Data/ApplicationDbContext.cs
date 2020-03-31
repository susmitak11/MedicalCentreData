using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MedicalCentreData.Models;

namespace MedicalCentreData.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MedicalCentreData.Models.PatientsData> PatientsData { get; set; }
        public DbSet<MedicalCentreData.Models.DoctorData> DoctorData { get; set; }
        public DbSet<MedicalCentreData.Models.Attendance> Attendance { get; set; }
        public DbSet<MedicalCentreData.Models.AppointmentData> AppointmentData { get; set; }
    }
}
