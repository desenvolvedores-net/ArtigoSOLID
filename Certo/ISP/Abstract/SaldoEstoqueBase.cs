using System;
using Solid.Certo.ISP.Contract;

namespace Solid.Certo.ISP.Abstract
{
    public abstract class SaldoEstoqueBase: SaldoBase, ISaldoEstoque
    {
        public override void Atualizar()
        {
            Console.WriteLine("Saldo de estoque atualizado.");
        }
    }
}