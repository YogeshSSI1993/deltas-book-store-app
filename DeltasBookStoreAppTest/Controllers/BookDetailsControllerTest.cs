using DeltasBookStoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using DeltasBookStoreApp.Interfaces;
using DeltasBookStoreApp.Controllers;
using DeltasBookStoreAppTest.MockData;
using Xunit;

namespace DeltasBookStoreAppTest.Controllers
{
    public class BookDetailsControllerTest
    {
        [Fact]
        public void GetAllBooks_ReturnOkStatus()
        {
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.GetBookDetails(It.IsAny<string>())).Returns(BookDetailsMock.GetBooks());
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result =  sut.Index();

            ///Assert
            result.GetType().Should().Be(typeof(ViewResult));
        }

        [Fact]
        public void GetBooks_ReturnOkStatus()
        {
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.GetBookDetails(It.IsAny<int>())).Returns(BookDetailsMock.GetBooks().FirstOrDefault());
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = sut.Edit(1);

            ///Assert
            result.GetType().Should().Be(typeof(ViewResult));
        }

        [Fact]
        public void GetBooks_ReturnNotFoundStatus()
        {
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.GetBookDetails(It.IsAny<int>())).Returns(BookDetailsMock.GetBooks().Where(x => x.Id == 0).FirstOrDefault());
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = sut.Edit(0);

            ///Assert0
            result.GetType().Should().Be(typeof(ViewResult));
        }

        [Fact]
        public void GetDeletedBookDetails_ReturnOkStatus()
        {
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.GetBookDetails(It.IsAny<string>())).Returns(BookDetailsMock.GetDeletedBooks());
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = sut.DeletedBooks();

            ///Assert
            result.GetType().Should().Be(typeof(ViewResult));
        }

        [Fact]
        public void PostBookDetails_ReturnActionResult()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.PostBookDetails(It.IsAny<BookDetails>())).Returns(1);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act & Assert
            Assert.Throws<NullReferenceException>(() => sut.Create(bookDetails));
        }

        [Fact]
        public void PostBookDetails_ReturnProblem()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.PostBookDetails(It.IsAny<BookDetails>())).Returns(99);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act & Assert
            Assert.Throws<NullReferenceException>(() => sut.Create(bookDetails));
        }

        [Fact]
        public void PutBookDetails_ReturnOk()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.PutBookDetails(It.IsAny<BookDetails>())).Returns(1);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = sut.Edit(4);

            ///Assert
            result.GetType().Should().Be(typeof(ViewResult));
        }

        [Fact]
        public void PutBookDetails_ReturnBadRequest()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.PutBookDetails(It.IsAny<BookDetails>())).Returns(1);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = sut.Edit(1);

            ///Assert
            result.GetType().Should().Be(typeof(ViewResult));
        }

        [Fact]
        public void PutBookDetails_ReturnNotFound()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.PutBookDetails(It.IsAny<BookDetails>())).Returns(99);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = sut.Edit(4);

            ///Assert
            result.GetType().Should().Be(typeof(ViewResult));
        }

        [Fact]
        public void DeleteBookDetails_ReturnOk()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.DeleteBookDetails(It.IsAny<int>())).Returns(1);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = sut.DeletedBooks();

            ///Assert
            result.GetType().Should().Be(typeof(ViewResult));
        }


        [Fact]
        public void DeleteBookDetails_ReturnProblem()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.DeleteBookDetails(It.IsAny<int>())).Returns(99);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = sut.DeletedBooks();

            ///Assert
            result.GetType().Should().Be(typeof(ViewResult));
        }

        [Fact]
        public void DeleteBookDetails_ReturnNotExist()
        {
            BookDetails bookDetails = new BookDetails { Id = 4, AuthorName = "A", BookName = "B", BookDescription = "C", IsActive = "Y", Price = 100, PublisherName = "D", TotalCopiesSold = 200, PublishedDate = DateTime.Now.ToString() };
            ///Arrange
            var mockRepository = new Mock<IBookDetailsRepository>();
            mockRepository.Setup(x => x.DeleteBookDetails(It.IsAny<int>())).Returns(1);
            var sut = new BookDetailsController(mockRepository.Object);

            ///Act
            var result = sut.DeletedBooks();

            ///Assert
            result.GetType().Should().Be(typeof(ViewResult));
        }
    }
}