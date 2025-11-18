using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ZstdSharp.Unsafe;

namespace MongoCSharp_CRUD
{
    public  class MongoDBConnection
    {
        public string ConnectionString { get; private set; } = String.Empty;

        private readonly IMongoDatabase _database;
        
        public Author author;
        public Book book;

        public MongoDBConnection() 
        {
            var atividadeMongo = new MongoClient(MongoDBConnection.GetConnectionString());
            _database = atividadeMongo.GetDatabase("Biblioteca");

        }

        public static string GetConnectionString() 
        {
            return "mongodb+srv://**:**@**.mongodb.net/";
        }

        public IMongoCollection<Author> Authors
        => _database.GetCollection<Author>("Authors");

        public IMongoCollection<Book> Books
            => _database.GetCollection<Book>("Books");

        public async Task Creat() 
        {
            int option = Menu.CreatMenu();

            if (option == 1)
            {
                var (name, country) = Author.CreatAuthor();
                author = new Author(name, country);
               await _database.GetCollection<Author>("Authors").InsertOneAsync(author);
            }

            if (option == 2)
            {
                var (title, authorId, year) = Book.CreatBook();
                book = new Book(title, authorId, year);
                await _database.GetCollection<Book>("Books").InsertOneAsync(book);
            }
        }

        public async Task Edit() 
        {
            int option = Menu.EditMenu();

            if (option == 1)
            {
                var (id, country) = Author.UpdateAuthor();

                await _database.GetCollection<Author>("Authors").UpdateOneAsync(
                    x => x.Id == id,
                    Builders<Author>.Update.Set(x => x.Country, country)
                );
            }
            if (option == 2)
            {
                var (id, year) = Book.UpdateBook();

                await _database.GetCollection<Book>("Books").UpdateOneAsync(
                    x => x.Id == id,
                    Builders<Book>.Update.Set(x => x.Year, year)
                );
            }
        }

        public async Task Read() 
        {
            int option = Menu.ReadMenu();

            if (option == 1)
            {
                var searchAuthor = await _database.GetCollection<Author>("Authors").Find(a => true).ToListAsync();
                foreach (var author in searchAuthor)
                {
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    Console.WriteLine(author);
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    Console.WriteLine("\n\n");
                    Console.ReadKey();
                }
                if(searchAuthor.Count == 0) 
                {
                    Console.WriteLine("A lista está vazia!");
                }
                Console.ReadKey();
            }
        

            if (option == 2)
            {
                var searchBook = await _database.GetCollection<Book>("Books").Aggregate()
                .Lookup<Book, Author, Book>(
                    _database.GetCollection<Author>("Authors"),
                    book => book.AuthorId,
                    author => author.Id,
                    book => book.Author
                    )
                .Unwind<Book, Book>(book => book.Author).ToListAsync();

                foreach (var item in searchBook)
                {
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    Console.WriteLine(item);
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    Console.WriteLine("\n\n");
                    Console.ReadKey();
                }
                if (searchBook.Count == 0)
                {
                    Console.WriteLine("A lista está vazia!");
                }
                Console.ReadKey();
            }
        }

        public async Task Delete() 
        {
            var (id, ObjectId) = Menu.DeleteMenu();

            if (id == 1)
            {
                await _database.GetCollection<Author>("Authors").DeleteOneAsync(a => a.Id == ObjectId.ToString());
            }
            else
            {
                await _database.GetCollection<Book>("Books").DeleteOneAsync(b => b.Id == ObjectId.ToString());
            }
        }

        public bool AuthorExist(ObjectId id) 
        {
            bool authorExists = false;
            
            var searchAuthor = _database.GetCollection<Author>("Authors").Find(a => a.Id == id.ToString()).FirstOrDefault();
            if (searchAuthor != null)
            {
                authorExists = true;
            }
            return authorExists;
        }

    }
}
