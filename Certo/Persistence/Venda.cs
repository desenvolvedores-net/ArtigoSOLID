/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Certo.Persistence.Abstract;
using Solid.Certo.Repository;
using System.Collections.Generic;

namespace Solid.Certo.Persistence
{
    public class Venda: EntityBase
    {
        #region Public Properties

        public int CodigoCliente { get; set; }
        public List<string> Itens { get; set; }
        public double TotalVenda { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override void Salvar()
        {
            DummyDBContext<Venda>.Salvar(this);
        }

        #endregion Public Methods
    }
}