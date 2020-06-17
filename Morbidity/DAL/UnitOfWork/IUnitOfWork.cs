using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IPrognosisRepository Prognos { get; }
        public IDiseaseRepository Diseases { get; }
        void Save();
    }
}