using PasswordGen.Model;
using System.Runtime.Serialization;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    class CaratteriSpecialiCasuali : IElementiCasuali
    {

        public CaratteriSpecialiCasuali(int m, BuilderPassword root) : base(root, 97, 122,m) {}
        public CaratteriSpecialiCasuali(int m) : base(97, 122, m) { }
    }
}