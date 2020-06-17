using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.Impl;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Tests
{
    class TestDiseaseRepository
        : BaseRepository<Disease>
        {
        public TestDiseaseRepository(DbContext context)
            : base(context)
            {
            }
        }
}