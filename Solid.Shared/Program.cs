//Como estou usando shared project, a diretiva CERTO é apenas para identificar se estou no projeto certo. (Trocadilho infame detectado)
#if CERTO
using Solid.Certo.DependencyService;
using Solid.Certo.Persistence;
#else

using Solid.Errado;

#endif

using System;
using System.Collections.Generic;

namespace Solid
{
    internal class Program
    {
        #region Private Methods

        private static void Main(string[] args)
        {

#if CERTO
            StrategyDependencyManager.RegistrarEstrategias();
            Console.Title = "Apresentação S.O.L.I.D - CERTO";
#else
            Console.Title = "Apresentação S.O.L.I.D - ERRADO";
            Console.BackgroundColor = ConsoleColor.DarkRed;      
#endif
            Action action = null;

            do
            {
                Console.Clear();

                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("0: Sair");
                Console.WriteLine("1: Cliente");
                Console.WriteLine("2: Venda");
                ConsoleKeyInfo opcao = Console.ReadKey();

                switch(opcao.Key)
                {
                    case ConsoleKey.NumPad0:
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.NumPad1:
                        action = SalvarCliente;
                        break;

                    case ConsoleKey.NumPad2:
                        action = RealizarVenda;
                        break;

                    default:
                        action = null;
                        Console.WriteLine("Opção não é válida.");
                        break;
                }

                try
                {
                    action?.Invoke();
                }
                catch(Exception ex)
                {
                    EscreverErro(ex);
                }

                Console.ReadKey();
            } while(true);//loop infinito apenas para testes
        }

        private static void EscreverErro(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r\nOcorreram erros ao executar o método.");
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void RealizarVenda()
        {
            Venda venda = new Venda();

            //vamos simular alguns erros para que a nossa estratégia funcione
            try
            {
                venda.Codigo = 1;
                venda.Salvar(); //Sem cliente
            }
            catch(Exception ex)
            {
                EscreverErro(ex);
            }

            try
            {
                venda.CodigoCliente = 1;
                venda.Salvar();//Sem itens
            }
            catch(Exception ex)
            {
                EscreverErro(ex);
            }

            //venda normal
            venda.Itens = new List<string> {"1x R$ 15,00 produto carvão",
                                            "1x R$ 10,00 produto costela de boi",
                                            "1x R$  5,00 produto cerveja"};
            venda.Salvar();
        }

        private static void SalvarCliente()
        {
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

            cliente.Salvar();
        }

        #endregion Private Methods
    }
}