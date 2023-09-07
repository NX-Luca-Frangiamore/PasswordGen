using static PasswordGen.Service.PasswordService.GeneratorePassword.Factory.FactoryBuilder;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Factory
{
    public interface IFactory
    {
        public string? Get(TypePassword type);
    }
}
