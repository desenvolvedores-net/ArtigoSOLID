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

    /*
     * As classes de estratégia não conhecem a implementação do banco de dados, apenas verificam se está tudo correto para que seja salvo em banco de dados.
     * 
     */

    //Sim, ao invés de "Cliente", podemos definir até aqui como sendo uma interface de cliente "ICliente".
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
            //Podemos também injetar o serviço de envio de emails. Desta forma esta classe não precisaria nem conhecer o EmailService.
            EmailService.EnviarEmail(entity.Email);
        }

        public override IEnumerable<string> Validar()
        {
            if(String.IsNullOrWhiteSpace(Entidade.Nome))
                yield return "O nome é obrigatório";

            if(!Entidade.Email.Contains("@"))
                yield return "O e-mail não é válido";

            //Aqui, para diminuir ainda mais o acoplamento. Usando injeção de dependência podemos definir o nosso validador de CNPJ, uma vez que o mesmo implementa a interface IValidator<>
            //O que poderia ser customizado para cada cliente, por exemplo.
            string cnpjEhValido = new CNPJValidator().Validar(Entidade.CNPJ).FirstOrDefault();

            if(!String.IsNullOrEmpty(cnpjEhValido))
                yield return cnpjEhValido;

            yield break;
        }

        #endregion Public Methods
    }
}