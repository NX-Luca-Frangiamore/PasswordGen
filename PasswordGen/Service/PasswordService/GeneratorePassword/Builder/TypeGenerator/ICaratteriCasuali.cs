
using System;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    public abstract class ICaratteriCasuali
    {
        private Random Random = new Random();

        /**
        * <param name="initRange">Indica l'inizio del range degli elementi cercati nella tabella ascii</param>
        * <param name="endRange">Indica la fine del range degli elementi cercati nella tabella ascii</param>
        */

        protected string Generate(int m, int initRange, int endRange)
        {
            string password = "";
            for (int i = 0; i < m; i++)
                password+=((char)Random.Next(initRange, endRange) + "");
            return password;
        }
    }
}
