using PasswordGen.Model;
using System.Runtime.Serialization;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    internal class CaratteriCasualiMau : ICaratteriCasuali
    {
        public CaratteriCasualiMau(int m)
        {
            Generate(m, 65, 90);
        }
    }
}