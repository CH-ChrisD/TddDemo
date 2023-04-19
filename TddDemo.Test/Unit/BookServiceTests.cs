using FluentAssertions;
using NUnit.Framework;
using TddDemo.Domain;

namespace TddDemo.Test.Unit
{
    [TestFixture]
    internal class BookServiceTests
    {
        [Test]
        public void TrySaveBooks_GivenAListContainingAnInvalidBooks_ReturnsFalse()
        {
            // Arrange
            var validBook = new Book()
            {
                Author = "some author",
                Title = "some title"
            };
            var invalidBook = new Book()
            {
                Author = string.Empty,
                Title = string.Empty,
            };

            var books = new List<Book>()
            {
                validBook,
                invalidBook
            };

            // Act
            var systemUnderTest = new BookService();
            var result = systemUnderTest.TrySaveBooks(books);

            // Assert 
            result.Should().Be(false);
        }

        [Test]
        public void TrySaveBooks_GivenAListContainingOnlyValidBooks_ReturnsTrue()
        {
            var validBook1 = new Book()
            {
                Author = "some author",
                Title = "some title"
            };

            var validBook2 = new Book()
            {
                Author = "another author",
                Title = "another title"
            };

            var books = new List<Book>()
            {
                validBook1,
                validBook2
            };

            // Act
            var systemUnderTest = new BookService();
            var result = systemUnderTest.TrySaveBooks(books);

            // Assert 
            result.Should().Be(true);
        }
    }
}
