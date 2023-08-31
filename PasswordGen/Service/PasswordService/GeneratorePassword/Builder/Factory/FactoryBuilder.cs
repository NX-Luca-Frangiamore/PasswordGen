using PasswordGen.Model;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Tipi;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Reflection.Metadata.Ecma335;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory
{

    public class FactoryBuilder
    {
        private Dictionary<TypePassword,BuilderPassword> Builder=new();
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
        private BuilderPassword GetBuilderSoft()
        {
            BuilderPassword p =new CaratteriCasualiMau(3)
                                                      .AddGenerazioneMinCaratteriCasuali(7).Root;
            return p;
        }
        private BuilderPassword GetBuilderMedium()
        {
            BuilderPassword p = new CaratteriCasualiMau(3)
                                                      .AddGenerazioneMNumeriCasuali(2)
                                                      .AddGenerazioneMinCaratteriCasuali(5).Root;
            return p;
        }
        private BuilderPassword GetBuilderHard()
        {
            BuilderPassword p = new CaratteriCasualiMau(3)
                                                      .AddGenerazioneMNumeriCasuali(2)
                                                      .AddGenerazioneMinCaratteriCasuali(3)
                                                      .AddGenerazioneMCaratteriSpecialiCasuali(2).Root;
            return p;
        }
    }
}
