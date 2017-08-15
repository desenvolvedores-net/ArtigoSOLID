/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Errado.LSP.Abstract;

namespace Solid.Errado.LSP
{
    public static class AtualizarSaldo
    {
        #region Public Methods

        public static void AtualizarSaldos(params AtualizaSaldoBase[] saldos)
        {
            foreach(var saldo in saldos)
            {
                if(saldo is AtualizarSaldoAnual)
                    ((AtualizarSaldoAnual)saldo).AtualizarAno();
                else if(saldo is AtualizarSaldoMensal)
                    ((AtualizarSaldoMensal)saldo).AtualizarMes();
                else if(saldo is AtualizarSaldoDiario)
                    ((AtualizarSaldoDiario)saldo).AtualizarDia();
            }
        }

        #endregion Public Methods
    }
}