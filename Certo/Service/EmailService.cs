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
            Console.WriteLine($"O e-mail foi enviado para {email}.");
        }

        #endregion Public Methods
    }
}