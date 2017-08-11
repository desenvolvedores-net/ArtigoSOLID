/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Certo.Persistence.Contract;
using Solid.Certo.Strategy.Contract;

namespace Solid.Certo.Strategy.Abstract
{
    public abstract class PersistenceStrategyBase<TEntity>: StrategyBase, IPersistenceStrategy<TEntity>
            where TEntity : class, IEntity, new()
    {
        #region Protected Constructors

        protected PersistenceStrategyBase()
        {
        }

        #endregion Protected Constructors

        #region Public Properties

        public TEntity Entidade { get; set; }

        #endregion Public Properties

        #region Public Methods

        public virtual void AntesDeSalvar(TEntity entity)
        {
            //na classe de base eu não faço nada
        }

        public virtual void DepoisDeSalvar(TEntity entity)
        {
            //na classe de base eu não faço nada
        }

        #endregion Public Methods
    }
}