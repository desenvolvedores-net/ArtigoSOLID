/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

 namespace Solid.Errado.Utility
{
    public static class AtualizarSaldo
    {
        #region Public Methods

        public static void AtualizarSaldos(params object[] saldos)
        {
            foreach(var saldo in saldos)
            {
                if(saldo.GetType() == typeof(AtualizarSaldoAnual))
                    ((AtualizarSaldoAnual)saldo).Atualizar();
                else if(saldo.GetType() == typeof(AtualizarSaldoMensal))
                    ((AtualizarSaldoMensal)saldo).Atualizar();
                else if(saldo.GetType() == typeof(AtualizarSaldoDiario))
                    ((AtualizarSaldoDiario)saldo).Atualizar();
            }
        }

        #endregion Public Methods
    }
}