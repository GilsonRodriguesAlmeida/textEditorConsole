using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }

        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual a pasta do arquivo:");
            //endereço de onde o arquivo está passado pelo usuario
            string pasta = Console.ReadLine();
            //lê o arquivo
            using (var arquivo = new StreamReader(pasta))
            {
                // lê até o final do arquivo
                string text = arquivo.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite o seu texto abaixo: (ESC para Sair)");
            Console.WriteLine("--------------------------");
            string text = "";

            do
            {
                // Adiciona linha a linha
                text += Console.ReadLine();
                // Adiciona uma nova linha
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);

        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("-Deseja salvar em qual pasta?");

            var pasta = Console.ReadLine();

            using (var arquivo = new StreamWriter(pasta))
            {
                arquivo.Write(text);
            }

            Console.WriteLine($"-Salvo em {pasta} com sucesso!");
            Console.ReadLine();
            Menu();
        }

    }
}