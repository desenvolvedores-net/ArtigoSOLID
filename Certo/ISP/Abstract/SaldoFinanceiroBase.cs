using System;
using Solid.Certo.ISP.Contract;

namespace Solid.Certo.ISP.Abstract
{
    public abstract class SaldoFinanceiroBase: SaldoBase, ISaldoFinanceiro
    {
        #region Public Methods

        public override void Atualizar()
        {
            Console.WriteLine("O saldo financeiro foi atualizado.");
        }

        #endregion Public Methods
    }
}