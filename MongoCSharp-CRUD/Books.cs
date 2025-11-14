using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCSharp_CRUD
{
    public class Books
    {
        public Books() { }
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string AuthorId { get; private set; }
        public int Year { get; private set; }
        
        public void CreateBook() 
        { }

        public void ReadBook()
        { }

        public void UpdateBook()
        { }

        public void DeleteBook()
        { }

    }
}
