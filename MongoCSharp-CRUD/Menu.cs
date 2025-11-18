using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCSharp_CRUD
{
    public class Menu
    {

        public static int MainMenu()
        {
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

        public static int CreatMenu() 
        {
            Console.Clear();
            int option;
            bool isInt;
            do
            {

                Console.WriteLine(" =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                                  "|            CRIAR LIVRO            |\n" +
                                  " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                                  "|    Selecione a opção desejada:    |\n" +
                                  "|1 - Criar Autor                    |\n" +
                                  "|2 - Criar Livro                    |\n" +
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

        public static int ReadMenu() 
        {
            Console.Clear();
            int option;
            bool isInt;
            do
            {

                Console.WriteLine(" =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                                  "|          CONSULTAR LIVRO          |\n" +
                                  " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                                  "|    Selecione a opção desejada:    |\n" +
                                  "|1 - Consultar Autores              |\n" +
                                  "|2 - Consultar Livros               |\n" +
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

        public static (int, ObjectId) DeleteMenu()
        {
            Console.Clear();
            int option;
            bool isInt, IdIsValid;
            ObjectId id = ObjectId.Empty;

            do
            {

                Console.WriteLine(" =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                                  "|           DELETAR LIVRO           |\n" +
                                  " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                                  "|    Selecione a opção desejada:    |\n" +
                                  "|1 - Deletar Autor                  |\n" +
                                  "|2 - Deletar Livro                  |\n" +
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

            if(option == 1) 
            {
                Console.Write("Informe o Id do Autor: ");
                IdIsValid = ObjectId.TryParse(Console.ReadLine()!, out id);

                if (IdIsValid == false)
                {
                    Console.WriteLine("Id inválida, a Id deve conter 24 caracteres hexadecimais\n");
                    Console.ReadKey();
                    Menu.MainMenu();
                }

            }
            if(option == 2) 
            {
                Console.Write("Informe o Id do Livro: ");
                IdIsValid = ObjectId.TryParse(Console.ReadLine()!, out id);

                if (IdIsValid == false)
                {
                    Console.WriteLine("Id inválida, a Id deve conter 24 caracteres hexadecimais\n");
                    Console.ReadKey();
                    Menu.MainMenu();
                }
            }

            return (option, id);
        }

        public static void Finish() 
        {
            Console.WriteLine(" =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" +
                              "|   ENCERRANDO SUA BIBLIOTECA...   |\n" +
                              " =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n"
               );
        }

    }
}
