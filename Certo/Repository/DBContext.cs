/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 *
 * Iremos assumir que nossos objetos serão salvos por um contexto de base de dados.
 * Cada linguagem ou ORM irá implementar de forma diferente.
 *
 */

using Solid.Certo.Persistence.Contract;
using Solid.Certo.Strategy.Contract;
using System;
using System.Collections.Generic;

namespace Solid.Certo.Repository
{
    public static class DBContext<TEntity>
        where TEntity : class, IEntity
    {
        #region Private Methods

        private static void Adicionar(TEntity entity)
        {
            Console.WriteLine($"A entidade {typeof(TEntity).Name} foi salva na base de dados.");
        }

        private static void Atualizar(TEntity entity)
        {
            Console.WriteLine($"A entidade {typeof(TEntity).Name} foi atualizada na base de dados.");
        }

        private static void EhValida(TEntity entity)
        {
            foreach(string item in RecuperarEstrategia(entity).Validar())
            {
                throw new Exception(item);
            }
        }

        private static IPersistenceStrategy<TEntity> RecuperarEstrategia(TEntity entity)
        {
            IPersistenceStrategy<TEntity> result = DependencyService.StrategyDependencyManager.RecuperarEstrategiaPersistencia(entity);
            result.Entidade = entity;
            return result;
        }

        #endregion Private Methods

        #region Public Methods

        public static void Salvar(TEntity entity)
        {
            EhValida(entity);
            RecuperarEstrategia(entity).AntesDeSalvar(entity);

            if(entity.Codigo > 0)
                Atualizar(entity);
            else
                Adicionar(entity);

            RecuperarEstrategia(entity).DepoisDeSalvar(entity);
        }

        public static IEnumerable<TEntity> Selecionar(long? id = null)
        {
            List<TEntity> result = new List<TEntity>();

            foreach(TEntity item in result)
            {
                yield return item;
            }

            yield break;
        }

        #endregion Public Methods
    }
}