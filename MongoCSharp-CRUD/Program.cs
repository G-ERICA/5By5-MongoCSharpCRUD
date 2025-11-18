
/*AVISO!!! Antes de iniciar o program acessa a classe: MongoDBConnection e altere a informação que consta na linha 31
 Informe sua connection string para prosseguir*/

using MongoCSharp_CRUD;

MongoDBConnection newConnection = new MongoDBConnection();



int option;

do
{
    Console.Clear();
    option = Menu.MainMenu();

    switch (option)
    {
        case 1:
            newConnection.Creat();
            break;
        case 2:
            newConnection.Edit();
            break;
        case 3:
            newConnection.Read();                     
            break;
        case 4:
            newConnection.Delete();
            break;
        case 5:
            Menu.Finish();
            break;
    }
} while (option > 0 && option < 5);