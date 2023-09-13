
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Factory
{

    public class FactoryBuilderPassword : IFactoryBuilderPassword
    {
        private readonly Dictionary<TypePassword, IBuilderPassword> Builder = new();
        public enum TypePassword
        {
            soft, medium, hard
        }
        public FactoryBuilderPassword()
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
            IBuilderPassword p = new BuilderPassword()
                                                      .AddGenerazioneMauCaratteriCasuali(3)
                                                      .AddGenerazioneMinCaratteriCasuali(7);
            return p;
        }
        private IBuilderPassword GetBuilderMedium()
        {
            IBuilderPassword p = new BuilderPassword()
                                                      .AddGenerazioneMauCaratteriCasuali(3)
                                                      .AddGenerazioneMNumeriCasuali(2)
                                                      .AddGenerazioneMinCaratteriCasuali(5);
            return p;
        }
        private IBuilderPassword GetBuilderHard()
        {
            IBuilderPassword p = new BuilderPassword()
                                                      .AddGenerazioneMauCaratteriCasuali(3)
                                                      .AddGenerazioneMNumeriCasuali(2)
                                                      .AddGenerazioneMinCaratteriCasuali(3)
                                                      .AddGenerazioneMCaratteriSpecialiCasuali(2);
            return p;
        }
    }
}
