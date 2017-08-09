/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

 using System;
using System.Collections.Generic;

namespace Solid.Errado
{
    public class Cliente
    {
        #region Private Methods

        private void Adicionar()
        {
            Validar();
            Console.WriteLine($"O cliente {Nome} foi inserido.");
        }

        private void Atualizar()
        {
            Validar();
            Console.WriteLine($"O cliente {Nome} foi atualizado.");
        }

        #endregion Private Methods

        #region Public Properties

        public string CNPJ { get; set; }
        public int Codigo { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Nome { get; set; }

        #endregion Public Properties

        #region Public Methods

        public void EnviarEmail()
        {
            Console.WriteLine($"O e-mail foi enviado para o endereço {Email}");
        }

        public void Excluir(long id)
        {
            Console.WriteLine($"O cliente {Nome} foi excluído.");
        }

        public void Salvar()
        {
            if(Codigo != 0)
                Atualizar();
            else
                Adicionar();

            EnviarEmail();
        }

        public IList<Cliente> Selecionar(long? id = null)
        {
            List<Cliente> result = new List<Cliente>();

            return result;
        }

        public bool Validar()
        {
            if(String.IsNullOrWhiteSpace(Nome))
                throw new Exception("O nome é obrigatório");

            if(!Email.Contains("@"))
                throw new Exception("O e-mail não é válido");

            if(CNPJ.Length != 14)
                throw new Exception("O CNPJ não é válido");

            return true;
        }

        #endregion Public Methods
    }
}