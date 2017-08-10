using Solid.Certo.Strategy.Contract;
using System.Collections.Generic;

namespace Solid.Certo.Strategy.Abstract
{
    public abstract class StrategyBase: IStrategy
    {
        #region Public Methods

        public abstract IEnumerable<string> Validar();

        #endregion Public Methods
    }
}