using PasswordGen.Model;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;






namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder
{


    public class IBuilderPassword
    {
        protected static string Password="";
        public string? Done()
        {
            return Password;
        }
        public IBuilderPassword AddGenerazioneMauCaratteriCasuali(int m)
        {
            return new CaratteriCasualiMau(m);
        }
        public IBuilderPassword AddGenerazioneMinCaratteriCasuali(int m)
        {
            return new CaratteriCasualiMin(m);
        }

        public IBuilderPassword AddGenerazioneMCaratteriSpecialiCasuali(int m)
        {
            return new CaratteriSpecialiCasuali(m);
        }

        public IBuilderPassword AddGenerazioneMNumeriCasuali(int m)
        {
            return new NumeriCasuali(m);
        }
    }
}
