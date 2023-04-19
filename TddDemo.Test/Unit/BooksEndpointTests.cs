using FluentAssertions;
using Moq;
using NUnit.Framework;
using TddDemo.Domain;
using TddDemo.Web.Endpoints;

namespace TddDemo.Test.Unit
{
    [TestFixture]
    internal class BooksEndpointTests
    {
        [Test]
        public async Task CreateBooks_GivenAnEmptyCollection_ReturnsNotFoundResponse()
        {
            // Arrange
            var emptyCollection = Array.Empty<Book>();

            var mockBookService = new Mock<IBookService>();
            var endpoint = new Books(mockBookService.Object);

            // Act
            var response = await endpoint.CreateBooks(emptyCollection);

            // Assert 
            response.Status.Should().Be(Statuses.NotFound);
        }

        [Test]
        public async Task CreateBooks_GivenSomeBooks_ReturnsSuccessfulResponse()
        {
            // Arrange
            var input = GetSampleBooks();

            var mockBookService = new Mock<IBookService>();
            mockBookService
                .Setup(m => m.TrySaveBooks(input))
                .Returns(true);

            // Act
            var endpoint = new Books(mockBookService.Object);
            var response = await endpoint.CreateBooks(input);

            // Assert 
            response.Status.Should().Be(Statuses.Successful);
        }

        [Test]
        public async Task CreateBooks_ServiceFailedToSave_ReturnsUnsuccessfulResponse()
        {
            var input = GetSampleBooks();

            var mockBookService = new Mock<IBookService>();
            mockBookService
                .Setup(m => m.TrySaveBooks(input))
                .Returns(false);

            var endpoint = new Books(mockBookService.Object);
            var response = await endpoint.CreateBooks(input);

            response.Status.Should().Be(Statuses.Unsuccessful);
        }

        private static List<Book> GetSampleBooks()
        {
            return new List<Book>()
            {
                new()
                {
                    Author = "some author",
                    Title = "some title",
                },
                new()
                {
                    Author = "another author",
                    Title = "another title",
                }
            };
        }
    }
}
