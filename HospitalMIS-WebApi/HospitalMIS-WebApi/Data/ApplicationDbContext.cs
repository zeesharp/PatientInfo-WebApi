using HospitalMIS_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalMIS_WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() :
          base("HospitalMisConnectionString")
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<PatientInfo> PatientInfo { get; set; }
    }
}