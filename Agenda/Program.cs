﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
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

       phonebook = CarregarLista();


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
                    if (escolha == 'n' || escolha == 'N')
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

        List<Contact>CarregarLista()
        {
            if (File.Exists("agenda.txt"))
            {

                StreamReader sr = new StreamReader("agenda.txt");

                string tx = "";
               
                
                while ((tx = sr.ReadLine()) != null)
                {
                    var aux3 = tx.Split(",");

                    Address address = new Address();

                    /*newContact.Name = aux3[0];
                    newContact.Phone = aux3[1];
                    newContact.Email = aux3[2];*/

                    string name = aux3[0];
                    string phone = aux3[1];
                    string email = aux3[2];
                    

                    Contact nc = new Contact(name,phone,email);

                    nc.Address.Street = aux3[3];
                    nc.Address.City = aux3[4];
                    nc.Address.State = aux3[5];
                    nc.Address.Country = aux3[6];
                    nc.Address.PostalCode = aux3[7];

                    phonebook.Add(nc);

                }
            sr.Close();
            return phonebook;
            }
            else
            {
                Console.WriteLine("Iniciando...");
                Thread.Sleep(1000);
                Console.Clear();
                
            }
            
            return phonebook;

        }

        
        void PrintPhoneBook(List<Contact> l)
        {
            foreach (var item in l)
            {
                Console.WriteLine();
                Console.WriteLine(item.ToUser());
                Console.WriteLine();
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
            Console.Write("\nInforme o nome: ");
            var n = Console.ReadLine();

            try
            {
                foreach (var item in phonebook)
                {
                    if (item.Name.Equals(n))
                    {
                        Console.WriteLine("\nContato deletado com sucesso!");
                        return item;
                    }
                }
            }
            catch
                {
                    Console.WriteLine("Contato não encontrado");
                    Console.WriteLine("\nPressione qualquer tecla para retornar ao menu.");
                    Console.ReadKey();
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
            //string aux = char.ToUpper(n[0]) + n.Substring(1);

            foreach (var item2 in phonebook)
            {
                if (item2.Name.Contains(n))
                {
                    int op2;
                    bool retorno2 = false;
                    do
                    {
                        op2 = Menu2();


                        switch (op2)
                        {
                            case 1:
                                Console.Write("\nInforme o nome: ");
                                string a = Console.ReadLine();
                                //string aux2 = char.ToUpper(n[0]) + n.Substring(1);
                                string retorno = item2.EditName(a);
                                break;

                            case 2:
                                Console.Write("\nInforme o telefone: ");
                                n = Console.ReadLine();
                                string retorno3 = item2.EditPhone(n);
                                break;

                            case 3:
                                Console.Write("\nInforme o email: ");
                                n = Console.ReadLine();
                                string retorno4 = item2.EditEmail(n);
                                break;

                            case 4:
                                Console.Write("\nInforme o endereço: ");
                                n = Console.ReadLine();
                                string retorno5 = item2.Address.EditStreet(n);

                                Console.Write("\nInforme o estado: ");
                                n = Console.ReadLine();
                                string retorno6 = item2.Address.EditState(n);

                                Console.Write("\nInforme a cidade: ");
                                n = Console.ReadLine();
                                string retorno7 = item2.Address.EditCity(n);

                                Console.Write("\nInforme o país: ");
                                n = Console.ReadLine();
                                string retorno8 = item2.Address.EditCountry(n);

                                Console.Write("\nInforme o CEP: ");
                                n = Console.ReadLine();
                                string retorno9 = item2.Address.EditPostalCode(n);
                                break;

                                case 5:
                                retorno2 = false;
                                break;


                        }
                    }
                    while (retorno2 == true);
                }
                else
                {
                    Console.WriteLine("Nome não encontrado!");
                    break;
                }
            }
        }
    }
}