using Microsoft.AspNetCore.Identity;
using PasswordGen.Model;
using static PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory.FactoryBuilder;

namespace PasswordGen.Service.PasswordService
{
    public interface IPasswordService

    {
       
        abstract public Task<bool> NewPassword(int? idUtente,string nomePassword,string password);
        abstract public Task<string?> NewPassword(int? idUtente, string nomePassword, TypePassword type);
        abstract public Task<bool> DeletePassword(int? idUtente, string nomePassword);
        abstract public Task<bool> ChangePassword(int? idUtente, string nomePassword, string newPassword);
        abstract public Task<PasswordModel?> GetPassword(int? idUtente, string nomePassword);
        abstract public Task<List<PasswordModel>?> GetPassword(int? idUtente);

    }
}
