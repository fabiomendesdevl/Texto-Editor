using System.IO;

namespace TextoEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.WriteLine("|------- Menu ---------|");
            Console.WriteLine("|1 - Abrir um arquivo  |");
            Console.WriteLine("|2 - Criar novo arquivo|");
            Console.WriteLine("|0 - Sair              |");
            Console.WriteLine("------------------------");

            short op = short.Parse(Console.ReadLine());

            switch (op)
            {
                case 1:
                    Abrir();
                    break;
                case 2:
                    Editar();
                    break;
                default:
                    Menu();
                    break;
            }
            static void Abrir()
            {
                Console.Clear();
                Console.WriteLine("Qual o caminho do arquivo ?");
                string path = Console.ReadLine();

                using (var file = new StreamReader(path))
                {
                    string texto = file.ReadToEnd();
                    Console.WriteLine(texto);

                }
                Console.WriteLine("");
                Console.ReadLine();
                Menu();
            }
            static void Editar()
            {
                Console.Clear();
                Console.WriteLine("|Insira seu texto abaixo|");
                Console.WriteLine("-------------------------");
                //esc para sair, salvar ou nao//
                string texto = "";

                do
                {
                    texto += Console.ReadLine();
                    texto += Environment.NewLine; // quebra de linha com enter
                } while (Console.ReadKey().Key != ConsoleKey.Escape);//Esc do teclado

                salvar(texto);
            }
            static void salvar(string texto)
            {
                Console.Clear();
                Console.WriteLine("Qual caminho voce deseja salvar o arquivo?");
                var path = Console.ReadLine();   // path ou caminho para salvar

                //abrir um aquivo
                using (var arquivo = new StreamWriter(path)) // Stream =  fluxo, de escrita = Write                                                       
                {
                    arquivo.Write(texto);
                }
                Console.WriteLine("arquvio salvo com sucesso..." + path);
                Console.ReadLine();
                Menu();
            }
        }
    }
}