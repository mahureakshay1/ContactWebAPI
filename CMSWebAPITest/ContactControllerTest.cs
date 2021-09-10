using ContactWebAPI;
using ContactWebAPI.Controllers;
using ContactWebAPI.Db.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace CMSWebAPITest
{
    public class ContactControllerTest
    {

        ContactController _controller;
        IContactRepository _service;

        public ContactControllerTest()
        {
            _service = new ContactFakeRepository();
            _controller = new ContactController(_service);
        }

        #region get all

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var result = _controller.Get();
            // Assert
            var items = Assert.IsType<List<Contact>>(result);
            Assert.Equal(4, items.Count);
        }
        #endregion


        #region Get by Id

        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNull()
        {
            // Act
            var notFound = _controller.Get(100);
            // Assert
            Assert.Null(notFound);
        }
        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testid = 1;
            // Act
            var okResult = _controller.Get(testid);
            // Assert
            Assert.IsType<Contact>(okResult);
        }
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var testid = 1;
            // Act
            var result = _controller.Get(testid);
            // Assert
            Assert.Equal(testid, result.ContactId);
        }

        #endregion

        #region update
        
        
        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var testItem = new Contact() { FirstName = "Magesh2", LastName = "Tembhurne2", ContactAddress = "Talodhi tah Bramhapuri, dist Chandrapur", ContactStatus = true, Email = "mahureakshay4@gmail.com", PhoneNumber = "8888589208" };
            // Act
            var createdResponse = _controller.Add(testItem);
            // Assert
            Assert.Equal(5, createdResponse.ContactId);
        }

        #endregion

        #region set status

       
        [Fact]
        public void SetStatus_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var id = 1;
            var status = false;
            // Act
            var createdResponse = _controller.SetStatus(id, status);
            Assert.False(createdResponse.ContactStatus);
        }
        #endregion

    }
}
