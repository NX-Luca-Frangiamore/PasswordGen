using PasswordGen.Model;
using System.Runtime.Serialization;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    internal class CaratteriCasualiMin : ICaratteriCasuali
    {
        public CaratteriCasualiMin(int m)
        {
            Generate(m, 97, 122);
        }
    }
}