using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class PrognosisContext
        : DbContext
    {
        public DbSet<Prognosis> Prognos { get; set; }
        internal DbSet<Disease> Diseases { get; set; }

        public PrognosisContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}