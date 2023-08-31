using PasswordGen.Model;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    public class NumeriCasuali : IElementiCasuali
    {
        public NumeriCasuali(int m) : base(48,57,m){}
    }
}
