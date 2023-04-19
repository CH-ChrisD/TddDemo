namespace TddDemo.Domain
{
    public interface IBookService
    {
        bool TrySaveBooks(IEnumerable<Book> books);
    }
}
