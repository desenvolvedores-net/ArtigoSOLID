﻿/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Certo.Utility.Abstract;
using System;

namespace Solid.Certo.Utility
{
    public class AtualizaSaldoMensal: AtualizaSaldoBase
    {
        #region Public Methods

        public override void Atualizar()
        {
            Console.WriteLine("O saldo MENSAL foi atualizado.");
        }

        #endregion Public Methods
    }
}