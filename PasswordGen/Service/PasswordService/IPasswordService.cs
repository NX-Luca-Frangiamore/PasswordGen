using Microsoft.AspNetCore.Identity;
using PasswordGen.Model;
using static PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory.FactoryBuilder;

namespace PasswordGen.Service.PasswordService
{
    public interface IPasswordService

    {
       
        abstract public Task<bool> NewPassword(string? username, string? passwordUtente,string nomePassword,string password);
        abstract public Task<string?> NewPassword(string? username, string? passwordUtente, string nomePassword, TypePassword type);
        abstract public Task<bool> DeletePassword(string? username, string? passwordUtente, string nomePassword);
        abstract public Task<bool> ChangePassword(string? username, string? passwordUtente, string nomePassword, string newPassword);
        abstract public Task<PasswordModel?> GetPassword(string? username, string? passwordUtente,string nomePassword);
        abstract public Task<List<PasswordModel>?> GetPassword(string? username, string? passwordUtente);

    }
}
