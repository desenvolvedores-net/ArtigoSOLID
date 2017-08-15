//Como estou usando shared project, a diretiva CERTO é apenas para identificar se estou no projeto certo. (Trocadilho infame detectado)
#if CERTO
using Solid.Certo.DependencyService;
using Solid.Certo.Persistence;
#else
using Solid.Errado;
using Solid.Errado.QuadradoRetangulo;
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

#if !CERTO
                Console.WriteLine("3: Área do Quadrado/ Retângulo");
#endif
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
#if !CERTO
                    case ConsoleKey.NumPad3:
                        action = CalcularQuadradoRetangulo;
                        break;
#endif

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
#if !CERTO
        private static void CalcularQuadradoRetangulo()
        {
            int altura;
            int largura;

            Console.WriteLine("\r\nInforme a altura:");
            altura = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe a largura:");
            largura = Convert.ToInt32(Console.ReadLine());

            //aqui, podemos criar um quadrado normalmente.
            Quadrado quadrado = new Quadrado
            {
                Altura = altura,
                Largura = largura
            };

            //aqui, criamos um retângulo com base em um quadrado, atendendo ao princípio do LSP
            Retangulo retanguloQuadrado = new Quadrado
            {
                Altura = altura,
                Largura = largura
            };

            //Aqui criamos um retângulo normalmente.
            Retangulo retangulo = new Retangulo
            {
                Altura = altura,
                Largura = largura
            };

            int quadradoAreaEsperada = altura * altura;
            int retanguloAreaEsperada = largura * altura;
            //o método CalcularArea() espera um retângulo, perceba que podemos passar tanto um quadrado quanto um retângulo. Atendendo ao princípio LSP.
            Console.WriteLine($"A área correta do retângulo é {retanguloAreaEsperada} e a calculada foi {Errado.Utility.CalculaArea.CalcularArea(retangulo)}");
            Console.WriteLine($"A área correta do quadrado  é {quadradoAreaEsperada} e a calculada foi {Errado.Utility.CalculaArea.CalcularArea(quadrado)}");
        }
#endif

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