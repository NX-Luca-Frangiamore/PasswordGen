using PasswordGen.Model;
using System.Runtime.Serialization;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    class CaratteriSpecialiCasuali : BuilderPassword
    {
        public CaratteriSpecialiCasuali(int m, BuilderPassword c) : base(c)
        {
            mCharacter = m;
        }
        public override string? Generate()
        {
            return Generate(mCharacter, 97, 122);
        }
    }
}