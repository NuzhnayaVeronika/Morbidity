using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using CCL.Security;
using CCL.Security.Identity;
using AutoMapper;

namespace BLL.Services.Impl
{
    public class DiseaseService
        :IDiseaseService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public DiseaseService( 
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<DiseaseDTO> GetDiseases(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Director)
                && userType != typeof(Researcher))
            {
                throw new MethodAccessException();
            }
            var diseasesEntities = 
                _database
                    .Diseases
                    .Find(z => z.ID == pageNumber, pageSize);
            var mapper = 
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Disease, DiseaseDTO>()
                    ).CreateMapper();
            var diseasesDto = 
                mapper
                    .Map<IEnumerable<Disease>, List<DiseaseDTO>>(
                        diseasesEntities);
            return diseasesDto;
        }
    }
}