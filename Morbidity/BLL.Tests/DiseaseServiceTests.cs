using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using CCL.Security;
using CCL.Security.Identity;
using Moq;
using Xunit;
using System.Linq;

namespace BLL.Tests
{
    public class DiseaseServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            //Arrange
            IUnitOfWork nullUnitOfWork = null;

            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new DiseaseService(nullUnitOfWork));
        }

        [Fact]
        public void GetDiseases_UserIsAnalyst_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Analyst("test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IDiseaseService diseaseService = new DiseaseService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => diseaseService.GetDiseases(0));
        }

        [Fact]
        public void GetDiseases_DiseaseFromDAL_CorrectMappingToDiseaseDTO()
        {
            // Arrange
            User user = new Researcher("test", 1);
            SecurityContext.SetUser(user);
            var diseaseService = GetDiseaseService();

            // Act
            var actualDiseaseDto = diseaseService.GetDiseases(0).First();

            // Assert
            Assert.True(
                actualDiseaseDto.ID == 1
                && actualDiseaseDto.Name == "testName"
                );
        }

        IDiseaseService GetDiseaseService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedDisease = new Disease() {ID = 1, Name = "testName"};
            var mockDbSet = new Mock<IDiseaseRepository>();
            mockDbSet.Setup(z => 
                z.Find(
                    It.IsAny<Func<Disease,bool>>(), 
                    It.IsAny<int>(), 
                    It.IsAny<int>()))
                  .Returns(
                    new List<Disease>() { expectedDisease }
                    );
            mockContext
                .Setup(context =>
                    context.Diseases)
                .Returns(mockDbSet.Object);

            IDiseaseService diseaseService = new DiseaseService(mockContext.Object);

            return diseaseService;
        }
    }
}