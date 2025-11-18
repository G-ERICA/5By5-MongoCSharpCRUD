using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MongoCSharp_CRUD
{
    public class Author
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Country { get; private set; }
              

        public Author(string name, string country ) 
        { 
            Name = name;
            Country = country;
        }

        public static (string, string) CreatAuthor()
        {
            Console.Clear();

            Console.WriteLine(" =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                              "|         REGISTRO DE LIVRO         |\n" +
                              " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n"
            );

            Console.Write("Informe o nome do Autor: ");
            string name = Console.ReadLine()!;

            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Nome não pode ser vazio\n" +
                    "Informe o nome do Autor ou tecle 0 para retornar e cancelar a operação");
                name = Console.ReadLine()!;
            }
            if (name == "0")
            {
                Menu.MainMenu();
            }

            Console.Write("Informe o pais de origem do Autor: ");
            string country = Console.ReadLine()!;
            while (string.IsNullOrEmpty(country))
            {
                Console.WriteLine("Pais não pode ser vazio\n" +
                    "Informe o pais do Autor ou tecle 0 para retornar e cancelar a operação");
                country = Console.ReadLine()!;
            }
            if (country == "0")
            {
                Menu.MainMenu();
            }

            return (name, country);

        }
        public static (string, string) UpdateAuthor()
        {
            Console.Write("Informe o Id do Autor: ");
            string id = Console.ReadLine()!;

            Console.Write("Informe o pais de origem do Autor: ");
            string country = Console.ReadLine()!;
            while (string.IsNullOrEmpty(country))
            {
                Console.WriteLine("Pais não pode ser vazio\n" +
                    "Informe o pais do Autor ou tecle 0 para retornar");
                country = Console.ReadLine()!;
            }
            if (country == "0")
            {
                Menu.EditMenu();
            }

            return (id, country);

        }
        public void DeleteAuthor()
        { }

        public override string ToString()
        {
            return $"Id:{Id} \nNome:{Name} \nPais:{Country}";
        }

    }
}
