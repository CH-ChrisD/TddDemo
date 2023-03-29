namespace TddDemo.Web.Endpoints
{
    internal class Books
    {
        internal const string Name = nameof(Books);
        internal const string Path = "/books";

        internal async Task<string> HelloWorld()
        {
            await Task.Delay(100);
            return "Hello world!";
        }

        internal async Task CreateBooks()
        {
            throw new NotImplementedException();
        }
    }
}
