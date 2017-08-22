/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Errado.Contract;
using System;

namespace Solid.Errado
{
    public class AtualizarSaldoDiario: ISaldo
    {
        #region Public Methods

        public void Atualizar()
        {
            Console.WriteLine("O saldo DIARIO foi atualizado.");
        }

        public void BaixarEstoque()
        {
            Console.WriteLine("O estoque foi baixado em 10 itens");
            Atualizar();
        }

        #endregion Public Methods
    }
}