using NUnit.Framework;
using TddDemo.Domain;
using TddDemo.Web.Endpoints;

namespace TddDemo.Test.Unit
{
    [TestFixture]
    internal class BooksEndpointTests
    {
        [Test]
        public async Task CreateBooks_GivenAnEmptyCollection_ShouldNotThrow()
        {
            // Arrange
            var emptyCollection = Array.Empty<Book>();

            var endpoint = new Books();

            // Assert 
            Assert.DoesNotThrowAsync(endpoint.CreateBooks);
        }

        [Test]
        public async Task CreateBooks_GivenSomeBooks_SavesThoseBooks()
        {
            // Arrange


            // Act

            // Assert 
        }
    }
}
