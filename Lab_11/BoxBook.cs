using System.Collections.Generic;

namespace Lab_11
{
    public class BoxBook
    {
        delegate List<Book> DelegateListBook(List<Book> books);
        public List<Book> MyProperty { get; set; }
    }
}
