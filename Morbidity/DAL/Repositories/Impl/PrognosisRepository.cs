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
    public class PrognosisRepository
        : BaseRepository<Prognosis>, IPrognosisRepository
    {
        internal PrognosisRepository(PrognosisContext context) 
            : base(context)
        {
        }
    }
}