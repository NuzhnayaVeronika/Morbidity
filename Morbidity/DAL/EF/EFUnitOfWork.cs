using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private PrognosisContext db;
        private PrognosisRepository prognosisRepository;
        private DiseaseRepository diseaseRepository;

        public EFUnitOfWork(PrognosisContext context)
        {
            db = context;
        }
        public IPrognosisRepository Prognos
        {
            get
            {
                if (prognosisRepository == null)
                    prognosisRepository = new PrognosisRepository(db);
                return prognosisRepository;
            }
        }

        public IDiseaseRepository Diseases
        {
            get
            {
                if (diseaseRepository == null)
                    diseaseRepository = new DiseaseRepository(db);
                return diseaseRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
