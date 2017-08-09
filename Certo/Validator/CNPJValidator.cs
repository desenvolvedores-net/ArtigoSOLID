/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Certo.Validator.Contract;
using System.Collections.Generic;

namespace Solid.Certo.Validator
{
    public class CNPJValidator: IValidator<string>
    {
        #region Public Methods

        public IEnumerable<string> Validar(string value)
        {
            if((value?.Length ?? 0) != 14)
                yield return "CNPJ não é válido.";

            yield break;
        }

        #endregion Public Methods
    }
}