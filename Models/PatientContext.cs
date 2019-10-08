using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCore.Models
{
    public class PatientContext : DbContext
    {


        public PatientContext(DbContextOptions<PatientContext> options) : base(options)
        {

        }
        public DbSet<Patient> patients { get; set; }
    }
}
