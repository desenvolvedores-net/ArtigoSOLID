/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using System;

namespace Solid.Certo.Service
{
    public static class EmailService
    {
        #region Public Methods

        public static void EnviarEmail(string email)
        {
            //Aqui podemos implementar nossos serviços de envio de e-mail e utilizar em toda a aplicação
            Console.WriteLine($"O e-mail foi enviado para {email}.");
        }

        #endregion Public Methods
    }
}