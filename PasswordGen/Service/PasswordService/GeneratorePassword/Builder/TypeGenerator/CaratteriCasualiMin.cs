using PasswordGen.Model;
using System.Runtime.Serialization;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    internal class CaratteriCasualiMin : IElementiCasuali
    {

        public CaratteriCasualiMin(int m) : base(97, 122, m) { }
    }
}