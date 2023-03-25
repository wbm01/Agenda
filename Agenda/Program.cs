using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Agenda;

internal class Program
{
    private static void Main(string[] args)
    {

        List<Contact> phonebook = new List<Contact>();
        int op;
        bool sair = false;
        char escolha2;
        string aux2;

        CarregarLista(phonebook, "agenda.txt");


        do
        {
            op = Menu();

            switch (op)
            {
                case 1:
                    phonebook.Add(CreateContact());
                    break;

                case 2:
                    ChangeContact();
                    break;

                case 3:
                    phonebook.Remove(DeleteContact());
                    break;

                case 4:
                    char escolha;
                    Console.Write("\nDeseja buscar a lista completa? Escolha S ou N: ");
                    escolha = char.Parse(Console.ReadLine());

                    if (escolha == 's' || escolha == 'S')
                    {
                        PrintPhoneBook(phonebook);
                        break;
                    }
                    else if (escolha == 'n' || escolha == 'N')
                    {
                        {
                            try
                            {

                                Console.Write("\nEscolha a letra que deseja consultar: ");
                                escolha2 = char.Parse(Console.ReadLine());
                                escolha2 = char.ToUpper(escolha2);

                                foreach (var item4 in phonebook)
                                {
                                    if (escolha2 == item4.Name[0])
                                    {
                                        PrintPhoneBookForLetter(phonebook, escolha2);
                                    }

                                }
                            }
                            catch
                            {
                                Console.WriteLine("Letra não encontrada ou caractere inválido!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Escolha apenas S ou N!");
                    }
                    break;


                case 5:
                    CriarArquivo("agenda.txt");
                    System.Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        } while (true);


        void CriarArquivo(string f)
        {

            try
            {

                if (File.Exists("agenda.txt"))
                {

                    var temp3 = LerArquivo("agenda.txt");
                    StreamWriter sw = new StreamWriter("agenda.txt");
                    for (int i = 0; i < phonebook.Count; i++)
                    {
                        sw.WriteLine(phonebook[i].ToString());
                    }

                    sw.Close();
                }
                else
                {
                    StreamWriter sw = new("agenda.txt");
                    for (int i = 0; i < phonebook.Count; i++)
                    {
                        sw.WriteLine(phonebook[i].ToString());
                    }
                    sw.Close();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERRO: Não foi possível gravar os contatos!");
            }
            finally
            {

                Thread.Sleep(1000);
                Console.WriteLine();
            }
        }

        string LerArquivo(string s)
        {
            string text = "";
            try
            {
                StreamReader sr = new StreamReader(s);
                text = sr.ReadToEnd();
                sr.Close();

            }
            catch (Exception)
            {
                Console.WriteLine("Lista vazia!");
            }
            return text;
        }

        List<Contact>CarregarLista(List<Contact>e,string s)
        {
            StreamReader sr = new StreamReader (s);

            while (!sr.EndOfStream)
            {
                string[] aux3 = sr.ReadLine().Split(",");

                string nome = aux3[0];
                string telefone = aux3[1];
                string email = aux3[2];
                string endereco = aux3[3];
                string cidade = aux3[4];
                string estado = aux3[5];
                string pais = aux3[6];
                string codigopostal = aux3[7];

                return e.Add(new Contact (nome, telefone, email));

            }
            sr.Close();
            
            return e;

        }
        void PrintPhoneBook(List<Contact> l)
        {
            foreach (var item in l)
            {
                List<Contact> listaordenada = l.OrderBy(Contact => Contact.Name).ToList();

                for (int i = 0; i < listaordenada.Count; i++)
                {
                    Console.WriteLine(listaordenada[i].ToUser());
                    Console.WriteLine();
                }
            }
        }

        void PrintPhoneBookForLetter(List<Contact> l, char escolha2)
        {
            foreach (var item5 in l)
            {
                if (escolha2 == item5.Name[0])
                {
                    Console.WriteLine(item5.ToUser());
                }
            }
        }


        int Menu()
        {

            Console.Write("\nMENU DE OPÇÕES\n\n1 - Insere Contato"
                + "\n2 - Editar Contato\n3 - Remover Contato\n4 - Mostrar agenda\n5 - Sair e Gravar\n\nEscolha uma opção: ");

            var resposta = int.Parse(Console.ReadLine());

            return resposta;
        }

        int Menu2()
        {

            Console.Write("\nMENU DE EDIÇÃO\n\n1 - Editar nome"
                + "\n2 - Editar Telefone \n3 - Editar Email\n4 - Editar Endereço\n5 - Menu Anterior\n\nEscolha uma opção: ");

            var resposta2 = int.Parse(Console.ReadLine());

            return resposta2;
        }

        Contact DeleteContact()
        {
            Console.Write("Informe o nome: ");
            var n = Console.ReadLine();

            foreach (var item in phonebook)
            {
                if (item.Name.Equals(n))
                {
                    return item;
                }
                else
                {
                    Console.WriteLine("Contato não encontrado");
                }
            }

            return null;
        }



        Contact CreateContact()
        {
            Console.Write("\nInforme o nome: ");
            string n = Console.ReadLine();
            string aux = char.ToUpper(n[0]) + n.Substring(1);


            Console.Write("\nInforme o telefone: ");
            var t = Console.ReadLine();
            Console.Write("\nInforme o email: ");
            string e = Console.ReadLine();


            Contact contact = new Contact(aux, t, e);

            Console.Write("\nInforme o endereço: ");
            contact.Address.EditStreet(Console.ReadLine());
            Console.Write("\nInforme o estado: ");
            contact.Address.EditState(Console.ReadLine());
            Console.Write("\nInforme a cidade: ");
            contact.Address.EditCity(Console.ReadLine());
            Console.Write("\nInforme o país: ");
            contact.Address.EditCountry(Console.ReadLine());
            Console.Write("\nInforme o CEP: ");
            contact.Address.EditPostalCode(Console.ReadLine());

            foreach (var item3 in phonebook)
            {
                if (contact.Name.Contains(item3.Name))
                {
                    Console.WriteLine("Nome já cadastrado, não será possível salvar!");
                    phonebook.Remove(item3);
                    return item3;
                }
            }
            return contact;
        }

        void ChangeContact()
        {
            Console.Write("\nInforme o nome para alteração: ");
            string n = Console.ReadLine();
            string aux = char.ToUpper(n[0]) + n.Substring(1);

            foreach (var item2 in phonebook)
            {
                if (item2.Name.Equals(aux))
                {
                    int op2;
                    bool retorno2 = false;
                    do
                    {
                        op2 = Menu2();


                        switch (op2)
                        {
                            case 1:
                                Console.WriteLine("Informe o nome: ");
                                string a = Console.ReadLine();
                                string aux2 = char.ToUpper(n[0]) + n.Substring(1);
                                item2.EditName(n);
                                break;

                            case 2:
                                Console.WriteLine("Informe o telefone: ");
                                n = Console.ReadLine();
                                item2.EditPhone(n);
                                break;

                            case 3:
                                Console.WriteLine("Informe o email: ");
                                n = Console.ReadLine();
                                item2.EditEmail(n);
                                break;

                            case 4:
                                Console.WriteLine("Informe o endereço: ");
                                n = Console.ReadLine();
                                item2.Address.EditStreet(n);

                                Console.WriteLine("Informe o estado: ");
                                n = Console.ReadLine();
                                item2.Address.EditState(n);

                                Console.WriteLine("Informe a cidade: ");
                                n = Console.ReadLine();
                                item2.Address.EditCity(n);

                                Console.WriteLine("Informe o país: ");
                                n = Console.ReadLine();
                                item2.Address.EditCountry(n);

                                Console.WriteLine("Informe o CEP: ");
                                n = Console.ReadLine();
                                item2.Address.EditPostalCode(n);
                                break;

                                case 5:
                                retorno2 = false;
                                break;


                        }
                    }
                    while (retorno2 == true);
                }
            }
        }
    }
}