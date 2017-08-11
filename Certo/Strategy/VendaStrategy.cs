/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Certo.Persistence;
using Solid.Certo.Strategy.Abstract;
using Solid.Certo.Utility.Abstract;
using System;
using System.Collections.Generic;

namespace Solid.Certo.Strategy
{
    public class VendaStrategy: PersistenceStrategyBase<Venda>
    {
        #region Public Methods

        public override void AntesDeSalvar(Venda entity)
        {
            base.AntesDeSalvar(entity);
            //vamos simular uma cálculo de total de venda
            Entidade.TotalVenda = 30;
            Console.WriteLine("O total da venda foi calculado");
        }

        public override IEnumerable<string> Validar()
        {
            if(Entidade.CodigoCliente == 0)
                yield return "O código do cliente é obrigatório.";

            if((Entidade.Itens?.Count ?? 0) == 0)
                yield return "A quantidade de itens vendida não pode ser zero.";

            yield break;
        }

        public override void DepoisDeSalvar(Venda entity)
        {
            base.DepoisDeSalvar(entity);

            Service.AtualizaSaldoService.AtualizarSaldos(new List<AtualizaSaldoBase>
            {
                new Utility.AtualizaSaldoDiario(),
                new Utility.AtualizaSaldoMensal(),
                new Utility.AtualizaSaldoAnual()
            });
        }

        #endregion Public Methods
    }
}