using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MainClientes
{
    class Program
    {
        static void Main(string[] args)
        {
            Carregar();
            var m = 1;
            int op;

            while (m == 1)
            {
                op = Menu();

                switch(op)
                {
                    case 1: Listar(); break;
                    case 2: Adicionar(); break;
                    case 3: Atualizar(); break;
                    case 4: Excluir(); break;
                    case 5: break;
                }
                break;
            }

            
        }




       public static int Menu()
       {
        Console.WriteLine("1-Listar Clientes");
        Console.WriteLine("2-Adicionar Clientes");
        Console.WriteLine("3-Atualizar Clientes");
        Console.WriteLine("4-Excluir Clientes");
        Console.WriteLine("5-Sair");
        
        return int.Parse(Console.ReadLine());
       }

       public static void Listar()
       {
        foreach(Clientes clientes  in NClientes.Listar())
        {
            Console.WriteLine(clientes);
        }
       }

       public static void Adicionar()
       {
        Console.WriteLine("Nome:");
        string n = Console.ReadLine();
        Console.WriteLine("Idade:");
        int i = int.Parse(Console.ReadLine());
        Console.WriteLine("Email");
        string e = Console.ReadLine();

        Clientes p = new Clientes{nome = n , idade = i, email= e};
        NClientes.Adicionar(p);
        Salvar();
       }

       public static void Atualizar()
       {
        Listar();
        Console.WriteLine("Selecione a Id para atualizar");
        int id = int.Parse(Console.ReadLine());
        Console.WriteLine("Informe novo email:");
        string e = Console.ReadLine();
        Clientes clientes = new Clientes{id = id, email = e};
        NClientes.Atualizar(clientes);
        Salvar();
       }

       public static void Excluir()
       {
        Listar();
        Console.WriteLine("Escolha um id para excluir:");
        int id = int.Parse(Console.ReadLine());
        Clientes clientes = new Clientes {id = id};
        NClientes.Excluir(clientes);
        Console.WriteLine("Cliente excluído");
       }

       

       static void Salvar()
       {
        string json = JsonSerializer.Serialize(NClientes.clientes);
        File.WriteAllText("clientes.json", json);
       }

       static void Carregar()
       {
        if (File.Exists("clientes.json"))
        {
            string json = File.ReadAllText("clientes.json");
            NClientes.clientes = JsonSerializer.Deserialize<List<Clientes>>(json);
        }

        else
        {
            NClientes.clientes = new List<Clientes>();
        }
       }
    } 

}