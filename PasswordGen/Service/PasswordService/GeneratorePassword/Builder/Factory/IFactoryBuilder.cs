using PasswordGen.Model;
using System.Net.NetworkInformation;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory
{

    public class FactoryBuilder
    {   
        public enum TypePassword
        {
            soft,medium,hard
        }
        public static string? Get(TypePassword type) => type switch
        {
            TypePassword.soft => GetPasswordSoft(),
            TypePassword.medium => GetPasswordMedium(),
            TypePassword.hard => GetPasswordHard(),
            _=>throw new NotImplementedException()

        };
        private static string? GetPasswordSoft()
        {
            IBuilderPassword p = new IBuilderPassword()
                                                       .AddGenerazioneMauCaratteriCasuali(3)
                                                       .AddGenerazioneMinCaratteriCasuali(7);
            return p.Done();
        }
        private static string? GetPasswordMedium()
        {
            IBuilderPassword p = new IBuilderPassword()
                                                       .AddGenerazioneMauCaratteriCasuali(3)
                                                       .AddGenerazioneMNumeriCasuali(2)
                                                       .AddGenerazioneMinCaratteriCasuali(5);
            return p.Done();
        }
        private static string? GetPasswordHard()
        {
            IBuilderPassword p = new IBuilderPassword()
                                                       .AddGenerazioneMauCaratteriCasuali(3)
                                                       .AddGenerazioneMNumeriCasuali(2)
                                                       .AddGenerazioneMinCaratteriCasuali(3)
                                                       .AddGenerazioneMCaratteriSpecialiCasuali(2);
            return p.Done();
        }
    }
}
