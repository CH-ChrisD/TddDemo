using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.Net.Http.Json;
using System.Text.Json;
using TddDemo.Domain;

namespace TddDemo.Test.Integration
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    internal class BookApiTests
    {
        private WebApplicationFactory<Program> _factory = null!;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [TearDown]
        public void TearDown()
        {
            _factory.Dispose();
            _factory = null!;
        }

        [Test]
        public async Task HelloWorld_Works()
        {
            // Demo test showing how to call the hello world endpoint
            // Arrange
            using var httpClient = _factory.CreateClient();

            // Act
            var response = await httpClient.GetAsync("/hello_world");

            // Assert
            var result = await response.Content.ReadAsStringAsync();
            result.Should().BeEquivalentTo("Hello World!");
        }

        [Test]
        public async Task WhenISearchForAuthorJohnSteinbeck_ThenIShouldSeeBookOfMiceAndMen()
        {
            // Arrange
            var mobyDick = new Book
            {
                Title = "Moby Dick",
                Author = "Herman Melville",
                PublicYear = 1851,
            };
            var ofMiceAndMen = new Book
            {
                Title = "Of Mice and Men",
                Author = "John Steinbeck",
                PublicYear = 1937,
            };

            var books = new List<Book>
            {
                mobyDick,
                ofMiceAndMen
            };

            using var httpClient = _factory.CreateClient();

            var response = await httpClient.PostAsJsonAsync("/add_books", books);
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            // Act
            var searchQuery = new SearchQuery()
            {
                Author = "John Steinbeck"
            };
            var result = await httpClient.PostAsJsonAsync("/books", searchQuery);

            // Assert 
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            var resultJson = await result.Content.ReadAsStringAsync();
            var booksResult = JsonSerializer.Deserialize<Book[]>(resultJson);

            booksResult.Should().Contain(book => book.Title == "Of Mice and Men");
        }
    }
}
