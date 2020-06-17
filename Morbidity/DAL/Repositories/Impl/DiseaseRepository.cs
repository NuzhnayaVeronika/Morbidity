using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;

namespace DAL.Repositories.Impl
{
    public class DiseaseRepository
        : BaseRepository<Disease>, IDiseaseRepository
    {
        internal DiseaseRepository(PrognosisContext context) 
            : base(context)
        {
        }
    }
}