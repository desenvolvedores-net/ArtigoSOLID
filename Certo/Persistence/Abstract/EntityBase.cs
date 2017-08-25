/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Certo.Persistence.Contract;

namespace Solid.Certo.Persistence.Abstract
{
    public abstract class EntityBase: IEntity
    {

        #region Public Properties

        /*
         * Eu tenho por hábito colocar uma chave primária em todas as minhas tabelas.
         * Por isso este campo é base para todas as minhas outras entidades.
         */
        public int Codigo { get; set; }

        #endregion Public Properties

        #region Public Methods

        public abstract void Salvar();

        #endregion Public Methods
    }
}