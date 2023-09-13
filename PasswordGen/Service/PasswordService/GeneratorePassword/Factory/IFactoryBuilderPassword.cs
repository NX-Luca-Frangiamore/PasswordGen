using static PasswordGen.Service.PasswordService.GeneratorePassword.Factory.FactoryBuilderPassword;

namespace PasswordGen.Service.PasswordService.GeneratorePassword.Factory
{
    public interface IFactoryBuilderPassword
    {
        public string? Get(TypePassword type);
    }
}
