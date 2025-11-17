using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCSharp_CRUD
{
    public class Menu
    {

        public Author Autor;

        public Book Livro;



        public static int MainMenu()
        {
            Console.Clear();
            int option;
            bool isInt;
            do {
                Console.WriteLine(" =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                                  "|           MENU INICIAL            |\n" +
                                  " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                                  "|    Selecione a opção desejada:    |\n" +
                                  "|1 - Registrar Livro                |\n" +
                                  "|2 - Editar Livro                   |\n" +
                                  "|3 - Consultar Livro                |\n" +
                                  "|4 - Deletar Livro                  |\n" +
                                  "|5 - Encerrar Programa              |\n" +
                                  " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n"
                );
                isInt = int.TryParse(Console.ReadLine(), out option);
                
                if (option < 1 || option > 5)
                {
                    Console.Clear();
                    Console.WriteLine("Opção não encontrada\n\n");
                }

            } while (option < 1 || option > 5 || isInt == false);


            Console.Clear();

            return option;
        }


        public static int EditMenu() 
        {
            Console.Clear();
            int option;
            bool isInt;
            do
            {

                Console.WriteLine(" =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n"  +
                                  "|            EDITAR LIVRO           |\n" +
                                  " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n"  +
                                  "|    Selecione a opção desejada:    |\n" +
                                  "|1 - Editar Autor (Pais)            |\n" +
                                  "|2 - Editar Livro (Ano Publicação)  |\n" +
                                  "|0 - Voltar                         |\n" +
                                  " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n"
                );
                isInt = int.TryParse(Console.ReadLine(), out option);

                if (option < 0 || option > 2)
                {
                    Console.Clear();
                    Console.WriteLine("Opção não encontrada\n\n");
                }
                if(option == 0) 
                {
                    MainMenu();
                }

            } while (option < 1 || option > 2 || isInt == false);

            return option;
        } 

        public static int SearchMenu() 
        {
            Console.Clear();

            int option;
            bool isInt;
            do
            {

                Console.WriteLine(" =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n"  +
                                  "|          CONSULTAR LIVRO          |\n" +
                                  " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n"  +
                                  "|    Selecione a opção desejada:    |\n" +
                                  "|1 - Consultar Autores              |\n" +
                                  "|2 - Consultar Livros               |\n" +
                                  "|3 - Consultar Todos                |\n" +
                                  "|0 - Voltar                         |\n" +
                                  " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n"
                );
                isInt = int.TryParse(Console.ReadLine(), out option);

                if (option < 0 || option > 2)
                {
                    Console.Clear();
                    Console.WriteLine("Opção não encontrada\n\n");
                }
                if (option == 0)
                {
                    MainMenu();
                }

            } while (option < 1 || option > 2 || isInt == false);

            return option;
        }

    }
}
