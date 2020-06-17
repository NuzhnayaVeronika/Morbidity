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
    }
}