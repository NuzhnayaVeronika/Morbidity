using System;
using System.Collections.Generic;
using System.Text;

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