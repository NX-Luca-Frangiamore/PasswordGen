using PasswordGen.Model;
using System.Runtime.Serialization;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    internal class CaratteriCasualiMau :  BuilderPassword
    {
     
        public CaratteriCasualiMau(int m, BuilderPassword c) :base(c)
        {
            this.mCharacter = m;          
        }

        public override string? Generate()
        {            
            return Generate(mCharacter, 65, 90);
        }
    }
}