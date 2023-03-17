using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

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
    }
}
