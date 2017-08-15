/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Errado.LSP.Abstract;
using System;

namespace Solid.Errado.LSP
{
    public class AtualizarSaldoMensal: AtualizaSaldoBase
    {
        #region Public Methods

        public void AtualizarMes()
        {
            Console.WriteLine("O saldo MENSAL foi atualizado.");
        }

        #endregion Public Methods
    }
}