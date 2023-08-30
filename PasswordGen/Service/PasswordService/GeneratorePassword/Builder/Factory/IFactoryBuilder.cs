using PasswordGen.Model;
using System.Net.NetworkInformation;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory
{
    public class FactoryBuilder
    { public enum TypePassword
        {
            soft,medium,hard
        }
        public static PasswordModel? Get(TypePassword type, string name) => type switch
        {
            TypePassword.soft => GetPasswordSoft(name),
            TypePassword.medium => GetPasswordMedium(name),
            TypePassword.hard => GetPasswordHard(name),
            _ => throw new NotImplementedException()
        };
        private static PasswordModel? GetPasswordSoft(string name)
        {
            IBuilderPassword? p = IBuilderPassword.Initialization(name)?
                                               .AddGenerazioneMauCaratteriCasuali(3)
                                               .AddGenerazioneMinCaratteriCasuali(7);
            return p?.Done();
        }
        private static PasswordModel? GetPasswordMedium(string name)
        {
            IBuilderPassword? p = IBuilderPassword.Initialization(name)?
                                               .AddGenerazioneMauCaratteriCasuali(3)
                                               .AddGenerazioneMNumeriCasuali(2)
                                               .AddGenerazioneMinCaratteriCasuali(5);
            return p?.Done();
        }
        private static PasswordModel? GetPasswordHard(string name)
        {
            IBuilderPassword? p = IBuilderPassword.Initialization(name)?
                                               .AddGenerazioneMauCaratteriCasuali(3)
                                               .AddGenerazioneMNumeriCasuali(2)
                                               .AddGenerazioneMinCaratteriCasuali(3)
                                               .AddGenerazioneMCaratteriSpecialiCasuali(2);
            return p?.Done();
        }
    }
}
