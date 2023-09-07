using static PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory.FactoryBuilder;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory
{
    public interface IFactory
    {
        public string? Get(TypePassword type);
    }
}
