/*
 * Classe apenas para fins de exemplo e aprendizado não considera nenhum tipo de validação ou regra ou se utiliza de algum framework.
 */

using Solid.Errado.QuadradoRetangulo;

namespace Solid.Errado.Utility
{
    public static class CalculaArea
    {
        #region Public Methods

        //Sim, este método poderia ser da classe retângulo.
        //Mas para efeito de exemplo, vou deixar ele aqui.
        public static int CalcularArea(Retangulo retangulo)
        {
            return retangulo.Altura * retangulo.Largura;
        }

        #endregion Public Methods
    }
}