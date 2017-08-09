/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using System.Collections.Generic;

namespace Solid.Certo.Strategy.Contract
{
    public interface IStrategy
    {
        #region Public Methods

        IEnumerable<string> Validar();

        #endregion Public Methods
    }
}