using TddDemo.Domain;

namespace TddDemo.Web.Endpoints
{
    internal class Books
    {
        private IBookService _bookService;

        internal const string Name = nameof(Books);
        internal const string Path = "/books";

        public Books(IBookService bookService)
        {
            _bookService = bookService;
        }

        internal async Task<string> HelloWorld()
        {
            await Task.Delay(100);
            return "Hello world!";
        }

        internal async Task<Response> CreateBooks(IEnumerable<Book> books)
        {
            if (!books.Any())
            {
                return new Response()
                {
                    Status = Statuses.NotFound
                };
            }

            if (_bookService.TrySaveBooks(books))
            {
                return new Response()
                {
                    Status = Statuses.Successful
                };
            }

            return new Response()
            {
                Status = Statuses.Unsuccessful
            };
        }
    }
}
