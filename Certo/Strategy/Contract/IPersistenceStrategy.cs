/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Certo.Persistence.Contract;

namespace Solid.Certo.Strategy.Contract
{
    public interface IPersistenceStrategy<TEntity>: IStrategy
        where TEntity : IEntity
    {
        #region Public Properties

        TEntity Entidade { get; set; }

        void DepoisDeSalvar(TEntity entity);

        #endregion Public Properties
    }
}