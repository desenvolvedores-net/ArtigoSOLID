/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using System;
using System.Collections.Generic;

namespace Solid.Errado
{
    public class Venda
    {
        #region Public Properties

        public int Codigo { get; set; }
        public int CodigoCliente { get; set; }
        public List<string> Itens { get; set; }
        public double TotalVenda { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void Salvar()
        {
            Validar();
            Console.WriteLine("A venda foi salva.");
            CalcularTotal();
            AtualizarSaldo();
        }

        private void CalcularTotal()
        {
            Console.WriteLine("O total da venda foi calculado.");
        }

        public void Validar()
        {
            if(CodigoCliente == 0)
                throw new Exception("O código do cliente é obrigatório.");

            if((Itens?.Count ?? 0) == 0)
                throw new Exception("A quantidade de itens vendida não pode ser zero.");
        }

        public void AtualizarSaldo()
        {
            Utility.AtualizarSaldo.AtualizarSaldos(new AtualizarSaldoAnual(),
                                                   new AtualizarSaldoMensal(),
                                                   new AtualizarSaldoDiario());
        }
        #endregion Public Methods
    }
}