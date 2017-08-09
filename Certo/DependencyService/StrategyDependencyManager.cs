/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Certo.Persistence.Contract;
using Solid.Certo.Strategy;
using Solid.Certo.Strategy.Contract;
using System.Collections.Generic;

namespace Solid.Certo.DependencyService
{
    public static class StrategyDependencyManager
    {
        #region Private Fields

        private static Dictionary<string, IStrategy> estrategias = new Dictionary<string, IStrategy>();

        #endregion Private Fields

        #region Public Methods

        public static IPersistenceStrategy<TEntity> RecuperarEstrategiaPersistencia<TEntity>()
            where TEntity : IEntity
        {
            return estrategias[typeof(TEntity).Name] as IPersistenceStrategy<TEntity>;
        }

        public static void RegistrarEstrategias()
        {
            //aqui eu mantive fixo, mas o correto é manter de forma dinâmica. Estude como o seu framework de injeção de dependência trabalha para que se mantenha esta parte do código dinâmica
            estrategias[typeof(Persistence.Cliente).Name] = new ClienteStrategy();
        }

        #endregion Public Methods
    }
}