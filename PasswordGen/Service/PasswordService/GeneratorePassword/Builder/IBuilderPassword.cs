using PasswordGen.Model;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;






namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder
{


    public interface IBuilderPassword
    {

        public string Done();
        public IBuilderPassword AddGenerazioneMauCaratteriCasuali(int m);
        public IBuilderPassword AddGenerazioneMinCaratteriCasuali(int m);

        public IBuilderPassword AddGenerazioneMCaratteriSpecialiCasuali(int m);

        public IBuilderPassword AddGenerazioneMNumeriCasuali(int m);
    }
}
