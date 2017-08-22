/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

namespace Solid.Errado.Contract
{
    public interface ISaldo
    {
        #region Public Methods

        void Atualizar();

        void BaixarEstoque();

        #endregion Public Methods
    }
}