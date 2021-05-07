using System;
using System.IO;
using System.Linq;

namespace consoleLeitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var caminhoArquivo = "./texto.txt";
            if (!File.Exists(caminhoArquivo))
            {
                var fileNew = File.Create(caminhoArquivo);
                fileNew.Close();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite o texto a ser adicionado no arquivo e pressione ENTER");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Para apagar a última linha do arquivo digite: !apagaLinha");
            Console.ResetColor();
            var leitor = Console.ReadLine();

            var linhas = File.ReadAllLines(caminhoArquivo);
            if (leitor == "!apagaLinha")
            {
                File.WriteAllLines(caminhoArquivo, linhas.Take(linhas.Length - 1).ToArray());
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Mensagem do Sistema: Ultima linha do arquivo apagada");
                Console.ResetColor();
            }
            else
            {

                StreamWriter saida = new StreamWriter(caminhoArquivo, true);
                saida.WriteLine(leitor);
                saida.Close();
            }
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Pressione ENTER para finalizar");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
