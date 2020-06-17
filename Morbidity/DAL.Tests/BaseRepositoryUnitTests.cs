using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DAL.Repositories.Impl;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Xunit;
using Moq;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputDiseaseInstance_CalledAddMethodOfDBSetWithDiseaseInstance()
        {
            //Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<PrognosisContext>()
                .Options;
            var mockContext = new Mock<PrognosisContext>(opt);
            var mockDbSet = new Mock<DbSet<Disease>>();
            mockContext
                .Setup(context => 
                    context.Set<Disease>(
                        ))
                .Returns(mockDbSet.Object);
            var repository = new TestDiseaseRepository(mockContext.Object);
            Disease expectedDisease = new Mock<Disease>().Object;

            //Act
            repository.Create(expectedDisease);

            //Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedDisease
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<PrognosisContext>()
                .Options;
            var mockContext = new Mock<PrognosisContext>(opt);
            var mockDbSet = new Mock<DbSet<Disease>>();
            mockContext
                .Setup(context =>
                    context.Set<Disease>(
                        ))
                .Returns(mockDbSet.Object);

            Disease expectedDisease = new Disease() { ID = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedDisease.ID))
                    .Returns(expectedDisease);
            var repository = new TestDiseaseRepository(mockContext.Object);

            //Act
            var actualDisease = repository.Get(expectedDisease.ID);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedDisease.ID
                    ), Times.Once());
            Assert.Equal(expectedDisease, actualDisease);
        }
    }
}