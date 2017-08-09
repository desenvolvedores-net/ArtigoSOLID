/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Certo.Persistence.Abstract;
using Solid.Certo.Repository;
using System;

namespace Solid.Certo.Persistence
{
    public class Cliente: EntityBase
    {
        #region Public Properties

        public string CNPJ { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Nome { get; set; }

        public void Salvar()
        {
            DBContext<Cliente>.Salvar(this);
        }

        #endregion Public Properties
    }
}