
//Inicializando e Configurando o MongoDB

using MongoCSharp_CRUD;
using MongoDB.Driver;
using MongoDB.Driver.Search;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Transactions;
using System.Xml.Linq;

var atividadeMongo = new MongoClient("mongodb+srv://ericagf21_db_user:QXlhq9YF6qkZCXSU@interacao.pgeg0fw.mongodb.net/");

var database = atividadeMongo.GetDatabase("Biblioteca");

var collectionAuthors = database.GetCollection<Author>("Authors");
var collectionBooks = database.GetCollection<Book>("Books");


//Menu e CRUD no MongoDB
string name = "", country = "";
Author author = new Author(name, country);

string title = "", id = "";
int year = 0;
Book book = new Book(title,id,year);

int option;

do
{
    option = Menu.MainMenu();

    switch (option)
    {
        case 1:
            var (name1, country1) = Author.CreatAuthor();
            author = new Author(name1, country1);
            collectionAuthors.InsertOne(author);

            var authorCreated = collectionAuthors.Find(i => i.Name == name1).FirstOrDefault();
            string idAuthor = authorCreated.Id.ToString();

            var (title1, year2) = Book.CreatBook();
            book = new Book(title1, idAuthor, year2);
            collectionBooks.InsertOne(book);
            break;
        case 2:
            option = Menu.EditMenu();

            if(option == 1) 
            {
                var (id1, country2) = author.UpdateAuthor();

                collectionAuthors.UpdateOne(
                    x => x.Id == id1,
                    Builders<Author>.Update.Set(x => x.Country, country2)
                );
            }
            if(option == 2) 
            {
                var (id2, year3) = book.UpdateBook();

                collectionBooks.UpdateOne(
                    x => x.Id == id2,
                    Builders<Book>.Update.Set(x => x.Year, year3)
                );
            }
            break;
        case 3:
            option = Menu.SearchMenu();

            if (option == 1)
            {
                var autores = collectionAuthors.Find(_ => true).ToList();

                foreach (var autor in autores)
                {
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    Console.WriteLine(autor);
                }
            }
            if (option == 2) 
            {
                var livros = collectionBooks.Find(_ => true).ToList();

                foreach (var livro in livros)
                {
                    Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                    Console.WriteLine(livro);
                }
            }


            break;
        case 4:
            Console.WriteLine(" =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                              "|          DELETAR LIVRO            |\n" +
                              " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n"
            );

            break;
        case 5:

            Console.WriteLine(" =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                              "|   ENCERRANDO SUA BIBLIOTECA...   |\n" +
                              " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n"
            );
            break;
    }
} while (option > 0 && option < 5);