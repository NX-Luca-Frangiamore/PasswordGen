using PasswordGen.Model;
using System.Runtime.Serialization;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    internal class CaratteriCasualiMin : BuilderPassword
    {
        public CaratteriCasualiMin(int m, BuilderPassword c) : base(c)
        {
            mCharacter = m;
        }
        public override string? Generate()
        {
            return Generate(mCharacter, 97, 122);
        }
    }
}