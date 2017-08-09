/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using System.Collections.Generic;

namespace Solid.Certo.Validator.Contract
{
    public interface IValidator<TValue>
    {
        #region Public Methods

        IEnumerable<string> Validar(TValue value);

        #endregion Public Methods
    }
}