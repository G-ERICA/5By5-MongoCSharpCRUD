using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MongoCSharp_CRUD
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Title { get; private set; }
        public ObjectId AuthorId { get; private set; }
        public int Year { get; private set; }
        public Author Author { get; private set; }
        public static MongoDBConnection _mongoConnection = new MongoDBConnection();

        public Book(string title,ObjectId authorId, int year) 
        {
            Title = title;
            AuthorId = authorId;
            Year = year;
        }

        public static (string, ObjectId, int) CreatBook()
        {
            Console.Clear();

            Console.WriteLine(" =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                              "|         REGISTRO DE LIVRO         |\n" +
                              " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n"
            );

            Console.Write("Informe o título do livro: ");
            string title = Console.ReadLine()!;

            while (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Título não pode ser vazio\n" +
                    "Informe o título do livro ou tecle 0 para retornar e cancelar a operação");
                title = Console.ReadLine()!;
            }
            if (title == "0")
            {
                Menu.MainMenu();
            }

            bool isInt;
            int year;
            do
            {
                Console.Write("Informe o ano de publicação do livro: ");
                isInt = int.TryParse(Console.ReadLine()!, out year);
                
                if (isInt == false)
                {
                    Console.WriteLine("Ano não pode conter letras ou caracteres especiais\n" +
                        "Informe o ano ou tecle 0 para retornar e cancelar a operação");
                }
                if (year == 0)
                {
                    Menu.MainMenu();
                }

            } while (isInt == false);

            ObjectId authorId;
            bool authorIdIsValid, isValid = false;

            do
            {
                Console.Write("Informe o Id do Autor: ");
                authorIdIsValid = ObjectId.TryParse(Console.ReadLine()!, out authorId);

                if(authorIdIsValid == false) 
                {
                    Console.WriteLine("Id inválida, a Id deve conter 24 caracteres hexadecimais\n");
                }
                else 
                {
                    isValid = _mongoConnection.AuthorExist(authorId);
                    if(isValid == false) 
                    {
                        Console.WriteLine("Id do Autor não encontrada" +
                        "Pessione qualquer tecla para tentar novamente ou 0 para retornar e cancelar a operação");
                        var key = Console.ReadKey();
                    
                        if ( key.KeyChar == '0')
                        {
                            Menu.MainMenu();
                        }
                    }
                }
                    

            } while (authorIdIsValid == false || isValid == false);


            return (title, authorId, year);
        }   
        public static (string, int) UpdateBook()
        {
            Console.Write("Informe o Id do Livro: ");
            string id = Console.ReadLine()!;

            bool isInt;
            int year;
            do
            {
                Console.Write("Informe o ano de publicação do livro: ");
                isInt = int.TryParse(Console.ReadLine()!, out year);

                if (isInt == false)
                {
                    Console.WriteLine("Ano não pode conter letras ou caracteres especiais\n" +
                        "Informe o ano ou tecle 0 para retornar");
                }
                if (year == 0)
                {
                    Menu.EditMenu();
                }

            } while (isInt == false);

            return (id, year);
        }
        public override string ToString()
        {
            return $"Id:{Id} \nTítulo:{Title} \nAno de Publicação:{Year} \nId Autor:{AuthorId} \nAutor:{Author.Name} \nPais do Autor:{Author.Country}";
        }
    }
}
