/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Certo.Persistence;
using Solid.Certo.Service;
using Solid.Certo.Strategy.Abstract;
using Solid.Certo.Validator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solid.Certo.Strategy
{
    public class ClienteStrategy: PersistenceStrategyBase<Cliente>
    {
        #region Public Constructors

        public ClienteStrategy() : base()
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public override void DepoisDeSalvar(Cliente entity)
        {
            base.DepoisDeSalvar(entity);
            EmailService.EnviarEmail(entity.Email);
        }

        public override IEnumerable<string> Validar()
        {
            if(String.IsNullOrWhiteSpace(Entidade.Nome))
                yield return "O nome é obrigatório";

            if(!Entidade.Email.Contains("@"))
                yield return "O e-mail não é válido";

            string cnpjEhValido = new CNPJValidator().Validar(Entidade.CNPJ).FirstOrDefault();

            if(!String.IsNullOrEmpty(cnpjEhValido))
                yield return cnpjEhValido;

            yield break;
        }

        #endregion Public Methods
    }
}