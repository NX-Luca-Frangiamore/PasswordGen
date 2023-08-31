using PasswordGen.Model;
using System.Runtime.Serialization;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    class CaratteriSpecialiCasuali : IElementiCasuali
    {

        public CaratteriSpecialiCasuali(int m) : base(33, 47,m) {}
    }
}