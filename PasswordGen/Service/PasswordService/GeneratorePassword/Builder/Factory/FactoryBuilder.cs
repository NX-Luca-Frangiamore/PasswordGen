using PasswordGen.Model;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory
{

    public class FactoryBuilder
    {
        private Dictionary<TypePassword,IBuilderPassword> Builder=new();
        public enum TypePassword
        {
            soft,medium,hard
        }
        public FactoryBuilder()
        {
            Builder[TypePassword.soft] = GetBuilderSoft();
            Builder[TypePassword.medium] = GetBuilderMedium();
            Builder[TypePassword.hard] = GetBuilderHard();
        }
        public string? Get(TypePassword type)
        {
            return Builder[type].Done();
        }
        private IBuilderPassword GetBuilderSoft()
        {
            BuilderPassword p = BuilderPassword.Create()
                                                        .AddGenerazioneMauCaratteriCasuali(3)
                                                        .AddGenerazioneMinCaratteriCasuali(7).Root;
            return p;
        }
        private IBuilderPassword GetBuilderMedium()
        {
            IBuilderPassword p = BuilderPassword.Create()
                                                       .AddGenerazioneMauCaratteriCasuali(3)
                                                       .AddGenerazioneMNumeriCasuali(2)
                                                       .AddGenerazioneMinCaratteriCasuali(5).Root;
            return p;
        }
        private IBuilderPassword GetBuilderHard()
        {
            IBuilderPassword p = BuilderPassword.Create()
                                                       .AddGenerazioneMauCaratteriCasuali(3)
                                                       .AddGenerazioneMNumeriCasuali(2)
                                                       .AddGenerazioneMinCaratteriCasuali(3)
                                                       .AddGenerazioneMCaratteriSpecialiCasuali(2).Root;
            return p;
        }
    }
}
