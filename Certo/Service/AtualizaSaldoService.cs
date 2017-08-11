/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Certo.Utility.Abstract;
using System.Collections.Generic;

namespace Solid.Certo.Service
{
    public static class AtualizaSaldoService
    {
        #region Public Methods

        public static void AtualizarSaldos(List<AtualizaSaldoBase> saldos)
        {
            foreach(AtualizaSaldoBase saldo in saldos)
            {
                saldo.Atualizar();
            }
        }

        #endregion Public Methods
    }
}