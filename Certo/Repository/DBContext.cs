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
        where TEntity : class, IEntity, new()
    {
        #region Private Properties

        private static IPersistenceStrategy<TEntity> Estrategia { get; } = DependencyService.StrategyDependencyManager.RecuperarEstrategiaPersistencia<TEntity>();

        #endregion Private Properties

        #region Private Methods

        private static void EhValida(TEntity entity)
        {
            Estrategia.Entidade = entity;

            foreach(string item in Estrategia.Validar())
            {
                throw new Exception(item);
            }
        }

        #endregion Private Methods

        #region Public Methods

        public static void Adicionar(TEntity entity)
        {
            EhValida(entity);
            Console.WriteLine($"A entidade {typeof(TEntity).Name} foi salva na base de dados.");
        }

        public static void Atualizar(TEntity entity)
        {
            EhValida(entity);
            Console.WriteLine($"A entidade {typeof(TEntity).Name} foi atualizada na base de dados.");
        }

        public static void Excluir(long id)
        {
            Console.WriteLine($"A entidade {typeof(TEntity).Name} com id {id} foi excluída da base de dados.");
        }

        public static void Salvar(TEntity entity)
        {
            if(entity.Codigo > 0)
                Atualizar(entity);
            else
                Adicionar(entity);

            Estrategia.DepoisDeSalvar(entity);
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