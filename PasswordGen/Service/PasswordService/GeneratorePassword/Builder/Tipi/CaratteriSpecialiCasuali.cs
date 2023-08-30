using PasswordGen.Model;
using System.Runtime.Serialization;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    [Serializable]
    class CaratteriSpecialiCasuali : ICaratteriCasuali
    {
        public CaratteriSpecialiCasuali(int m)
        {
            Generate(m, 33, 47);
        }
    }
}