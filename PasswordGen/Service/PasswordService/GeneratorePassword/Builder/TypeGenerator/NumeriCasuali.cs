using PasswordGen.Model;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    public class NumeriCasuali : BuilderPassword
    {
        public NumeriCasuali(int m, BuilderPassword c) : base(c)
        {
           mCharacter = m;
        }

        public override string? Generate()
        {
            string password = "";
            for (int i = 0; i < mCharacter; i++)
                password += (new Random().Next(10).ToString() + "");
            return password;
        }
    }
}
