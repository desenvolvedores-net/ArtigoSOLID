/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Errado.Contract;
using System;

namespace Solid.Errado
{
    public class SaldoFinanceiro: ISaldo
    {
        #region Public Methods

        public void Atualizar()
        {
            Console.WriteLine("O saldo financeiro foi atualizado.");
        }

        public void BaixarEstoque()
        {
            throw new Exception("OPS! Eu não sei o que fazer aqui. Não sou uma classe de saldo de estoques");
        }

        #endregion Public Methods
    }
}