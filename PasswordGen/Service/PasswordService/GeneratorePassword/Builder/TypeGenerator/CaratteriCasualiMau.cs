using PasswordGen.Model;
using System.Runtime.Serialization;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi
{
    internal class CaratteriCasualiMau :  IElementiCasuali
    {
       
        public CaratteriCasualiMau(int m) :base(65, 90,m){}
    }
}