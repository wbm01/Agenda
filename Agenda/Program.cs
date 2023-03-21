using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Agenda;

internal class Program
{
    private static void Main(string[] args)
    {
        List <Contact> phonebook = new List<Contact>();
        int op;
        bool sair = false;

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
                    Console.WriteLine("Deseja buscar a lista completa? Escolha S ou N: ");
                    escolha = char.Parse(Console.ReadLine());
                    if(escolha == 's'){
                        PrintPhoneBook(phonebook);
                        break;
                    }
                    /*else
                    {
                        char escolha2;
                        Console.WriteLine("Escolha a letra que deseja consultar: ");
                        escolha2 = char.Parse(Console.ReadLine());

                        foreach(var item4 in phonebook)
                        {
                            if (item4.Name.Contains(escolha2))
                            {
                                PrintPhoneBook(escolha2);
                            }
                            

                        }
                    }*/
                    break;
                    

                case 5:
                    System.Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        } while (true);



        void PrintPhoneBook(List<Contact> l)
        {
            foreach (var item in l)
            {
                List<Contact> listaordenada = l.OrderBy(Contact => Contact.Name).ToList();

                for (int i = 0; i < listaordenada.Count; i++)
                {
                    Console.WriteLine(listaordenada[i].ToString());
                    Console.WriteLine();
                }
            }
        }


        int Menu()
        {

            Console.Write("\nMENU DE OPÇÕES\n\n1 - Insere Contato"
                + "\n2 - Editar Contato\n3 - Remover Contato\n4 - Mostrar agenda\n5 - Sair\n\nEscolha uma opção: ");

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
            Console.Write("\nInforme o telefone: ");
            var t = Console.ReadLine();
            Console.Write("\nInforme o email: ");
            string e = Console.ReadLine();


            Contact contact = new Contact(n, t, e);

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
            var n = Console.ReadLine();

            foreach (var item2 in phonebook)
            {
                if (item2.Name.Equals(n))
                {
                    int op2;
                    do
                    {
                        op2 = Menu2();


                        switch (op2)
                        {
                            case 1:
                                Console.WriteLine("Informe o nome: ");
                                n = Console.ReadLine();
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
                                            Console.WriteLine("\nDeseja buscar a lista completa? Escolha S ou N: ");
                                            escolha = char.Parse(Console.ReadLine());
                                            if (escolha == 's' || escolha == 'n')
                                            {
                                                PrintPhoneBook(phonebook);
                                                break;
                                            }
                                            /*else
                                            {
                                                char escolha2;
                                                Console.WriteLine("Escolha a letra que deseja consultar: ");
                                                escolha2 = char.Parse(Console.ReadLine());

                                                foreach(var item4 in phonebook)
                                                {
                                                    if (item4.Name.Contains(escolha2))
                                                    {
                                                        PrintPhoneBook(escolha2);
                                                    }


                                                }
                                            }*/
                                            break;


                                        case 5:
                                            System.Environment.Exit(0);
                                            break;

                                        default:
                                            Console.WriteLine("\nOpção Inválida");
                                            break;
                                    }
                                } while (true);
                                break;

                            default:
                                Console.WriteLine("\nOpção Inválida");
                                break;
                        }
                    } while (sair == false);


                }
                else
                {
                    Console.WriteLine("\nContato não encontrado!");
                }

            }
        }



        /*Contact contact = new Contact("Willian", "(16) 99999");

        contact.Address.EditStreet("Rua Nove de Julho, 2100");
        contact.Address.EditPostalCode("14800-000");
        contact.Address.EditState("SP");
        contact.Address.EditCity("Araraquara");
        contact.Address.EditCountry("Brasil");

        Contact contact2 = new Contact("Isa", "(16) 11111");

        contact2.Address.EditStreet("Rua Nove de Julho, 2122");
        contact2.Address.EditPostalCode("14806-111");
        contact2.Address.EditState("SP");
        contact2.Address.EditCity("Araraquara");
        contact2.Address.EditCountry("Brasil");


        phonebook.Add(contact);
        phonebook.Add(contact2);

        PrintPhoneBook(phonebook);

        phonebook.OrderBy(x => x.Name); // Função lâmbida*/


    }

}