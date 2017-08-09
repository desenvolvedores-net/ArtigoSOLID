/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

namespace Solid.Certo.Persistence.Contract
{
    public interface IEntity
    {
        #region Public Properties

        int Codigo { get; set; }

        #endregion Public Properties
    }
}