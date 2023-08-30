using PasswordGen.Model;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    public class NumeriCasuali : IBuilderPassword
    {
        public NumeriCasuali(int m)
        {
            for (int i = 0; i < m; i++)
                Password+=(new Random().Next(10).ToString() + "");
        }

    }
}
