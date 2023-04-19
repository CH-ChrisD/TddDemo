namespace TddDemo.Domain
{
    public class BookService : IBookService
    {
        public bool TrySaveBooks(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                if (string.IsNullOrEmpty(book.Author)
                    || string.IsNullOrEmpty(book.Title))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
