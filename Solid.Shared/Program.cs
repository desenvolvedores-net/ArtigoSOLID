//Como estou usando shared project, a diretiva CERTO é apenas para identificar se estou no projeto certo. (Trocadilho infame detectado)
#if CERTO
using Solid.Certo.DependencyService;
using Solid.Certo.Persistence;
#else
using Solid.Errado;
#endif
using System;

namespace Solid
{
    internal class Program
    {
        #region Private Methods

        private static void Main(string[] args)
        {
#if CERTO
            StrategyDependencyManager.RegistrarEstrategias();
#endif
            Console.Title = "Apresentação S.O.L.I.D";

            do
            {
                Console.Clear();

                Cliente cliente = new Cliente();

                Console.WriteLine("Digite o CNPJ do cliente");
                string linha = Console.ReadLine();
                cliente.CNPJ = linha;

                Console.WriteLine("Digite o Nome do cliente");
                linha = Console.ReadLine();
                cliente.Nome = linha;

                Console.WriteLine("Digite o E-mail do cliente");
                linha = Console.ReadLine();
                cliente.Email = linha;
                try
                {
                    cliente.Salvar();
                }
                catch(Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ocorreu um erro ao salvar o cliente.");
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.ReadKey();
            } while(true);//loop infinito apenas para testes
        }

        #endregion Private Methods
    }
}